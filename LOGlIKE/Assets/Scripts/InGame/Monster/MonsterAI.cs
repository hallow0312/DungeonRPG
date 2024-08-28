 using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MonsterController: MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] float movePower = 2.0f;
    private int moveState;
    private float direction;
    bool isTracing;
    private GameObject traceTarget;

 
    private void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(ChangeState());
       
    }
    private void FixedUpdate()
    {
        Moving(); 
    }
    IEnumerator ChangeState()
    {
        moveState = Random.Range(-1,2); // idle //left//right
        
        if (moveState == 0)
        {
            animator.SetBool("isMove", false);
            transform.position = transform.position;
        }
        else
        {
            animator.SetBool("isMove", true);
            transform.position = transform.position;
           
        }
        yield return CoroutineCache.waitForSeconds(2.0f);
       
        StartCoroutine(ChangeState());
    }

    public void Moving()
    {
        if ((moveState==0))
        {
            return;
        }
        Vector3 moveVelocity = Vector3.zero;
     

        if (isTracing)
        {
          Vector3 playerPos=traceTarget.transform.position;
            if (playerPos.x < transform.position.x)
            {
                moveVelocity = Vector3.left;
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else if(playerPos.x>transform.position.x)
            {
                moveVelocity = Vector3.right;
                transform.localScale = new Vector3(1, 1, 1);
            }
        }
        else
        {
            if (moveState == -1) //left
            {
                moveVelocity = Vector3.left;
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else if (moveState == 1)
            {
                moveVelocity = Vector3.right;
                transform.localScale = new Vector3(1, 1, 1);
            }
        }
        direction = moveVelocity.x * movePower * Time.deltaTime;
        Vector2 frontVec = transform.position + new Vector3(direction, 0, 0);
        RaycastHit2D rayHit = Physics2D.Raycast(frontVec, Vector2.down, 1, LayerMask.GetMask("Ground"));

        if (!rayHit.collider)
        {
            direction *= -1;
        }
        Debug.DrawRay(frontVec, Vector2.down, new Color(0, 1, 0));
        transform.position += new Vector3(direction, 0,0);
    }
    public void Hurt()
    {
        animator.SetTrigger("isHurt");
    }

   
    public void StartTrace(GameObject target)
    {
        StopCoroutine(ChangeState());
        traceTarget = target;
    }
    public void  StayTrace()
    {
        isTracing = true;
        animator.SetBool("isMove", true);
    }
    public void EndTrace()
    {
        traceTarget = null;
        isTracing = false;
        StartCoroutine(ChangeState());
    }
    
}
