using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftUpDown : MonoBehaviour {
    public GameObject LiftDestroy;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector2(transform.position.x, transform.position.y - 0.03f);
	}

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.gameObject == LiftDestroy)
        {
            Destroy(this.gameObject);
        }
    }
}
