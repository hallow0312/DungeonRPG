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
public abstract class Monster : MonoBehaviour,ISubject
{
    public MonsterData monsterdata;
    private MonsterHpManager monsterhp;
    private MonsterController monsterController;
    private readonly List<IObserver> observers=new List<IObserver>();
    public abstract void InitSetting();
    public virtual void Start()
    { 
        InitSetting();
        monsterController=GetComponent<MonsterController>();
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
        if(monsterController!=null)
        {
            monsterController.Die();
        }
        Destroy(DestroyCollider);
        GiveExp();
        NotifyObserver();
        Destroy(gameObject, 1.0f);
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
    public void RegisterObserver(IObserver observer)
    {
        this.observers.Add(observer);
    }
    public void RemoveObserver(IObserver observer)
    {
        this.observers.Remove(observer);
    }
    public void NotifyObserver()
    {
        foreach(var observer in observers)
        {
            observer.UpdateObserver();
        }
    }

}
