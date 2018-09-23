using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class clock : MonoBehaviour {
    float timer;
    int days;
    public int hours;
    public int minuts;
    public float timeModulator;
    public Text clockdisplay;
    public Text dayplay;
    // Use this for initialization
    void Start () {
        timer = 0;

    }
	// Update is called once per frame
	void Update () {
        if (timer >= minuts+1)
        {
            if (minuts + 1 == 60)
            {
                minuts = 0;
                timer = 0;
                if (hours + 1 == 24)
                {
                    hours = 0;
                    days++;
                }
                else { hours++; }
                
            }else { minuts++; } 
        }
        //display
        if (hours < 10)
        {
            if (minuts < 10)
            { //0x:0x
                clockdisplay.text = "0" + hours.ToString() + ":" + "0" + minuts.ToString();

            }//0x:xx
            else { clockdisplay.text = "0" + hours.ToString() + ":" + minuts.ToString(); }
        }else
        {
            if (minuts < 10)
            {//xx:0x
                clockdisplay.text =hours.ToString() + ":" + "0" + minuts.ToString();

            }//xx:xx
            else { clockdisplay.text =hours.ToString() + ":" + minuts.ToString(); }
        }
        dayplay.text = days.ToString();
        //example timeModulator= imput
        //if imput = 0.5 : 1 second is 2 minuts // 1 minuto = 2 hora // 12 minutos = 1 dia
        //if imput = 1   : 1 second is 1 minut // 1 minuto = 1 hora // 24 minutos = 1 dia
        //if imput = 2   : 2 second is 1 minuts // 1 minuto = 0.5 hora // 48 minutos = 1 dia

        timer += Time.deltaTime/timeModulator;
    }

    public int get_hours()
    {
        return hours;
    }
    public int get_minuts()
    {
        return minuts;
    }
}
