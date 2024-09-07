using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MonsterController: MonoBehaviour //일반몬스터 
{
    [SerializeField] protected Animator animator;
    [SerializeField] protected float movePower;
    [SerializeField] protected Vector3 scale;
    protected int moveState;
    protected float direction;
    protected bool isTracing;
    protected GameObject traceTarget;
    
    protected virtual void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(ChangeState());
        scale= transform.localScale;
    }
    protected virtual void FixedUpdate()
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
            Vector3 playerPos = traceTarget.transform.position;

            if (playerPos.x < transform.position.x)
            {
                moveVelocity = Vector3.left;
                transform.localScale = new Vector3(-scale.x, scale.y, scale.z);
            }
            else if (playerPos.x > transform.position.x)
            {
                moveVelocity = Vector3.right;
                transform.localScale = new Vector3(scale.x, scale.y, scale.z);

            }

        }
        else
        {
            if (moveState == -1) //left
            {
                transform.localScale = new Vector3(-scale.x, scale.y, scale.z);
                moveVelocity = Vector3.left;
            }
            else if (moveState == 1)
            {
                moveVelocity = Vector3.right;
                transform.localScale = new Vector3(scale.x, scale.y, scale.z);

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
    public  void  Die()
    {
        animator.SetTrigger("isDie");
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
    public void EndCoroutine()
    {
        if (isTracing) { return; }
        StopCoroutine(ChangeState());
       
    }
    
}
