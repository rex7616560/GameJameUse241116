using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using DG.Tweening;

public class PlayerController2D : MonoBehaviour
{
    public Rigidbody2D Rigidbody;

    [LabelText("速度")]
    public float PlayerSpeed;

    [LabelText("跳躍高度")]
    public float JumpHeight;

    [LabelText("跳躍次數")]
    public float JumpTimes;
    private float initJumpTime;

    public bool isJumping;
    public bool isGrounded;
    public enum Player
    {
        Player1,
        Player2,
        All,
    };

    [LabelText("哪位玩家")]
    public Player Whichplayer;
    void Start()
    {
        Rigidbody = gameObject.GetComponent<Rigidbody2D>();
        initJumpTime = JumpTimes;
    }


    void Update()
    {
        switch (Whichplayer)
        {
            case Player.Player1:
                Player1Control();
                break;
            case Player.Player2:
                Player2Control();
                break;
        }
    }
    void Player1Control()
    {
        float horizontal = Input.GetAxis("Horizontal1"); // 1P使用的水平輸入 (需在Input設定管理)
        if (horizontal != 0)
        {
            Rigidbody.velocity = new Vector2(horizontal * PlayerSpeed, Rigidbody.velocity.y);
        }

        if (Input.GetButtonDown("Jump1") && JumpTimes > 0) // 1P使用的跳躍按鍵 (需在Input設定管理)
        {
            Rigidbody.velocity = new Vector2(Rigidbody.velocity.x, JumpHeight);
            JumpTimes--;
            isJumping = true;
        }
    }
    void Player2Control()
    {
        float horizontal = Input.GetAxis("Horizontal2"); // 2P使用的水平輸入 (需在Input設定管理)
        if (horizontal != 0)
        {
            Rigidbody.velocity = new Vector2(horizontal * PlayerSpeed, Rigidbody.velocity.y);
        }

        if (Input.GetButtonDown("Jump2") && JumpTimes > 0) // 1P使用的跳躍按鍵 (需在Input設定管理)
        {
            Rigidbody.velocity = new Vector2(Rigidbody.velocity.x, JumpHeight);
            JumpTimes--;
            isJumping = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            JumpTimes = initJumpTime;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
            isJumping = false;
        }
    }
}
