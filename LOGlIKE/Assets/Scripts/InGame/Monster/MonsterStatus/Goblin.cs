using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : Monster
{
 
     private MonsterController monsterController;

    public override void InitSetting()
    {
        monsterdata.attackDamage = 10.0f;
        monsterdata.Exp = 100f;
        monsterdata.HP = 400.0f;
    }
    public override void Start()
    {
        base.Start();
        monsterController = GetComponent<MonsterController>();
    }
    public override void Hurt(float damage)
    {
        monsterController.Hurt();
        base.Hurt(damage);
    }
}
