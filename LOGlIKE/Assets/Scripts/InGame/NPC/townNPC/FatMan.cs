using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FatMan : NPC
{
   [SerializeField] GameObject storeBoard;
   
    public override void Yes()
    {
        base.Yes();
        storeBoard.gameObject.SetActive(true);
    }
  
    public override void EndInteract()
    {
        base.EndInteract();
        Destroy(storeBoard);
    }


}
