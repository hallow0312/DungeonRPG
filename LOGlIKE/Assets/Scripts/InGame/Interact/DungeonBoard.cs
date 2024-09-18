using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DungeonBoard : MonoBehaviour,IInteractable
{
    [SerializeField] bool OnInteract;
    [SerializeField] CheckBoard checkBoard;
    
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
    public void SelectForest()
    {
        
        checkBoard.gameObject.SetActive(true);
        checkBoard.SetDungeon(3);
    }
    public void SelectDesert()
    {
        checkBoard.gameObject.SetActive(true);
        checkBoard.SetDungeon(4);

    }
    public void SelectTemple()
    {
        checkBoard.gameObject.SetActive(true);
        checkBoard.SetDungeon(5);

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
