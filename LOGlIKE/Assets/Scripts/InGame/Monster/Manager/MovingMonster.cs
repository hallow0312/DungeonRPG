using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingMonster : Monster
{
    MonsterController controller;
    public override void Start()
    {
        base.Start();
        controller = GetComponent<MonsterController>();
    }
    public override void InitSetting()
    {
        
    }
    public override void Hurt(float damage)
    {
        controller.Hurt();
        base.Hurt(damage);
    }

}
