using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class LevelManager : MonoBehaviour
{
   [SerializeField] HPManager hpmanager;
   [SerializeField] PlayerAttack playerAttack;
   [SerializeField] EXPManager expManager;
   [SerializeField] TMP_Text levelText;

   [SerializeField] private int level;

    public int Level
    {
        get { return level; }
        set { level = value; }
    }
    private void Start()
    {
        Level = PlayerManager.Instance.Level;
        levelText.text = "LV " + Level;
    }
    public void LevelUp()
    {
        Level++;
        levelText.text = "LV " + level;
        PlayerManager.Instance.Level = Level;
        hpmanager.MaxHP += 5.0f;
        playerAttack.PlayerPower += 2.5f;
        
    }
}
