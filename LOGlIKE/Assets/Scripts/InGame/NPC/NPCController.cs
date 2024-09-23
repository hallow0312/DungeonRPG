using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    [SerializeField] NPCSprite sprite;
    [SerializeField] Animator animator;
    [SerializeField] int state;
    [SerializeField] NPC npc;
    
    private Rect moveBound;
    private float direction;
    private float movePower= 1.0f;
    private bool isTrigger;
    private bool isInteract;
    Coroutine moveCoroutine;

    private void Start()
    {
        animator = GetComponent<Animator>();
        sprite = GetComponent<NPCSprite>();
        isTrigger = false;
        isInteract = false;
        moveBound = new Rect(transform.position.x - 5.0f, transform.position.y, 10.0f, 0);
        moveCoroutine = StartCoroutine(ChangeDirection());
        
    }
    
    void  Update()
    {
        if(isTrigger&&!isInteract)
        {
            if(Input.GetKeyDown(KeyCode.G))
            {
                StartNPC();
            }
        }
    }
   
    private void FixedUpdate()
    {
        NPCMove();
        
    }
    public void NPCMove()
    {
        if(state==0)
        {
            animator.SetBool("isMove", false);
        }
        else
        {
            animator.SetBool("isMove", true);
            if(state==-1)
            {
                sprite.FlipLeft();
            }
            else if(state==1)
            {
                sprite.FlipRight();
            }
            direction = transform.position.x + state * movePower * Time.deltaTime;
            if (direction <= moveBound.xMin || direction >= moveBound.xMax)
            {
                state *= -1;
            }
            direction=Mathf.Clamp(direction, moveBound.xMin, moveBound.xMax);

            transform.position = new Vector2(direction, transform.position.y);
        }
    }
    IEnumerator ChangeDirection()
    {
        state = Random.Range(-1, 2);
        yield return new WaitForSeconds(5.0f);
       moveCoroutine= StartCoroutine(ChangeDirection());
    }

   

   
    public void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("Player"))
        {
            sprite.HightLight();
            isTrigger = true;
        }

    }
    public void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            sprite.MakeNormal();
            Debug.Log("normal");
            isTrigger = false;
        }
       
    }
    
    public void StartNPC()
    {
        if (npc != null)
        {
            isInteract = true;
          
            npc.StartChat();
            if(moveCoroutine!=null)
            {
                StopCoroutine(moveCoroutine);
                state = 0;
            }
            moveCoroutine = null;
        }
        Debug.Log("대화 시작");
    }
    public void EndNPC()
    {
      moveCoroutine= StartCoroutine(ChangeDirection());
        isInteract = false;
        
    }

}
