using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxContentManager : MonoBehaviour {

    public GameObject content;
    public LayerMask playerLayer;

    private Vector2 movePoint;
    private bool IsOpened;
    private bool IsActive;
    private bool Break;
    private bool Opened;

    private float totalTime;
    int second;

	// Use this for initialization
	void Start () {
        
        content = Instantiate(content);
        content.transform.position = transform.position;
        content.transform.SetParent(gameObject.transform);
        content.gameObject.SetActive(false);

        IsOpened = false;
        IsActive = true;
        Opened = true;

        movePoint = (Vector2)transform.position + new Vector2(0.0f, 1.2f);
	}
	
	// Update is called once per frame
	void Update () {
        Break = Physics2D.Linecast(transform.position, transform.position - transform.up * 1f, playerLayer);
        if (IsOpened && IsActive)
        {  
            content.transform.position = Vector2.Lerp(content.transform.position, movePoint, 0.5f);
            //IsActive = false;               
        }

	}

    private void OnCollisionEnter2D(Collision2D col)
    {
        
        if(col.gameObject.tag == "Player")
        {
            //Debug.Log("aaa");
            if (Break)
            {
                if (Opened == false) return;
                content.gameObject.SetActive(true);
                IsOpened = true;
                Debug.Log("bbb") ;
            }
        }
    }

}
