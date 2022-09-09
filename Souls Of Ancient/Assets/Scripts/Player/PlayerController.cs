using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public static PlayerController Instance { get; private set; }
    public void Awake()
    {
        Instance = this;
    }
    public Animator animator;
     private float vertical;
     private float horizontal;
    public float speedPlayer;
    
    public float jumpForce;

    public EnemyBulletController enemy;
    private Vector2 movement;
    private Rigidbody2D rb;
    private bool isGrounded=true;
    private bool attack;
    public int playerCoin;
    

    private SpriteRenderer _renderer;
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
        animator= GetComponent<Animator>();
        _renderer =GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PlayerMoving();
        FlipMove();
        
       FireAttack();
       PlayerKill();

         if(Input.GetKey("space"))
         {
            Jump();
             animator.SetBool("isWalk",false);
         }
        
            
    }


    private void PlayerMoving()
    {
        horizontal = Input.GetAxis("Horizontal");
       
        WalkAnimation();

       transform.position += new Vector3(horizontal,0,0)*Time.deltaTime*speedPlayer;
    }

    #region  Walk Animation 
   

      private void WalkAnimation()
    {
        if(horizontal!=0)
        {
            animator.SetBool("isWalk",true);
        }else
        {
            animator.SetBool("isWalk",false);
        }
    }
    #endregion

    #region  Jump
     private void Jump()
     {
       
        
            if(isGrounded==true)
            {   
                isGrounded=false;
                
                
                rb.AddForce(new Vector2(0,jumpForce),ForceMode2D.Impulse);
                
            }
           // JumpAnimation();
            
        
     }
    #endregion

    #region  JumpAnimation
    void JumpAnimation()
    {
        if(horizontal!=0)
             {
                animator.SetBool("isJump",true);
            }
        else
            {
            animator.SetBool("isJump",false);
            }
    }
   
    #endregion
    #region Character Flip

    void FlipMove()
    {   
        if(Input.GetAxisRaw("Horizontal") > 0)
        {
            _renderer.flipX=false;
            GunC.Instance.isLookingLeft =true;
            
        }
        else if (Input.GetAxisRaw("Horizontal")<0)

        {
            _renderer.flipX = true;
              GunC.Instance.isLookingLeft =false;
            
        }

    }
    #endregion

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag=="platform")
        {
            isGrounded =true;
           
        }else
        {
            isGrounded =false;
        }

         if(col.gameObject.tag=="Enemy")
        {
            isGrounded =true;
           
        }
        



          if(col.gameObject.tag =="Enemy")
        {
           
             ScoreManager.Instance.HealthPlayer--;
             ScoreManager.Instance.healthText.text = ScoreManager.Instance.HealthPlayer.ToString();
        }

          
        
        

    }

        
    private void FireAttack()
    {
        
        if(Input.GetMouseButton(0))
        {
           animator.SetBool("isAttack",true);
          
           
        }else
        {
            animator.SetBool("isAttack",false);
           
        }
        
        
    }

    private void PlayerKill()
    {
        if(ScoreManager.Instance.HealthPlayer==0)
        {
            Destroy(gameObject);
        }

        

    }

    #region  AttackSecond
   
    #endregion

    

   
}
