using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultMonster : Monster // 움직이지 않는 허수아비 기준으로 default 잡음
{
    public override void InitSetting()
    {
        monsterdata.attackDamage = 1.0f;
        monsterdata.Exp = 5.0f;
        monsterdata.HP = 100.0f;
    }
   
}
