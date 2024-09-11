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

    private void OnTriggerStay2D(Collider2D collision)
    {
        CalculateTotalDamage();
        if (collision.gameObject.CompareTag("Monster")&&isAttack)
        {
            isAttack = false;
            collision.gameObject.GetComponent<Monster>().Hurt(totalDamage);
        }
    }
    void CalculateTotalDamage()
    {
        totalDamage = WeaponDamage *1.4f + playerAttack.PlayerPower * 1.2f;
    }
}
