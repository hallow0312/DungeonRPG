using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterHpManager : MonoBehaviour
{
    [SerializeField] private float Max_hp;
    [SerializeField] private float current_hp;
    [SerializeField] Image hpBar;

    private Monster monster;
   
    public void SetHP(float hp)
    {
        Max_hp = hp;
        current_hp = Max_hp;
        Update_Bar();
    }
    public void Start()
    {
        monster = GetComponent<Monster>();
        
      
    }

    public void InitialHpBar()
    {   if (hpBar == null) return;
        hpBar.transform.localScale = Vector3.one;
    }

    
    public void Update_Bar()
    {
        if (Max_hp <= 0)
        {
            Debug.Log("Error");
            return;
        }
        hpBar.transform.localScale = new Vector3(current_hp / Max_hp, 1, 1);
    }

    public void Damaged(float damage)
    {
        current_hp -= damage;
        Update_Bar();
        if (current_hp<0)
        {
            monster.Die();

        }
    }
   

}

