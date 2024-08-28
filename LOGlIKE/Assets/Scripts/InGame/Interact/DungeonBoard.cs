using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DungeonBoard : MonoBehaviour,IInteractable
{
    [SerializeField] bool OnInteract;
    [SerializeField] GameObject CheckBoard;
    private void Start()
    {
        OnInteract = false;
    }
   
   
    void Update()
    {
        if (OnInteract)
        {
            Interact();
        }

    }
    public void Interact()
    {
        
        if (Input.GetKeyDown(KeyCode.G))
        {
           Instantiate(Resources.Load<GameObject>("DungeonCanvas"));
            
        }
    }
    public void SelectDungeon()
    {
        CheckBoard.SetActive(true);
    }
    public void ExitBoard()
    {
        Destroy(gameObject);
     
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.gameObject.CompareTag("Player"))
        {
            OnInteract = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            OnInteract = false;
    
           
        }
    }

}
