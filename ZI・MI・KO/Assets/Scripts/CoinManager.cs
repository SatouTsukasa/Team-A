using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour {
    private const int COIN_POINT = 100;

    private GameObject gameManager;

	// Use this for initialization
	void Start () {
        gameManager = GameObject.Find("GameManager");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GetCoin()
    {
        gameManager.GetComponent<GameManager>().AddScore(COIN_POINT);
        Destroy(this.gameObject);
    }
}
