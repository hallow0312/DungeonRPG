using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPManager : MonoBehaviour
{
    [SerializeField] private float maxHP;
    [SerializeField] private float currentHP;
    [SerializeField] private Slider slider;
    [SerializeField] float defaultHP=100.0f;
    [SerializeField] SpriteRenderer[] render;
    [SerializeField] AudioClip audioclip;
   
    public float MaxHP
    {
        get { return maxHP; }
        set
        {
            maxHP = value;
            if (defaultHP != 0)
            {
                slider.transform.localScale = new Vector3(maxHP / defaultHP, 1, 1);
            }
        }
    }

    public float CurrentHP
    {
        get { return currentHP; }
        set
        {
            currentHP = value;
            slider.value = currentHP/maxHP;
        }
    }


    private void Start()
    {
        maxHP = PlayerManager.Instance.MaxHP;
        currentHP = PlayerManager.Instance.CurrentHP;
   
    }

    public void CanDamaged()
    {
        for (int i = 0; i < render.Length; i++)
        {
            render[i].color = new Color(1, 1, 1, 1);
        }
        gameObject.tag = "Player";
        
    }
    public void  Heal(float amount) //포션힐
    {
        CurrentHP += amount;
        if(CurrentHP>maxHP)
        {
            CurrentHP = MaxHP;
        }
    }
    public void  StatueHeal() // statue 에서 상호작용하면 전체힐 시켜주기위함 
    {
        CurrentHP = MaxHP;
       
    }

    public void Damaged(float damage)
    {  
        gameObject.tag = "NoEnemy";
       
        for(int i=0; i < render.Length; i++)
        {
            render[i].color = new Color(0.8f, 0.8f, 0.8f, 0.6f);
        }
        CurrentHP -= damage;
        SoundManager.Instance.Sound(audioclip);
        if (currentHP < 0)
        {
            currentHP = 0; // HP는 0 이하로 내려가지 않도록
        }
        PlayerManager.Instance.CurrentHP = CurrentHP;
        Invoke(nameof(CanDamaged), 1.5f);
    }

   
}