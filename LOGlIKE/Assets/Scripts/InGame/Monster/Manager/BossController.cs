using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossController : MonsterController
{
    private const float range = 4.0f;
    [SerializeField] BoxCollider2D attack;
    [SerializeField]float attackDamage;
    bool inRange;
    bool isAttacking;
    private float detectionRange = range;
    Vector2 detection;
   

    
    protected override void Start()
    {
        attack.gameObject.SetActive(false);
        base.Start();
        inRange = false;
        isAttacking = false;

    }
    protected override void FixedUpdate()
    {
        Detecting();
        if (!inRange)
        {
            base.FixedUpdate();
        }
        else if(inRange&&!isAttacking)
        {
            isAttacking = true;
            base.moveState = 0;
            StartCoroutine(Attacking());
        }
    }
    public void Detecting()
    {
        if (transform.localScale.x > 0)
        {
            detection = Vector2.right;
           
        }
        else
        {
            detection = Vector2.left;
            
        }
        detection.y =-0.2f;
        RaycastHit2D rayHit = Physics2D.Raycast(transform.position,detection, detectionRange, LayerMask.GetMask("Player"));
        Debug.DrawRay(transform.position, detection * detectionRange, Color.red);
        if (rayHit && rayHit.collider.CompareTag("Player"))
        {
            inRange = true; 
        }
        else
        {
            inRange = false;
        }
    }

    
   
   IEnumerator Attacking()
    {
        attack.gameObject.SetActive(true);
        base.animator.SetTrigger("isAttack");
        yield return CoroutineCache.waitForSeconds(0.42f);
        attack.gameObject.SetActive(false);
        isAttacking = false;
    }



}
