using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MovingMonster
{

   
    public override void InitSetting()
    {
        monsterdata.attackDamage = 5.0f;
        monsterdata.Exp = 15.0f;
        monsterdata.HP = 100.0f;
    }
  
}
