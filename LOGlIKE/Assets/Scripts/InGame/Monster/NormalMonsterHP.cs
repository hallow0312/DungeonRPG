using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NormalMonsterHP : MonsterHpManager
{
    [SerializeField] Image hpBar;

    public override void InitialHpBar()
    {
      hpBar.transform.localScale= Vector3.one;
    }
    public override void Update_Bar()
    {
        base.Update_Bar();
        hpBar.transform.localScale = new Vector3(current_hp / Max_hp / 1, 1);
    }
    public override void Damaged(float damage)
    {
        base.Damaged(damage);
        if(current_hp <0)
        {
            monster.Die();
           
        }
    }
}
