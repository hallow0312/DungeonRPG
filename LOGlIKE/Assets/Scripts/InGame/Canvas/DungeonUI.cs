using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DungeonUI: MonoBehaviour
{
    public void ExitCanavas()
    {
        Instantiate(Resources.Load<GameObject>("ExitCanvas"));
    }

}
