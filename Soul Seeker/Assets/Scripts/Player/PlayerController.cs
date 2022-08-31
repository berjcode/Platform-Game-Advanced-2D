using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    private float vertical;
    private float horizontal;
    public float speedPlayer;
    public float jumpForce;
    private Vector2 movement;
    private Rigidbody2D rb;

    
    public SpriteRenderer _renderer;
    
    void Start()
    {
       rb=GetComponent<Rigidbody2D>(); 
       _renderer= GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoving();
        Jump();
        flip();
    }


    #region MovementCode
    private void PlayerMoving()
    {
        
        horizontal= Input.GetAxis("Horizontal");
        RunAnimation();
        

      
       transform.position += new Vector3(horizontal,0,0)*Time.deltaTime*speedPlayer;
        
    }


    private void Jump()
    {
        if(Input.GetKeyDown("space"))
        {
            rb.AddForce(new Vector2(0,jumpForce),ForceMode2D.Impulse);
            JumpAnim();
        }
    }

    #endregion


    #region Jump Animation

    private void JumpAnim()
    {
        if(horizontal != 0 )
        {
            animator.SetBool("isJump",true);
        }else{
            animator.SetBool("isJump",false);
        }
    }

    #endregion

    #region Run Animation

    private void RunAnimation()
    {
        if(horizontal!=0)
        {
            animator.SetBool("isRuning",true);
        }else
        {
            animator.SetBool("isRuning",false);
        }
    }

    #endregion


    #region Chracter Flip

    void flip()
    {
       if (Input.GetAxisRaw("Horizontal") > 0)
    {
        _renderer.flipX = false;
    }
    else if (Input.GetAxisRaw("Horizontal") < 0)
    {
        _renderer.flipX = true;
    }   
    }
    #endregion
}
