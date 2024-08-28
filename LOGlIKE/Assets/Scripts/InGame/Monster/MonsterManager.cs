using System.Collections;
using System.Collections.Generic;
using UnityEditor.Compilation;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
public struct MonsterData
{
    public float HP;
    public float attackDamage;
    public float Exp;

}
public abstract class Monster : MonoBehaviour
{
    public MonsterData monsterdata;
    private MonsterHpManager monsterhp;
   
    public abstract void InitSetting();
    public virtual void Start()
    { 
        InitSetting();
        
        monsterhp=GetComponent<MonsterHpManager>();
      
        if(monsterhp != null)
        {
          monsterhp.SetHP(monsterdata.HP);
          monsterhp.InitialHpBar(); 
        }
       
    }
    public virtual void GiveExp()
    {
        PlayerManager.Instance.GetEXP(monsterdata.Exp);
    }

    public virtual void Die()
    {
        var DestroyCollider = this.GetComponent<Collider2D>();
        Destroy(DestroyCollider);
        GiveExp();

        Destroy(gameObject, 0.5f);
    }
  
    public virtual void Hurt(float damage)
    { 
        monsterhp.Damaged(damage);
    }


    private  void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<HPManager>().Damaged(monsterdata.attackDamage);
        }
    }

}
