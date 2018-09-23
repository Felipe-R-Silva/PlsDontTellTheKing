using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItems : MonoBehaviour {
    //cash P for player
    int moneyP;

    //materials


    public PlayerItems(int money) {
        moneyP= money;
        
    }
    //Add pick Up
   
    public void Addmoney(int n)
    {
        moneyP = moneyP + n;
    }
    //Remove Pick Up
    public void Removemoney(int n)
    {
        moneyP = moneyP - n;
    }


    //gets
    public int Getmoney()
    {
        return moneyP;
    }
    //seters
    public void Setmoney(int newValue)
    {
        //MonoBehaviour.print(newValue+" old "+ moneyP);
        moneyP= newValue;
    }

}
