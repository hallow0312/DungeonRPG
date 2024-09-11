using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class TraceArea : MonoBehaviour
{
    private const float EndTime = 5.0f;
    [SerializeField] MonsterController contoller;
    [SerializeField] float TraceRange;
    Vector2 direction;
    Vector2 backDirection;
    private bool tracing;
    private float traceTimer;
    
    private void Start()
    {
        tracing = false;
    }
    private void Update()
    { 
         Detecting();
    }
    public void Detecting()
    {
        Vector2 frontVec;
        if (transform.parent.localScale.x > 0)
        {
            direction = Vector2.right;
            backDirection = Vector2.left;
            frontVec = transform.position;
         
        }
        else
        {
            direction = Vector2.left;
            backDirection= Vector2.right;
            frontVec= transform.position;
       
        }
       

        RaycastHit2D rayHit = Physics2D.Raycast(frontVec, direction, TraceRange, LayerMask.GetMask("Player"));
        RaycastHit2D rayHit2 = Physics2D.Raycast(frontVec, backDirection, TraceRange, LayerMask.GetMask("Player"));
        Debug.DrawRay(frontVec, direction * TraceRange, Color.blue);
        Debug.DrawRay(frontVec, backDirection * TraceRange, Color.blue);

        if (rayHit||rayHit2)
        {
            traceTimer = 0;
            contoller.StartChase(rayHit.collider.gameObject);
            tracing = true;
        }
        else
        {
            if (tracing)
            {
                traceTimer += Time.deltaTime;
                if (traceTimer >= EndTime)
                {
                    tracing = false;
                    contoller.EndChase();
                }
            }
        }
    }
}
