using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour {
    private const int COIN_POINT = 100;

    private GameObject gameManager;

    //private AudioSource audiosource;

    //public AudioClip CoinSE;

	// Use this for initialization
	void Start () {
        //audiosource = GameObject.Find("GameManager").GetComponent<AudioSource>();
        gameManager = GameObject.Find("GameManager");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// コイン入手時
    /// </summary>
    public void GetCoin()
    {
        //audiosource.PlayOneShot(CoinSE);
        gameManager.GetComponent<GameManager>().AddScore(COIN_POINT);
        Destroy(this.gameObject);
    }
}
