using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FatMan : NPC
{
    GameObject storeBoard;
   
    public override void Yes()
    {
        storeBoard = Instantiate(Resources.Load<GameObject>("EnhanceBoard"));
    }
  
    public override void EndInteract()
    {
        base.EndInteract();
        Destroy(storeBoard);
    }


}
