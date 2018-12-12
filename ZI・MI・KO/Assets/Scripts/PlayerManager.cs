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
        
    }

    private void FixedUpdate()
    {
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
            //Debug.Log("aaa");
            gameManager.GetComponent<GameManager>().GameOver();
            DestroyPlayer();
        }

        if(col.gameObject.tag == "Goal")
        {
            gameManager.GetComponent<GameManager>().GameClear();
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
                //上からの接触ではない
                gameManager.GetComponent<GameManager>().GameOver();
                DestroyPlayer();
            }
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
