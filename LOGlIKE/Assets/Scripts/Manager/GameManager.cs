using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;


public class GameManager : SingleTon<GameManager>
{
    GameObject SettingBoard;
    bool isOpen;
    private void Start()
    {
        isOpen = false;
    }
    public bool IsOpen
    { 
        set { isOpen = value; }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            if (!isOpen)
            {
                isOpen = true;
                CreateBoard();
            }
            else if(isOpen)
            {
                isOpen = false;
                DestroyBoard();
            }
        }
        
       
    }
    public void CreateBoard()
    {
        SettingBoard = Instantiate(Resources.Load<GameObject>("SettingBoard"));

    }
    public  void DestroyBoard()
    {
       Destroy(SettingBoard);
    }

}
