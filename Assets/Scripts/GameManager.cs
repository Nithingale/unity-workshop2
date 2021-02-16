using UnityEngine;

public static class GameManager
{
	public enum GAME_STATE { menu, play, gameOver };
    public static GAME_STATE gameState = GAME_STATE.menu;
    public static int gameScore = 0;
    public static int highScore = 0;
}
