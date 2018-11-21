using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    //定数定義
    private const int MAX_SCORE = 999999;

    public GameObject textGameOver;
    public GameObject textGameClear;
    public GameObject buttons;
    public GameObject textScoreNumber;

    public enum GAME_MODE
    {
        PLAY,
        CLEAR,
    };

    private int score = 0;          //スコア
    private int displayScore = 0;   //表示用スコア

    public GAME_MODE gameMode = GAME_MODE.PLAY; 

	// Use this for initialization
	void Start () {
        RefreshScore();
	}
	
	// Update is called once per frame
	void Update () {
		if(score > displayScore)
        {
            displayScore += 10;

            if(displayScore > score)
            {
                displayScore = score;
            }

            RefreshScore();
        }
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

    public void AddScore(int val)
    {
        score += val;
        if(score > MAX_SCORE)
        {
            score = MAX_SCORE;
        }
    }

    //表示用スコアを更新
    void RefreshScore()
    {
        textScoreNumber.GetComponent<Text>().text = displayScore.ToString();
    }
}
