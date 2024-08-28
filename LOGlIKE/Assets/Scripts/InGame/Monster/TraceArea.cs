using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraceArea : MonoBehaviour
{
    [SerializeField] MonsterController controller;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            controller.StartTrace(collision.gameObject);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            controller.StayTrace();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            controller.EndTrace();
        }
    }
}
