using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SettingBoard : MonoBehaviour
{
    [SerializeField] Image soundBoard;


    public void Resume()
    {
        
        Destroy(gameObject);
        GameManager.Instance.IsOpen = false;
    }
    public void GoToLobby()
    {
  
        GameManager.Instance.IsOpen = false;
        Destroy(gameObject);

    }

    public void SetVolume()
    {
        soundBoard.gameObject.SetActive(true);
    }
}
