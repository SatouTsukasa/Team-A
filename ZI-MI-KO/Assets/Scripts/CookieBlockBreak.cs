using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookieBlockBreak : MonoBehaviour {

    public LayerMask playerLayer;
    private bool Break;
    private Animator animator;

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        Break = Physics2D.Linecast(transform.position, transform.position - transform.up * 1f, playerLayer);
        //Debug.Log(Break);
    }

    /// <summary>
    /// 衝突処理
    /// </summary>
    /// <param name="col">衝突したObjの情報</param>
    private void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("aaaa");
        if (col.gameObject.tag == "Player")
        {
            if (Break)
            {
                animator.SetBool("BlockBreak", true);
                Destroy(gameObject, 0.3f);
            }
        }
    }
}
