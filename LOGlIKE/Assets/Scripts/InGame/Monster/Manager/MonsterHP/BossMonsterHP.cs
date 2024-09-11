using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class BossMonsterHP : MonsterHpManager
{
    [SerializeField] Slider hpBar;
    

    public override void InitialHpBar()
    {
        hpBar.maxValue = Max_hp;
        hpBar.minValue = 0;
        hpBar.value = Max_hp;
    }
    public override void Update_Bar()
    {
        base.Update_Bar();
        hpBar.value = current_hp;
    }
    public override void Damaged(float damage)
    {
        base.Damaged(damage);
        if (current_hp <= 0)
        {
            Destroy(hpBar);
            monster.Die(); 

        }
    }
}
