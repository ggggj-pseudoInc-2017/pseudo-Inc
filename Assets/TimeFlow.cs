using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using pseudoinc;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeFlow : MonoBehaviour {

    public Text timeText;
    public Text money;
    public Text moneyToSend;
    public Slider moneySlider;

    float time = 0f;

    int NumGetMoney = 0;
    int NumSendMoney = 0;
    int NumGetFollower = 0;

    void Start () {

        time = Church.GetTime();
        moneySlider.value = Church.Get_money();
        moneySlider.maxValue = Church.MoneyToSend;
        moneyToSend.text = Church.Get_money() + " / " + Church.MoneyToSend;
    }
	
	void Update ()
    {
        time += Time.deltaTime;
        Church.SetTIme(time);

        timeText.text = "시간 : " + Mathf.RoundToInt(time);

        if(time/30f > NumGetMoney+1)
        {
            Church.Add_money(Church.Calculate_offer());
            NumGetMoney++;
        }

        if(time/180f > NumSendMoney+1)
        {
            NumSendMoney++;
            switch(NumSendMoney)
            {
                case 1:
                    Church.Add_money(-50);
                    moneySlider.maxValue = 250;
                    SetMoneyToSend(250);
                    return;
                case 2:
                    Church.Add_money(-250);
                    moneySlider.maxValue = 500;
                    SetMoneyToSend(500);
                    return;
                case 3:
                    Church.Add_money(-500);
                    moneySlider.maxValue = 1000;
                    SetMoneyToSend(1000);
                    return;
                case 4:
                    Church.Add_money(-1000);
                    moneySlider.maxValue = 2000;
                    SetMoneyToSend(2000);
                    return;
                case 5:
                    Church.Add_money(-2000);
                    Win();
                    return;
                default:
                    return;

            }
        }

        moneySlider.value = Mathf.Min(Church.Get_money(), moneySlider.maxValue);
        moneyToSend.text = Church.Get_money() + " / " + moneySlider.maxValue;

        if (time/60 > NumGetFollower+1)
        {
            NumGetFollower++;
            for (int i = 0; i < ((Church.Get_faith() - 10) / 100 * (Church.Get_favor() + 20) / 100); i++)
            {
                if (Church.Get_num_followers() < Church.Get_maxFollower())
                {
                    Follower newFollower = new Follower(Random.Range(1, 11), Random.Range(40, 81));
                    Church.Add_follower(newFollower);
                    Debug.Log(Church.Get_num_followers());
                }
            }
        }
        

        if(Church.Get_money() < 0)
        {
            BadEnd();
        }
	}

    void SetMoneyToSend(int money)
    {
        moneyToSend.text = Church.Get_money() + " / " + money;
    }

    void Win()
    {
        SceneManager.LoadScene(4);
    }

    void BadEnd()
    {
        SceneManager.LoadScene(5);
    }
}
