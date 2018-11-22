using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraManager : MonoBehaviour {

    public GameObject player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(player != null)
        {
            Vector3 cameraPos = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);

            if (cameraPos.x < 0.0f)
            {
                cameraPos.x = 0.0f;
            }
            if(cameraPos.y > 0.0f)
            {
                cameraPos.y = 0.0f;
            }
            if(cameraPos.y < 5.0f)
            {
                cameraPos.y = 0.0f;
            }

            transform.position = cameraPos;
        }
	}
}
