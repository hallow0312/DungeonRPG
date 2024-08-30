using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DungeonUI: MonoBehaviour
{
    [SerializeField] TMP_Text monsterCount;
    [SerializeField] public int maxMonster;
    private GameObject exitCanvas;
    private int remainMonster;
    private void Start()
    {
        remainMonster = maxMonster;
        monsterCount.text = remainMonster + "/" + maxMonster;
    }
    public void ExitCanavas()
    {
        exitCanvas = Instantiate(Resources.Load<GameObject>("ExitCanvas"));
    }

    public void Counting()
    {
        remainMonster--;
        monsterCount.text = remainMonster + "/" + maxMonster;
    }
}
