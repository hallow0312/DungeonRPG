using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushRoom : MovingMonster
{

    public override void InitSetting()
    {
        monsterdata.attackDamage = 15.0f;
        monsterdata.Exp = 50.0f;
        monsterdata.HP = 250.0f;
    }
  

}
