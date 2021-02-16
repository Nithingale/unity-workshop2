using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    public void StartGame()
    {
        Button thisButton = GetComponent<Button>();
        thisButton.interactable = false;
        thisButton.GetComponentInChildren<Text>().color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
        GameManager.gameState = GameManager.GAME_STATE.play;
    }
}
