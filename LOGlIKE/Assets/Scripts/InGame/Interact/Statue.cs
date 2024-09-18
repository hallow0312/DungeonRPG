using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Statue : MonoBehaviour,IInteractable
{
    [SerializeField] TMP_Text s_text;
    [SerializeField] AudioClip clip;
    bool isActive;
    bool isInteract;
    HPManager playerHpmanager;

    private void  Start()
    {
        isActive = false;
        isInteract = false;
        s_text.text = " ";
    }
    private void Update()
    {
        if (!isActive || isInteract || playerHpmanager == null) return;

        if (Input.GetKeyDown(KeyCode.G))
        {
            isInteract = true;
            Interact();
        }
    }
    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isActive = true;
            playerHpmanager=collision.gameObject.GetComponent<HPManager>();
            s_text.text = "G키를 눌러 상호작용";
        }
    }

   
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            s_text.text = " ";
            isActive = false;
            playerHpmanager = null;
        }
    }
   
    public void Interact()
    {
        s_text.text = "체력이 회복되었습니다.";
        SoundManager.Instance.Sound(clip);
        playerHpmanager.StatueHeal();
        isInteract = false;
        StartCoroutine(ResetText());
    }
    IEnumerator ResetText()
    {
        Color color = s_text.color;
        
        while(color.a>0)
        {
            color.a -= Time.deltaTime*0.5f;
            s_text.color = color;
            yield return null;
        }
        s_text.text = " ";
        s_text.color = Color.black;

    }
}
