using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using pseudoinc;

public class UpgradeController : MonoBehaviour {

    public void Upgrade_level() // 교회 레벨 업(꽃게)
    {
        int currentLevel = Church.Get_level();
        switch(currentLevel)
        {
            case 0:
                if (Church.Get_money() >= 50)
                {
                    Church.LevelUp();
                    Church.Add_money(-50);
                }
                return;
            case 1:
                if (Church.Get_money() >= 150)
                {
                    Church.LevelUp();
                    Church.Add_money(-150);
                }
                return;
            case 2:
                if (Church.Get_money() >= 350)
                {
                    Church.LevelUp();
                    Church.Add_money(-350);
                }
                return;
            case 3:
                if (Church.Get_money() >= 750)
                {
                    Church.LevelUp();
                    Church.Add_money(-750);
                }
                return;
            case 4:
                if (Church.Get_money() >= 1500)
                {
                    Church.LevelUp();
                    Church.Add_money(-1500);
                }
                return;

        }
    }

    private void Upgrade_gospel(int money, int num_follower, int offer, int faith, int favor) // 교리 업그레이드(성서)
    {
        if(money + Church.Get_money()<0)
        {
            return;
        }
        Church.Add_money(money);
        for (int i = 0; i < num_follower; i++)
        {
            Church.Add_follower(new Follower(Random.Range(1, 11), Random.Range(40, 81)));
        }
        Church.Increase_all_followers_offer(offer);
        Church.Increase_all_followers_faith(faith);
        Church.Add_favor(favor);
    }

    public void UpgradeGospel(int i)
    {
        switch(i)
        {
            case 1:
                Upgrade_gospel(-750, 0, 0, 0, 3);
                return;
            case 2:
                Upgrade_gospel(0, 2, 0, 0, -3);
                return;
            case 3:
                Upgrade_gospel(0, 0, 0, 0, 0);
                return;
            case 4:
                Upgrade_gospel(500, 0, -1, 1, -2);
                return;
            case 5:
                Upgrade_gospel(750, 0, -1, 1, -3);
                return;
            case 6:
                Upgrade_gospel(-400, 3, 0, 1, 1);
                return;
            case 7:
                Upgrade_gospel(-500, 3, 0, 0, 1);
                return;
            case 8:
                Upgrade_gospel(-500, 0, 0, 0, 2);
                return;
            case 9:
                Upgrade_gospel(-150, 0, 0, 1, 0);
                return;
            case 10:
                Upgrade_gospel(0, 0, -1, 1, 1);
                return;
            case 11:
                Upgrade_gospel(-250, 0, 0, 2, -2);
                return;
            case 12:
                Upgrade_gospel(-250, 0, 0, 1, 1);
                return;
            case 13:
                Upgrade_gospel(-150, 0, 0, 1, 0);
                return;
            case 14:
                Upgrade_gospel(-400, 2, 0, 1, 0);
                return;
            case 15:
                Upgrade_gospel(0, 0, 0, 1, -1);
                return;
            case 16:
                Upgrade_gospel(0, 3, 0, 2, -2);
                return;
        }
    }
}
