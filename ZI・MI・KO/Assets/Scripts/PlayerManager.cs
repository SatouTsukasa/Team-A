using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DG.Tweening;

public class PlayerManager : MonoBehaviour {

    public GameObject gameManager;

    public LayerMask blockLayer;

    private Rigidbody2D rbody;
    private Animator animator;

    private const float MOVE_SPEED = 3;

    private float moveSpeed;
    private float jumpPower = 500;


    private bool goJump = false;
    private bool canJump = false;
    private bool usingButtons = false;
    private bool isHit = false;

    private float HitCount = 0;

    private Renderer renderer;

    public enum MOVE_DIR
    {
        STOP,
        LEFT,
        RIGHT
    };

    private MOVE_DIR moveDirection = MOVE_DIR.STOP;

	// Use this for initialization
	void Start () {
        rbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        renderer = GetComponent<Renderer>();
        
	}
	
	// Update is called once per frame
	void Update () {
        canJump = Physics2D.Linecast(transform.position - (transform.right * 0.07f), transform.position - (transform.up * 0.07f), blockLayer) ||
            Physics2D.Linecast(transform.position + (transform.right * 0.07f), transform.position + (transform.up * 0.07f), blockLayer);

        if (!usingButtons)
        {
            float x = Input.GetAxisRaw("Horizontal");

            if(x == 0)
            {
                moveDirection = MOVE_DIR.STOP;
            }
            else
            {
                if(x < 0)
                {
                    moveDirection = MOVE_DIR.LEFT;
                }
                else
                {
                    moveDirection = MOVE_DIR.RIGHT;
                }
            }

            if (Input.GetKeyDown("space"))
            {
                PushJumpButton();
            }
        }
        if (isHit)
        {
            StartCoroutine("Invincible", isHit);
        }
        
    }

    private void FixedUpdate()
    {
        Debug.Log(HitCount);
        switch (moveDirection)
        {
            case MOVE_DIR.STOP:
                moveSpeed = 0;
                animator.SetBool("canWalk", false);
                break;
            case MOVE_DIR.LEFT:
                moveSpeed = MOVE_SPEED * -1;
                transform.localScale = new Vector2(-0.2f, 0.2f);
                animator.SetBool("canWalk", canJump);
                break;
            case MOVE_DIR.RIGHT:
                moveSpeed = MOVE_SPEED * 1;
                transform.localScale = new Vector2(0.2f, 0.2f);
                animator.SetBool("canWalk", canJump);
                break;
        }
        rbody.velocity = new Vector2(moveSpeed, rbody.velocity.y);

        if (goJump)
        {
            rbody.AddForce(Vector2.up * jumpPower);
            goJump = false;
        }
        animator.SetBool("onGround", canJump);
    }

    /// <summary>
    /// ボタン左移動
    /// </summary>
    public void PushLeftButton()
    {
        moveDirection = MOVE_DIR.LEFT;
        usingButtons = true;
    }

    /// <summary>
    /// ボタン右移動
    /// </summary>
    public void PushRightButton()
    {
        moveDirection = MOVE_DIR.RIGHT;
        usingButtons = true;
    }

    /// <summary>
    /// ボタン押してない
    /// </summary>
    public void ReleaseMoveButton()
    {
        moveDirection = MOVE_DIR.STOP;
        usingButtons = false;
    }

    /// <summary>
    /// ボタンジャンプ
    /// </summary>
    public void PushJumpButton()
    {
        if (canJump)
        {
            goJump = true;
        }
    }

    /// <summary>
    /// 衝突処理
    /// </summary>
    /// <param name="col">衝突したObjの情報</param>
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(gameManager.GetComponent<GameManager>().gameMode != GameManager.GAME_MODE.PLAY)
        {
            return;
        }

        if(col.gameObject.tag == "Trap")
        {
            GameObject.Find("LifeGauge").GetComponent<LifeManager>().damege();
            //Debug.Log("aaa");
            if (GameObject.Find("LifeGauge").GetComponent<LifeManager>().Life == 0)
            {

                //ライフが０なら
                gameManager.GetComponent<GameManager>().GameOver();
                DestroyPlayer();
            }
            else
            {
                isHit = true;
                //ライフが残っていれば

            }
        }

        if(col.gameObject.tag == "Goal")
        {
            Destroy(animator,0.5f);
            gameManager.GetComponent<GameManager>().GameClear();
            //GetComponent<Rigidbody2D>().gravityScale = 100;
            Destroy(this,0.5f);
        }

        if(col.gameObject.tag == "Enemy")
        {
            if(transform.position.y > col.gameObject.transform.position.y + 0.1f)
            {
                //踏んだ
                rbody.velocity = new Vector2(rbody.velocity.x, 0);
                rbody.AddForce(Vector2.up * jumpPower);
                col.gameObject.GetComponent<EnemyManager>().DestroyEnemy();
            }
            else
            {
                //Debug.Log(Life);
                //上からの接触ではない
                GameObject.Find("LifeGauge").GetComponent<LifeManager>().damege();
                if(GameObject.Find("LifeGauge").GetComponent<LifeManager>().Life == 0)
                {
                    
                    //ライフが０なら
                    gameManager.GetComponent<GameManager>().GameOver();
                    DestroyPlayer();
                }
                else
                {
                    isHit = true;
                    //ライフが残っていれば
                    
                }
                
            }
        }

        if(col.gameObject.tag == "OutZone")
        {
            gameManager.GetComponent<GameManager>().GameOver();
            DestroyPlayer();
        }

        if(col.gameObject.tag == "Coin")
        {
            col.gameObject.GetComponent<CoinManager>().GetCoin();
        }

        if(col.gameObject.tag == "JumpBlock")
        {
            if(transform.position.y > col.gameObject.transform.position.y)
            {
                //Debug.Log("bbb");
                rbody.AddForce(Vector2.up * jumpPower * 1.5f);
            }
            
        }
    }


    IEnumerator Invincible()
    {
        Debug.Log(isHit);
        if(isHit && HitCount == 0)
        {
            gameObject.layer = LayerMask.NameToLayer("PlayerDamage");
            HitCount = 1f;
            //isHit = true;
        }
        if (isHit)
        {
            //透明にする
            renderer.material.color = new Color(0.5f, 0.5f, 0.5f, 0);
            //0.05秒待つ
            yield return new WaitForSeconds(0.05f);
            //元に戻す
            renderer.material.color = new Color(1, 1, 1, 1);
            //0.05秒待つ
            yield return new WaitForSeconds(0.05f);
        }
        
        if (HitCount > 0)
        {
            HitCount -= Time.deltaTime;
            if(HitCount <= 0.1)
            {
                
                HitCount = 0;
                isHit = false;
                gameObject.layer = LayerMask.NameToLayer("Player");
            }
        }
        
    }

    public void DestroyPlayer()
    {
        gameManager.GetComponent<GameManager>().gameMode = GameManager.GAME_MODE.GAMEOVER;
        //コライダー削除
        CircleCollider2D circleCollider = GetComponent<CircleCollider2D>();
        BoxCollider2D boxCollider = GetComponent<BoxCollider2D>();
        Destroy(circleCollider);
        Destroy(boxCollider);

        //死亡アニメーション
        Sequence animSet = DOTween.Sequence();
        animSet.Append(transform.DOLocalMoveY(1.0f, 0.2f).SetRelative());
        animSet.Append(transform.DOLocalMoveY(-10.0f, 1.0f).SetRelative());
        Destroy(this.gameObject,1.2f);
    }
}
