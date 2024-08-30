using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonExit : MonoBehaviour
{
   public void ExitDungeon()
    {
        StartCoroutine(SceneController.Instance.AsyncLoad(2));
       
    }
   
   public void CancelExit()
    {
        Destroy(gameObject);
    }
}
