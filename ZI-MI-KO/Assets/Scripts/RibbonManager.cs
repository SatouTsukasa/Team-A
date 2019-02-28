using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RibbonManager : MonoBehaviour {
    public GameObject Player;

    private float x;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
   
	void Update () {
        x = Player.transform.localScale.x;
        if (Player != null)
        {
            if(x > 0)
            {
                Vector3 Ribbonpos = new Vector3(Player.transform.position.x + 0.9f, Player.transform.position.y + 0.5f, Player.transform.position.z);
                transform.localScale = new Vector3(1f, 1f, 1);
                transform.position = Ribbonpos;
            }
            else if(x < 0)
            {
                Vector3 Ribbonpos = new Vector3(Player.transform.position.x + 0.9f * -1, (Player.transform.position.y + 0.5f), Player.transform.position.z);
                transform.localScale = new Vector3(-1f, 1f, 1);
                transform.position = Ribbonpos;
            }
            
            
        }
	}

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Enemy")
        {
            GameObject.Find("EnemyCap").GetComponent<EnemyManager>().DestroyEnemy();
        }
    }
}
