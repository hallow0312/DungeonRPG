using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : SingleTon<PlayerManager>
{
   public float MaxHP
    {  get;  set; }
   public float CurrentHP
        { get; set; }
   public float PlayerPower
    { get;  set; }
   public int Level
    { get; set; }

     public float Exp
    { get; set; } 
    public float MaxExp
    { get; set; }
    [SerializeField] EXPManager expManager;

    protected override void Awake()
    {
        base.Awake();
        FirstStart();
    }
    
    void FirstStart()
    {
        MaxHP = 100.0f;
        CurrentHP = MaxHP;
        PlayerPower = 5.0f;
        Level = 1;
        Exp = 0;
        MaxExp = 100;
    }

    public void GetEXP(float exp)
    {
        Exp += exp;
        expManager.GetExp +=exp;
    }

 


}
