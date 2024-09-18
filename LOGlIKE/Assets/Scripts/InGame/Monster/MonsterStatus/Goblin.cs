using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : MovingMonster
{
 
    public override void InitSetting()
    {
        monsterdata.attackDamage = 10.0f;
        monsterdata.Exp = 100f;
        monsterdata.HP = 400.0f;
    }
  
}
