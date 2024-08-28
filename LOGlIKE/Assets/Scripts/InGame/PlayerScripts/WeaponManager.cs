using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WeaponManager : MonoBehaviour
{
    [SerializeField] float WeaponDamage;
    [SerializeField] bool isAttack;
    [SerializeField] float totalDamage;
    [SerializeField] PlayerAttack playerAttack;
    public bool AttackState
    {
        get { return isAttack; }
        set { isAttack = value; }
    }

    private void Start()
    {
        AttackState = false;
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CalculateTotalDamage();
        if (collision.gameObject.CompareTag("Monster")&&isAttack)
        {
          
            collision.gameObject.GetComponent<Monster>().Hurt(totalDamage);
        }
    }
    void CalculateTotalDamage()
    {
        totalDamage = WeaponDamage * 2 + playerAttack.PlayerPower * 1.2f;
    }
}
