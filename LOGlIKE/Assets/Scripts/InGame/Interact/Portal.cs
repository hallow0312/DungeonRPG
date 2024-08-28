using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Portal : MonoBehaviour, IInteractable
{
    [SerializeField] GameObject positionObject;
    [SerializeField] TMP_Text portalText;

    
    [SerializeField] bool readyToMove;
    [SerializeField] bool inTrigger;

    [SerializeField] float readyTime = 3.0f;
    [SerializeField] float minusTime = 1.0f;
    void Start() 
    {
        readyToMove = false;
      
        portalText.fontSize = 0.4f;
        ResetText();
    }

    void Update()
    {
        if(inTrigger&&Input.GetKeyUp(KeyCode.G))
        {
            Interact();
        }
    }
    public void Interact()
    {
        inTrigger = false;
        StartCoroutine(IdleTime());
        
    }


   
    private IEnumerator IdleTime()
    {

        float timer = readyTime;
        while (timer > 0)
        {
            portalText.text = timer + " 초 뒤에 이동 예정";
            yield return CoroutineCache.waitForSeconds(minusTime);
            timer -= minusTime;
        }
        readyToMove = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
             portalText.text = " G키를 눌러 이동";
            inTrigger = true; 
           
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player")&&readyToMove)
        {
            StartCoroutine(SceneController.Instance.AsyncLoad(2));
         
            readyToMove = false;
            ResetText(); 
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            ResetText(); 
        }
    }
    private void ResetText()
    {
        portalText.text = " ";
    }
}
