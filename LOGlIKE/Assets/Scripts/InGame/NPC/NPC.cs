using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public  class NPC : MonoBehaviour,IInteractable
{
    [SerializeField] string[] chat;
    [SerializeField] TMP_Text dialogue;
    [SerializeField] Canvas chattingboard;
    [SerializeField] GameObject buttonObject;
    [SerializeField] float typingSpeed = 0.1f;


    private int  currentChatIndex ;
    private Coroutine coroutine;
    private void Start()
    {
        chattingboard.gameObject.SetActive(false);
        buttonObject.SetActive(false);
    }
    private bool istyping;
    public void StartChat() // 이제 npc 대화 시작  NPCcontroller로 부터 시작함 .
    {
        currentChatIndex = 0;
        chattingboard.gameObject.SetActive(true);
        Interact();

    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.G))
        {
            if(istyping)
            {
                StopCoroutine(coroutine);
                CompleteChat(chat[currentChatIndex]);
            }
            else
            {
                ChatNPC();
            }
        }
    }
    public void Interact()
    { 
    }
    public void ChatNPC()
    {

       
    }
    IEnumerator NPCText(string context)
    {
        istyping = true;
        dialogue.text = "";
        foreach (char text in context.ToCharArray())
        {
            dialogue.text += text;
            yield return CoroutineCache.waitForSeconds(typingSpeed);
        }
        currentChatIndex++;
        yield return CoroutineCache.waitForSeconds(1.0f);
        ChatNPC();
    }
    public void EndInteract()
    {
        buttonObject.SetActive(true);
    }
    public void CompleteChat(string context)
    {
        dialogue.text = context;
        istyping = false;
        currentChatIndex++;
    }
    public void Yes()
    {

    }
    public void NO()
    {

    }
}
