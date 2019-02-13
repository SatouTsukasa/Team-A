using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBlock : MonoBehaviour {
    public float JumpPower;
    public GameObject Player;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Jump()
    {
        Debug.Log("bnm");
        if (Player.transform.position.y > transform.position.y)
        {
            Player.GetComponent<Rigidbody2D>().AddForce(Vector2.up * JumpPower);
        }
    }
}
