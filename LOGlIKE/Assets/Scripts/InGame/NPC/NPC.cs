using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public abstract class NPC : MonoBehaviour
{
    [SerializeField] string[] chat;               // NPC ��ȭ �迭
    [SerializeField] TMP_Text dialogue;           // ��ȭ �ؽ�Ʈ
    [SerializeField] Canvas chattingboard;        // ä�� ���� ĵ����
    [SerializeField] GameObject buttonObject;     // ��ư ������Ʈ
    [SerializeField] float typingSpeed = 0.1f;    // Ÿ���� �ӵ�
    NPCController npcController;

    [SerializeField] RawImage npcImage;           // NPC �̹���
    [SerializeField] Sprite sprite;               // �̹��� ��������Ʈ
    private int currentChatIndex;                 // ���� ��ȭ �ε���
    private Coroutine coroutine;                  // Ÿ���� �ڷ�ƾ
    private bool istyping;                        // ��ȭ Ÿ���� �� ����
    private bool isChatting;                      // ��ȭ ���� ����

    private void Start()
    {
        chattingboard.gameObject.SetActive(false);  // ���� �� ��ȭ ���� ����
        npcController = GetComponent<NPCController>();
    }

    public virtual void StartChat()
    {
        if (isChatting) return;  // �̹� ��ȭ ���̸� �� ��ȭ�� �������� ����

        npcImage.texture = sprite.texture;
        currentChatIndex = 0;                           // ��ȭ ���� �� �ε��� �ʱ�ȭ
        chattingboard.gameObject.SetActive(true);       // ��ȭ ���� Ȱ��ȭ
        buttonObject.SetActive(false);                  // ��ư ��Ȱ��ȭ
        isChatting = true;
      
        ChatNPC();                                      // ù ��ȭ ȣ��
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G) && isChatting && currentChatIndex < chat.Length)
        {
            if (istyping) // Ÿ���� ���� �� ��ŵ�� ���ϸ�
            {
                StopCoroutine(coroutine);             // Ÿ���� �ڷ�ƾ ����
                CompleteChat(chat[currentChatIndex]); // ��ȭ�� ��� �ϼ�
            }
            else
            {
                ChatNPC(); // Ÿ���� ���� �ƴϸ� ���� ��ȭ�� �̵�
            }
        }
    }

    public void ChatNPC()
    {
        if (currentChatIndex < chat.Length)
        {
            istyping = true;                           // Ÿ���� ������ ǥ��
            coroutine = StartCoroutine(NPCText(chat[currentChatIndex]));  // ��ȭ Ÿ���� ����
        }
        else
        {
            EndChat(); // ��� ��ȭ�� ������ ��
        }
    }

    IEnumerator NPCText(string context)
    {
        dialogue.text = ""; // ��ȭ �ʱ�ȭ
        foreach (char text in context.ToCharArray())
        {
            dialogue.text += text;  // �ϳ��� Ÿ����
            yield return new WaitForSeconds(typingSpeed);
        }

        istyping = false;  // Ÿ���� �Ϸ�
        currentChatIndex++; // ���� ��ȭ�� �̵�
    }

    public void CompleteChat(string context)
    {
        istyping = false;  // Ÿ���� ���� �ƴ�
        dialogue.text = context; // ��ȭ ��� �Ϸ�

        // ������ ��ȭ��� ��ȭ�� ����
        if (currentChatIndex >= chat.Length - 1)
        {
            EndChat();
        }
        else
        {
            currentChatIndex++;  // �ε��� ����
        }
    }

    public void EndChat()
    {
        buttonObject.SetActive(true); // ��ư Ȱ��ȭ
        isChatting = false;           // ��ȭ ����
    }

    public virtual void Yes() { } // ��ư

    public void NO() // ��ư
    {
        chattingboard.gameObject.SetActive(false);  // ��ȭ ���� ����
        npcController.EndNPC();                     // NPC ���� ó��
        isChatting = false;                         // ��ȭ ���� �÷���
    }

    public virtual void EndInteract()
    {
        npcController.EndNPC();
        isChatting = false;
    }
}
