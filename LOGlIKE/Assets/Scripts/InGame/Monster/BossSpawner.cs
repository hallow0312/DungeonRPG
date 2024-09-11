using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossSpawner : MonoBehaviour
{
    [SerializeField] GameObject bossMonster;
    [SerializeField] Image warningImage;
    
    private void OnEnable()
    {
        StartCoroutine(Warning());
        GameObject instanceBoss= Instantiate(bossMonster);
        instanceBoss.transform.position=gameObject.transform.position;
     
    }
   
    IEnumerator Warning()
    {  
        warningImage.gameObject.SetActive(true);
        Color color = warningImage.color;
        color.a = 0;
        while(color.a<1.0f)
        {
            color.a += Time.deltaTime;
            warningImage.color = color;
            yield return null;
        }
        
        warningImage.gameObject.SetActive(false);
      

    }
       
      
}
