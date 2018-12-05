using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxContentManager : MonoBehaviour {

    public GameObject content;
    //public LayerMask playerLayer;

    private Vector2 movePoint;
    private bool IsOpened;
    private bool IsActive;
    //private bool Break;
    private bool Opened;
    private float totalTime;
    //private Animator animator;
    private SpriteRenderer sr;
    private BoxCollider2D[] m_Collider;
    private BoxCollider2D playerCollider;

    int second;

	// Use this for initialization
	void Start () {
        GameObject player = GameObject.FindWithTag("Player");
        if(player != null)playerCollider = player.GetComponent<BoxCollider2D>();
        m_Collider = GetComponentsInChildren<BoxCollider2D>();

        sr = GetComponent<SpriteRenderer>();

        content = Instantiate(content);
        content.transform.position = transform.position;
        content.transform.SetParent(gameObject.transform);
        content.gameObject.SetActive(false);

        IsOpened = false;
        IsActive = true;
        //Opened = true;

        movePoint = (Vector2)transform.position + new Vector2(0.0f, 1.2f);

        
	}
	
	// Update is called once per frame
	void Update () {
        //Break = Physics2D.Linecast(transform.position, transform.position - transform.up * 1f, playerLayer);
        if (IsOpened && IsActive)
        {  
            content.transform.position = Vector2.Lerp(content.transform.position, movePoint, 1.0f);
            Debug.Log(content);
            sr.color = Color.Lerp(sr.color, Color.gray, 1.0f);
        }
        

    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        
        /*if(col.gameObject.tag == "Player")
        {
            
            if (Break)
            {
                if (Opened == false) return;
                content.gameObject.SetActive(true);
                IsOpened = true;
                Debug.Log("bbb") ;
            }
        }*/
        if(m_Collider[1].IsTouching(playerCollider) && col.gameObject.CompareTag("Player"))
        {
            content.gameObject.SetActive(true);
            IsOpened = true;
            
            StartCoroutine(WaitSwitchOff());
            
        }
    }

    private IEnumerator WaitSwitchOff()
    {
        /*if (IsActive == false)
        {
            Debug.Log("aaa");
            animator.SetBool("BlockBreak", true);
            Destroy(gameObject, 1.5f);
        }*/
        yield return new WaitForSeconds(1.0f);
        IsActive = false;
    }

}
