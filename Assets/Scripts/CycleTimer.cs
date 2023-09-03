using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CycleTimer : MonoBehaviour
{
    public float Timer;

    public TMP_Text TextHour;

    public TMP_Text TextAM;

    public int HourGame;

    // Start is called before the first frame update
    void Start()
    {
        HourGame = 10;
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;

        if(Timer > 86)
        {
            HourGame = 11;
            TextHour.text = " " + HourGame.ToString();
            TextAM.text = "PM";
        }

        if (Timer > 172)
        {
            HourGame = 12;
            TextHour.text = " " + HourGame.ToString();
            TextAM.text = "AM";
        }

        if (Timer > 258)
        {
            HourGame = 1;
            TextHour.text = " " + HourGame.ToString();
            TextAM.text = "AM";
        }

        if (Timer > 344)
        {
            HourGame = 2;
            TextHour.text = " " + HourGame.ToString();
            TextAM.text = "AM";
        }

        if (Timer > 430)
        {
            HourGame = 3;
            TextHour.text = " " + HourGame.ToString();
            TextAM.text = "AM";
        }

        if (Timer > 516)
        {
            HourGame = 4;
            TextHour.text = " " + HourGame.ToString();
            TextAM.text = "AM";
        }

        if (Timer > 602)
        {
            HourGame = 5;
            TextHour.text = " " + HourGame.ToString();
            TextAM.text = "AM";
        }

        if (Timer > 688)
        {
            HourGame = 6;
            TextHour.text = " " + HourGame.ToString();
            TextAM.text = "AM";
        }
    }
}
