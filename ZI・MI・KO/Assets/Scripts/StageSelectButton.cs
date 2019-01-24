using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageSelectButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClick(int number)
    {
        //Debug.Log(number);
        switch (number)
        {
            case 0:
                SceneManager.LoadScene("Main");
                break;
            case 1:
                SceneManager.LoadScene("Main2");
                break;
            case 2:
                SceneManager.LoadScene("StageSelect");
                break;
            case 3:
                SceneManager.LoadScene("TitleScene");
                break;
            default:
                break;
        }
    }
}
