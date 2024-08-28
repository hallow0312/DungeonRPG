using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class SceneController : SingleTon<SceneController>
{

    [SerializeField] Image loadImage;
    [SerializeField] Image SceneImage;
    [SerializeField] Slider slider;
    [SerializeField] TMP_Text SceneText;
    [SerializeField] string[] text;
    
   
    public IEnumerator FadeIn()
    {
        
        loadImage.gameObject.SetActive(true);
        Color color = loadImage.color;
        color.a = 1;
        while (color.a >= 0.0f)
        {
            color.a -= Time.deltaTime;
            loadImage.color = color;
            loadImage.gameObject.SetActive(false);
            yield return null;
        }

    }
   
    public IEnumerator SliderScreen()
    {   
        SceneImage.gameObject.SetActive(true);
        slider.value = 0;
        SceneText.text = text[Random.Range(0, text.Length)];
        
        while(slider.value<1.0f)
        {
            yield return CoroutineCache.waitForSeconds(1.0f);
            slider.value += 0.2f;
        }
        yield return null;
    }


    public IEnumerator AsyncLoad(int index)
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(index);
        
        loadImage.gameObject.SetActive(true);

        asyncOperation.allowSceneActivation = false;

        Color color = loadImage.color;
        color.a = 0;
        while (!asyncOperation.isDone)
        {
            color.a += Time.deltaTime;
            loadImage.color = color;
            if (asyncOperation.progress >= 0.9f)
            {
                color.a = Mathf.Lerp(color.a, 1f, Time.deltaTime);
                loadImage.color = color;
                if (color.a >= 1.0f)
                {
                    yield return StartCoroutine(SliderScreen());
                    asyncOperation.allowSceneActivation = true;
                 
                    yield break;
                }
            }
                   
            yield return null;
        }
        
        // bool allowSceneActivation : 장면이 준비되는 즉시 장면을 활성화 시킬 것 인지 허용 여부 판단 함수 

        //bool isDone :  해당 동작이 준비 되었는지 확인하는 함수
        //
        //float progress 작업의 진행 정도를 0과 1사이의 값으로 확인하는 함수 

    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
     void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        SceneImage.gameObject.SetActive(false);
        StartCoroutine(FadeIn());
      
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
 