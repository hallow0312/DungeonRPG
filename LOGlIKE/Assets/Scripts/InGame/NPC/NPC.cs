using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public abstract class NPC : MonoBehaviour
{
    [SerializeField] string[] chat;               // NPC 대화 배열
    [SerializeField] TMP_Text dialogue;           // 대화 텍스트
    [SerializeField] Canvas chattingboard;        // 채팅 보드 캔버스
    [SerializeField] GameObject buttonObject;     // 버튼 오브젝트
    [SerializeField] float typingSpeed = 0.1f;    // 타이핑 속도
    NPCController npcController;

    [SerializeField] RawImage npcImage;           // NPC 이미지
    [SerializeField] Sprite sprite;               // 이미지 스프라이트
    private int currentChatIndex;                 // 현재 대화 인덱스
    private Coroutine coroutine;                  // 타이핑 코루틴
    private bool istyping;                        // 대화 타이핑 중 여부
    private bool isChatting;                      // 대화 진행 여부

    private void Start()
    {
        chattingboard.gameObject.SetActive(false);  // 시작 시 대화 보드 숨김
        npcController = GetComponent<NPCController>();
    }

    public virtual void StartChat()
    {
        if (isChatting) return;  // 이미 대화 중이면 새 대화를 시작하지 않음

        npcImage.texture = sprite.texture;
        currentChatIndex = 0;                           // 대화 시작 시 인덱스 초기화
        chattingboard.gameObject.SetActive(true);       // 대화 보드 활성화
        buttonObject.SetActive(false);                  // 버튼 비활성화
        isChatting = true;
      
        ChatNPC();                                      // 첫 대화 호출
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G) && isChatting && currentChatIndex < chat.Length)
        {
            if (istyping) // 타이핑 중일 때 스킵을 원하면
            {
                StopCoroutine(coroutine);             // 타이핑 코루틴 중지
                CompleteChat(chat[currentChatIndex]); // 대화를 즉시 완성
            }
            else
            {
                ChatNPC(); // 타이핑 중이 아니면 다음 대화로 이동
            }
        }
    }

    public void ChatNPC()
    {
        if (currentChatIndex < chat.Length)
        {
            istyping = true;                           // 타이핑 중임을 표시
            coroutine = StartCoroutine(NPCText(chat[currentChatIndex]));  // 대화 타이핑 시작
        }
        else
        {
            EndChat(); // 모든 대화가 끝났을 때
        }
    }

    IEnumerator NPCText(string context)
    {
        dialogue.text = ""; // 대화 초기화
        foreach (char text in context.ToCharArray())
        {
            dialogue.text += text;  // 하나씩 타이핑
            yield return new WaitForSeconds(typingSpeed);
        }

        istyping = false;  // 타이핑 완료
        currentChatIndex++; // 다음 대화로 이동
    }

    public void CompleteChat(string context)
    {
        istyping = false;  // 타이핑 중이 아님
        dialogue.text = context; // 대화 즉시 완료

        // 마지막 대화라면 대화를 종료
        if (currentChatIndex >= chat.Length - 1)
        {
            EndChat();
        }
        else
        {
            currentChatIndex++;  // 인덱스 증가
        }
    }

    public void EndChat()
    {
        buttonObject.SetActive(true); // 버튼 활성화
        isChatting = false;           // 대화 종료
    }

    public virtual void Yes() { } // 버튼

    public void NO() // 버튼
    {
        chattingboard.gameObject.SetActive(false);  // 대화 보드 숨김
        npcController.EndNPC();                     // NPC 종료 처리
        isChatting = false;                         // 대화 종료 플래그
    }

    public virtual void EndInteract()
    {
        npcController.EndNPC();
        isChatting = false;
    }
}
