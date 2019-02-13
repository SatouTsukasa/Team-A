using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class ButtonBlinker : MonoBehaviour {

    private GameObject TapButton;

    public float Step = 0.4f;

	// Use this for initialization
	void Start () {
        TapButton = GameObject.Find("TitleTapButton");
	}
	
	// Update is called once per frame
	void Update () {
        float toColor = this.TapButton.GetComponent<Image>().color.a;

        if(toColor < 0 || toColor > 1)
        {
            Step = Step * -1;
        }

        this.TapButton.GetComponent<Image>().color = new Color(255, 255, 255, toColor + Step);
    }
}


