using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject textGameOver;
    public GameObject textGameClear;
    public GameObject buttons;

    public enum GAME_MODE
    {
        PLAY,
        CLEAR,
    };

    public GAME_MODE gameMode = GAME_MODE.PLAY; 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GameOver()
    {
        textGameOver.SetActive(true);
        buttons.SetActive(false);
    }

    public void GameClear()
    {
        gameMode = GAME_MODE.CLEAR;
        textGameClear.SetActive(true);
        buttons.SetActive(false);
    }
}
