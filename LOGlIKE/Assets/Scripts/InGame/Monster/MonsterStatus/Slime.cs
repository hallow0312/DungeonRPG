using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Monster
{
    private MonsterController monsterController;
   
    public override void InitSetting()
    {
        monsterdata.attackDamage = 5.0f;
        monsterdata.Exp = 15.0f;
        monsterdata.HP = 100.0f;
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
