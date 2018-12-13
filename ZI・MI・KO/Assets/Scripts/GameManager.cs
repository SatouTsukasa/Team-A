using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    //定数定義
    private const int MAX_SCORE = 999999;
    private float timeleft;
    private float timer;

    public GameObject textGameOver;
    public GameObject textGameClear;
    public GameObject TextFinalTotalScoreTime;
    public GameObject TextFinalScore;
    public GameObject TextFinalTime;
    public GameObject TextFinalTotalScore;
    public GameObject buttons;
    public GameObject textScoreNumber;
    public GameObject TimerNumber;
    
    public Text messageStart;

    public enum GAME_MODE
    {
        PLAY,
        CLEAR,
        GAMEOVER,
    };

    private int score = 0;          //スコア
    private int displayScore = 0;   //表示用スコア
    private int time = 100;           //制限時間

    public GAME_MODE gameMode = GAME_MODE.PLAY;

    public bool gameOver;
    public bool gameClear;

	// Use this for initialization
	void Start () {
        RefreshScore();
        messageStart.enabled = true;
        gameOver = false;
        gameClear = false;
    }
	
	// Update is called once per frame
	void Update () {
        timeleft -= Time.deltaTime;
        timer += Time.deltaTime;
        if (timer > 1)
        {
            messageStart.enabled = false;
            timer = 0;
        }

        if (score > displayScore)
        {
            displayScore += 10;

            if(displayScore > score)
            {
                displayScore = score;
            }

            RefreshScore();
        }
        if(timeleft <= 0.0 && (!gameOver || gameClear == false))
        {
            if (gameClear == false)
            {
                time--;
                RefreshTime();
                timeleft = 1.0f;
            }
            if (time < 1)
            {
                time = 1;
                GameOver();
                GameObject.Find("Player").GetComponent<PlayerManager>().DestroyPlayer();
            }
            

        }
    }

    //ゲームオーバー時
    public void GameOver()
    {
        gameMode = GAME_MODE.GAMEOVER;
        textGameOver.SetActive(true);
        buttons.SetActive(false);
        gameOver = true;
    }

    //ゲームクリア時
    public void GameClear()
    {
        gameMode = GAME_MODE.CLEAR;
        textGameClear.SetActive(true);
        TextFinalTotalScoreTime.SetActive(true);
        TextFinalScore.SetActive(true);
        TextFinalTime.SetActive(true);
        TextFinalTotalScore.SetActive(true);
        RefreshFinalScore();
        RefreshFinalTime();
        RefreshFinalTotalScore();
        buttons.SetActive(false);
        gameClear = true;
    }

    //スコア更新
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

    //表示用タイム更新
    void RefreshTime()
    {
        TimerNumber.GetComponent<Text>().text = time.ToString();
    }

    void RefreshFinalScore()
    {
        TextFinalScore.GetComponent<Text>().text = displayScore.ToString();
    }

    void RefreshFinalTime()
    {
        TextFinalTime.GetComponent<Text>().text = time.ToString();
    }

    void RefreshFinalTotalScore()
    {
        TextFinalTotalScore.GetComponent<Text>().text = (displayScore + time * 100).ToString();
    }
}
