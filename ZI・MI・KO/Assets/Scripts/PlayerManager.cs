using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    public LayerMask blockLayer;

    private Rigidbody2D rbody;

    private const float MOVE_SPEED = 3;
    private float moveSpeed;
    private float jumpPower = 400;
    private bool goJump = false;
    private bool canJump = false;

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
	}
	
	// Update is called once per frame
	void Update () {
        canJump = Physics2D.Linecast(transform.position - (transform.right * 0.07f), transform.position - (transform.up * 0.07f), blockLayer) ||
            Physics2D.Linecast(transform.position + (transform.right * 0.07f), transform.position + (transform.up * 0.07f), blockLayer);

    }

    private void FixedUpdate()
    {
        switch (moveDirection)
        {
            case MOVE_DIR.STOP:
                moveSpeed = 0;
                break;
            case MOVE_DIR.LEFT:
                moveSpeed = MOVE_SPEED * -1;
                transform.localScale = new Vector2(-0.27f, 0.27f);
                break;
            case MOVE_DIR.RIGHT:
                moveSpeed = MOVE_SPEED * 1;
                transform.localScale = new Vector2(0.27f, 0.27f);
                break;
        }
        rbody.velocity = new Vector2(moveSpeed, rbody.velocity.y);

        if (goJump)
        {
            rbody.AddForce(Vector2.up * jumpPower);
            goJump = false;
        }
    }

    public void PushLeftButton()
    {
        moveDirection = MOVE_DIR.LEFT;
    }

    public void PushRightButton()
    {
        moveDirection = MOVE_DIR.RIGHT;
    }

    public void ReleaseMoveButton()
    {
        moveDirection = MOVE_DIR.STOP;
    }
    public void PushJumpButton()
    {
        if (canJump)
        {
            goJump = true;
        }
    }
}
