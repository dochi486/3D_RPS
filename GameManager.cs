using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    Menu,
    InPeace,
}  

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    public GameState gameState = GameState.InPeace;
    new protected void Awake()
    {
        DontDestroyOnLoad(this);
        gameState = GameState.InPeace; //Stage������ �� �ν����Ϳ� �ٸ� ������ �Ǿ��ִ��� awake���� �ٲ��ִ� �κ�
    }
    public static GameState GameState
    {
        get => Instance.gameState;
        set
        {
            if (Instance == null)
                return;


            if (Instance.gameState == value)
                return;


            var previousState = Instance.gameState;
            Instance.gameState = value;

            if (value == GameState.Menu)
                Time.timeScale = 0;
            else
                Time.timeScale = 1;

            Debug.Log($"Game State : {previousState} => {value} " + $"Time Scale:{Time.timeScale}");
        }
    }
}
