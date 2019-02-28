using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lift : MonoBehaviour {
    public GameObject LiftDestroy;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector2(transform.position.x, transform.position.y - 0.03f);
	}

    /// <summary>
    /// 衝突処理
    /// </summary>
    /// <param name="col">衝突したObjの情報</param>
    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "LiftDestroy")
        {
            Debug.Log(col.gameObject.tag);
            Destroy(this);
        }
    }
}
