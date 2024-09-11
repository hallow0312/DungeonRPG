using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bush : Monster
{
    public override void InitSetting()
    {
        monsterdata.attackDamage = 0f;
        monsterdata.Exp = 0f;
        monsterdata.HP = 100.0f;
    }

}
