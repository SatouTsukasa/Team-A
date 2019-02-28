using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftInstance : MonoBehaviour {

    public GameObject Lift;

	// Use this for initialization
	void Start () {
        InvokeRepeating("Instance", 0f, 4.0f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// リフト生成
    /// </summary>
    void Instance()
    {
        Instantiate(Lift,new Vector3(transform.position.x,transform.position.y,transform.position.z),Quaternion.identity);
    }

    
}
