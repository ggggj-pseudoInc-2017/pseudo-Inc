using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using pseudoinc;

public class UpgradeController : MonoBehaviour {

    public void Upgrade_level() // 교회 레벨 업(꽃게)
    {
        int current_level = Church.Get_level();
        if (Church.Get_money() >= 500 * current_level)
        {
            Church.Add_money(-500 * current_level);
            Church.LevelUp();
        }
    }

    private void Upgrade_gospel(int money, int num_follower, int offer, int faith, int favor) // 교리 업그레이드(성서)
    {
        Church.Add_money(money);
        for (int i = 0; i < num_follower; i++)
        {
            Church.Add_follower(new Follower(Random.Range(1, 11), Random.Range(40, 81)));
        }
        Church.Increase_all_followers_offer(offer);
        Church.Increase_all_followers_faith(faith);
        Church.Add_favor(favor);
    }

    public void Upgrade_gospel_1(){
        Upgrade_gospel(-750, 0, 0, 0, 3);
    }
    public void Upgrade_gospel_2(){
        Upgrade_gospel(0, 2, 0, 0, -3);
    }
    public void Upgrade_gospel_3(){
        Upgrade_gospel(0, 0, 0, 0, 0);
    }
    public void Upgrade_gospel_4(){
        Upgrade_gospel(500, 0, -1, 1, -2);
    }
    public void Upgrade_gospel_5(){
        Upgrade_gospel(7500, 0, -1, 1, -3);
    }
    public void Upgrade_gospel_6(){
        Upgrade_gospel(-400, 3, 0, 1, 1);
    }
    public void Upgrade_gospel_7(){
        Upgrade_gospel(-500, 3, 0, 0, 1);
    }
    public void Upgrade_gospel_8(){
        Upgrade_gospel(-500, 0, 0, 0, 2);
    }
    public void Upgrade_gospel_9(){
        Upgrade_gospel(-150, 0, 0, 1, 0);
    }
    public void Upgrade_gospel_10(){
        Upgrade_gospel(0, 0, -1, 1, 1);
    }
    public void Upgrade_gospel_11(){
        Upgrade_gospel(-250, 0, 0, 2, -2);
    }
    public void Upgrade_gospel_12(){
        Upgrade_gospel(-250, 0, 0, 1, 1);
    }
    public void Upgrade_gospel_13(){
        Upgrade_gospel(-150, 0, 0, 1, 0);
    }
    public void Upgrade_gospel_14(){
        Upgrade_gospel(-400, 2, 0, 1, 0);
    }
    public void Upgrade_gospel_15(){
        Upgrade_gospel(0, 0, 0, 1, -1);
    }
    public void Upgrade_gospel_16(){
        Upgrade_gospel(0, 3, 0, 2, -2);
    }
}
