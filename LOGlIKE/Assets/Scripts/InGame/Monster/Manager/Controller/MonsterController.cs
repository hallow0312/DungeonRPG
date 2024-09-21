using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MonsterController: MonoBehaviour //일반몬스터 
{
    #region public/protected
    public Animator animator;
    [SerializeField] protected float movePower;
    [SerializeField] protected Vector3 scale;

    [SerializeField] public float attackDelay = 1.5f;
    public int detectionMove;
    public float direction;
    public bool isTracing;
    protected GameObject traceTarget;
    #endregion

    #region MonsterState
    public IMonsterState moveState = new MoveState();
    public IMonsterState hurtState = new HurtState();
    public IMonsterState chaseState = new ChaseState();
    public IMonsterState currentState;
    #endregion
    protected virtual void Start()
    {
        animator = GetComponent<Animator>();
        
        scale= transform.localScale;
        TransitionState(moveState);
    }
    protected virtual void FixedUpdate()
    {
        currentState.UpdateState(this);
    }

 
    public void TransitionState(IMonsterState monsterState)
    {
        if (currentState != null)
        {
            currentState.ExitState(this); 
        }

        currentState = monsterState;
        currentState.EnterState(this); 
    }

    public void Moving()
    {
        if ((detectionMove==0))
        {
            return;
        }

        Vector3 moveVelocity = Vector3.zero;

        if (detectionMove == -1) //left
        {
             transform.localScale = new Vector3(-scale.x, scale.y, scale.z);
             moveVelocity = Vector3.left;
        }
        else if (detectionMove == 1)
        {
           moveVelocity = Vector3.right;
           transform.localScale = new Vector3(scale.x, scale.y, scale.z);

        }

        direction = moveVelocity.x * movePower * Time.deltaTime;
        Vector2 frontVec = transform.position + new Vector3(direction, 0, 0);
        RaycastHit2D rayHit = Physics2D.Raycast(frontVec, Vector2.down, 6, LayerMask.GetMask("Ground"));
        RaycastHit2D rayHit2 = Physics2D.Raycast(transform.position, moveVelocity,0.1f , LayerMask.GetMask("Ground"));
        if (!rayHit.collider||rayHit2)
        {
            detectionMove *= -1;
        }
        Debug.DrawRay(frontVec, Vector2.down*3, new Color(0, 1, 0));
        Debug.DrawRay(frontVec, moveVelocity*0.1f, new Color(0, 1, 0));

        transform.position += new Vector3(direction, 0,0);
    }
    public void TracePlayer()
    {
        if (traceTarget == null||!isTracing) return;
        Vector3 moveVelocity = Vector3.zero;
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
        direction = moveVelocity.x * movePower * Time.deltaTime;
        Vector2 frontVec = transform.position + new Vector3(direction, 0, 0);
        RaycastHit2D rayHit = Physics2D.Raycast(frontVec, Vector2.down, 5, LayerMask.GetMask("Ground"));
       

        if (!rayHit.collider)
        {
            direction *= -1;
        }
        Debug.DrawRay(frontVec, Vector2.down * 3, new Color(0, 1, 0));
        transform.position += new Vector3(direction, 0, 0);
    }


    public void Hurt()
    {
        TransitionState(hurtState);
    }
    public  void  Die()
    {
        isTracing = false;
        StopAllCoroutines();
        animator.SetTrigger("isDie");
    }
   
    public void StartChase(GameObject target)
    {
        traceTarget = target;
        isTracing = true;
        TransitionState(chaseState);
    }
   
    public void EndChase()
    {
        traceTarget = null;
        isTracing = false;
        TransitionState(moveState);
        
    }
   
    
}
