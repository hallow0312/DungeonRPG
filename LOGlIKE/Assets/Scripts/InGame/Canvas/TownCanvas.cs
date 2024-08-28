using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnvironmentName : MonoBehaviour
{
    [SerializeField] Image image;
    [SerializeField] Text text;
    [SerializeField] float FadeSpeed = 0.5f;
   
    public IEnumerator FadeIn()
    {
        text.gameObject.SetActive(true);
        image.gameObject.SetActive(true);
        Color color = image.color;
        color.a = 0f;
        while(color.a<1.0f)
        {
            color.a += Time.deltaTime*FadeSpeed;
            image.color = color;
            text.color = color;
            yield return null;
        }
        if(color.a>=1.0f)
        {
            StartCoroutine(FadeOut());
        }
  
    }
     
    public IEnumerator FadeOut()
    {
        Color color = image.color;
        color.a = 1.0f;
        while(color.a>0)
        {
            color.a-= Time.deltaTime*FadeSpeed;
            image.color = color;
            text.color = color;
            yield return null;
        }
        image.gameObject.SetActive(false);
        text.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(FadeIn());
        }
    }
}
