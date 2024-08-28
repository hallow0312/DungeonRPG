using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EXPManager : MonoBehaviour
{
    [SerializeField] GameObject experienceBar;
    [SerializeField] float currentExp;
    [SerializeField] float maxExp;

    private LevelManager levelManager;
    private void Start()
    {
        currentExp = PlayerManager.Instance.Exp;
        maxExp = PlayerManager.Instance.MaxExp;
        experienceBar.transform.localScale = new Vector3(currentExp / maxExp, 1, 1);
        levelManager=GetComponent<LevelManager>();
    }

    private void Update()
    {
        UpdateExp();
    }

    public float GetExp
    {
        get { return currentExp; }
        set { currentExp = value;}
    }
    public float GetmaxExp
    {
        get { return maxExp; }
        set { maxExp = value;
            PlayerManager.Instance.MaxExp = maxExp;
        }
    }
    void UpdateExp()
    {
        while(currentExp>=maxExp)
        {
            Debug.Log("LevelUP");
            currentExp -= maxExp;
            levelManager.LevelUp();
        }
        experienceBar.transform.localScale = new Vector3(currentExp / maxExp, 1, 1);
    }
}
