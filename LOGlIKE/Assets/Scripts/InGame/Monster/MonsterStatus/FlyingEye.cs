using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEye :MovingMonster
{
    public override void InitSetting()
    {
        monsterdata.HP = 1500.0f;
        monsterdata.attackDamage = 40.0f;
        monsterdata.Exp = 450.0f;
    }
}
