using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultMonster : Monster // �������� �ʴ� ����ƺ� �������� default ����
{
    public override void InitSetting()
    {
        monsterdata.attackDamage = 1.0f;
        monsterdata.Exp = 5.0f;
        monsterdata.HP = 100.0f;
    }
   
}
