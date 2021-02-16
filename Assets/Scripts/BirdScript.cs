using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BirdScript : MonoBehaviour
{
    public GameObject w0;
    public GameObject w1;
    public float speed = 150.0f;
    public GameObject score;
    public Button playButton;
    public Text highScore;

    private Rigidbody2D rb;

    private float fx;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (GameManager.gameState == GameManager.GAME_STATE.play)
        {
            if (rb.simulated == false)
            {
                rb.simulated = true;
                fx = speed;
                rb.AddForce(new Vector2(fx, 0.0f), ForceMode2D.Force);
            }
            else
            {
                if (Input.GetMouseButtonDown(0))
                {
                    rb.AddForce(new Vector2(0.0f, 10.0f), ForceMode2D.Impulse);
                }
                if (Input.GetMouseButtonDown(1))
                {
                    GameManager.gameState = GameManager.GAME_STATE.gameOver;
                }
            }
        }
        else if (GameManager.gameState == GameManager.GAME_STATE.gameOver)
        {
            rb.simulated = false;
            rb.velocity = Vector2.zero;
            transform.position = new Vector3(0.0f, 0.5f, 0.0f);
            transform.rotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
            transform.localScale = new Vector3(0.6f, 0.6f, 1.0f);
            GameManager.highScore = GameManager.gameScore;
            GameManager.gameScore = 0;
            highScore.text = GameManager.highScore.ToString() + " best";
            score.GetComponent<TextMesh>().text = "00";
            playButton.interactable = true;
            playButton.GetComponentInChildren<Text>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            GameManager.gameState = GameManager.GAME_STATE.menu;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == w0 || collision.gameObject == w1)
        {
            fx = -fx;
            rb.AddForce(new Vector2(fx, 0.0f), ForceMode2D.Force);
            transform.localScale = new Vector3(0.6f * fx / Mathf.Abs(fx), 0.6f, 1.0f);
            if (GameManager.gameScore < 99)
            {
                GameManager.gameScore++;
            }
            score.GetComponent<TextMesh>().text = GameManager.gameScore < 10 ? "0" + GameManager.gameScore.ToString() : GameManager.gameScore.ToString();
        }
    }
}
