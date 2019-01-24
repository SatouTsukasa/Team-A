using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageSelectButton : MonoBehaviour {

    public GameObject StageSelect;
    public GameObject TitleButton;
    public GameObject ReturnButton;
    public GameObject VolumeSlider;
    public GameObject RetryButton;

	// Use this for initialization
	void Start () {
        StageSelect = GameObject.Find("StageSelectButton");
        TitleButton = GameObject.Find("TitleButton");
        ReturnButton = GameObject.Find("ReturnButton");
        VolumeSlider = GameObject.Find("VolumeSlider");
        StageSelect.SetActive(false);
        TitleButton.SetActive(false);
        ReturnButton.SetActive(false);
        VolumeSlider.SetActive(false);
        RetryButton.SetActive(false);
        Time.timeScale = 1f;
    }
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(Time.timeScale);
        Debug.Log(StageSelect);

    }

    public void OnClick(int number)
    {
  
        Debug.Log(number);

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
            case 4:
                    Debug.Log("asdf");
                    StageSelect.SetActive(true);
                    TitleButton.SetActive(true);
                    ReturnButton.SetActive(true);
                    VolumeSlider.SetActive(true);
                //Pause = GameObject.Instantiate(PauseUI) as GameObject;
                Time.timeScale = 0f;        
                break;
            case 5:
                StageSelect.SetActive(false);
                TitleButton.SetActive(false);
                ReturnButton.SetActive(false);
                VolumeSlider.SetActive(false);
                Time.timeScale = 1f;
                
                break;
            default:
                break;
        }
    }
}
