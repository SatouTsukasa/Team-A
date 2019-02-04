using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour {

    public Sprite LifeHeart;
    public float Life;
    Sprite[] sprites; 
    

	// Use this for initialization
	void Start () {
        Life = 4;
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(Life);
	}

    public void damege()
    {

        GetComponent<Image>().fillAmount -= 0.25f;
        Life -= 1f; 
    }
}
