using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MonsterCount : MonoBehaviour,IObserver
{
    
    [SerializeField] int RemainMonster;
    [SerializeField] int MaxMonster;
    [SerializeField] TMP_Text CountText;
    [SerializeField] GameObject bossSpawner;
    public void UpdateObserver()
    {
        RemainMonster--;
        CountText.text = RemainMonster + "/" + MaxMonster;
       
        if(RemainMonster==0)
        {
            bossSpawner.SetActive(true);
        }
    }
    public void AddMonster(Monster monster)
    {
        RemainMonster++;
        MaxMonster++;
        monster.RegisterObserver(this);
     
    }
    private void Start()
    {
      
        RemainMonster = 0; MaxMonster = 0;
        Monster[]monsters=FindObjectsOfType<Monster>();
        foreach(var monster in monsters)
        {
            AddMonster(monster);
        }
        CountText.text = RemainMonster + "/" + MaxMonster;
        bossSpawner.SetActive(false);
    }

}
