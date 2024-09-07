using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class MonsterHpManager : MonoBehaviour
{
    [SerializeField] protected float Max_hp;
    [SerializeField] protected float current_hp;


    protected Monster monster;
   
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

    public abstract void InitialHpBar();

    
    public virtual void Update_Bar()
    {
        if (Max_hp <= 0)
        {
            Debug.Log("Error");
            return;
        }
      
    }

    public virtual void Damaged(float damage)
    {
        current_hp -= damage;
        Update_Bar();
        
    }
   

}

