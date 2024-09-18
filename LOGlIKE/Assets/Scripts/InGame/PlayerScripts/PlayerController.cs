using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController: MonoBehaviour
{
    #region SerializeField
   [SerializeField] float movePower = 5.0f;
   [SerializeField] float jumpPower = 13.0f;
   
   [SerializeField]bool isJumping = false;
   
    #endregion

    #region private
    private Rigidbody2D rigid;
    private GameObject currentOneWayPlatForm;
    private BoxCollider2D playerCollider;
    private PlayerAnimationController animeController;
    private JumpManager jumpManager;

    #endregion



    void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();
     
        jumpManager=gameObject.GetComponent<JumpManager>();
        playerCollider = gameObject.GetComponent<BoxCollider2D>();
        animeController = gameObject.GetComponent<PlayerAnimationController>();
        currentOneWayPlatForm = null;
    }
      
      
       
    void Update()
    {
       
         if(Input.GetKeyDown(KeyCode.DownArrow))
         {
           if(currentOneWayPlatForm!=null)
            {
                StartCoroutine(DownJump());
            }
         }
        
        if (Input.GetButtonDown("Jump")&&jumpManager.CanJump())
        {
            isJumping = true;
           
            animeController.TriggerJumpAnimation();
        }

        if (Input.GetAxisRaw("Horizontal") == 0)
        {
            animeController.BoolRunningAnimation(false);
        }
        else
        {
            animeController.BoolRunningAnimation(true);
        }
       
    }


    void FixedUpdate()
    {
        Move();
        Jump();
   
    }
    

    void Move()
    {
        float horizonInput = Input.GetAxisRaw("Horizontal");
        if (horizonInput != 0)
        {
            float moveDirection =  horizonInput*movePower*Time.deltaTime;
            transform.localScale=new Vector3(-horizonInput, 1, 1);
            transform.position += new Vector3(moveDirection, 0, 0);
        }
    }

    void Jump()
    {
       
        if(!isJumping)
        {
            return;
        }
       
        rigid.velocity = Vector2.zero;

        Vector2 jumpVelocity = Vector2.up * jumpPower;
        rigid.AddForce(jumpVelocity, ForceMode2D.Impulse);
        jumpManager.IncreaseJumpCount();
        isJumping = false;
        
    }
    IEnumerator DownJump()
    {
        BoxCollider2D boxCollider2D=currentOneWayPlatForm.GetComponent<BoxCollider2D>();
        Physics2D.IgnoreCollision(playerCollider, boxCollider2D);
        yield return CoroutineCache.waitForSeconds(1.5f);
        Physics2D.IgnoreCollision(playerCollider, boxCollider2D,false);

    }


    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if(collision.otherCollider!=null)
        {
            jumpManager.ResetJumpCount();
        }
         if(collision.gameObject.CompareTag("OneWayPlatForm"))
        {
            currentOneWayPlatForm = collision.gameObject;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("OneWayPlatForm"))
        {
            currentOneWayPlatForm = null;
        }
    }





}