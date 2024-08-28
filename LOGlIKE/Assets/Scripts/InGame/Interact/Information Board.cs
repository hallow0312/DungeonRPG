using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Experimental.GlobalIllumination;

public class InformationBoard : MonoBehaviour,IInteractable
{
    [SerializeField] TMP_Text tMP_Text;
    [SerializeField] bool isDialogue;
    [SerializeField] string[] dialogue;
    [SerializeField] int count = 0;

    private void Start()
    {
        isDialogue = false;
        tMP_Text.text = " ";
    }

    private void Update()
    {
        if (isDialogue)
        {
            Dialogue();

        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
         
            Interact();
        }
       
    }
    public void Interact()
    {
       
        isDialogue = true;
        count = 0;
        tMP_Text.text = "G키를 누르면 상호작용";
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isDialogue = false;
            tMP_Text.text = " ";
            count = 0;
        }
    }
    public void Dialogue()
    {
       if(!isDialogue)
        {
            return;
        }

        if (count < dialogue.Length)
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                tMP_Text.text = dialogue[count];
                count++;
                
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                isDialogue = false;
                tMP_Text.text = " ";
            }
        }
    }
}

   

