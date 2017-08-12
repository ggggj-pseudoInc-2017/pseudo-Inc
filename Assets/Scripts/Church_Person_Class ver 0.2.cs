using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace pseudoinc
{
    //테스트로 사용한 클래스. 완성되면 삭제 요망
    public static class Global
    {
        public static Church church_test;    //테스트용
        public static int favor_test; //테스트용
    }

    // 교회 클래스 생성
    class Church
    {
        // 변수들 private으로 선언
        private int money;          // 자금
        private ArrayList followers;// 신도들의 배열 리스트
        private int num_followers;  // 총 신도 수
        private int faith;          // 신도들의 충성도 합

        // 변수들에 대한 접근 메서드를 public으로 선언
        public int Get_money()          { return money; }
        public void Set_money(int money){ this.money = money; }
        public void Add_money(int money){ this.money += money; }
        public int Get_num_followers() { return num_followers; }

        public void Add_follower(Follower follower)
        {
            followers.Add(follower);
            num_followers++;
        }
        public int Get_faith() { return faith; }
        public void Apply_faith()
        {
            int cal_faith = 0;
            for (int i = 0; i < num_followers; i++){
                if (followers[i].GetType() != typeof(Follower)){
                    throw new Exception("followers에 Follower가 아닌 자료가 들어갔습니다.");
                }
                cal_faith += ((Follower)followers[i]).Get_faith();
            }
            faith = cal_faith;
        }   // 신도들에게서 들어올 신앙 계산 및 적용
        public int Calculate_offer()
        {
            int cal_money = 0;
            for (int i = 0; i < num_followers; i++)
            {
                if (followers[i].GetType() != typeof(Follower))
                {
                    throw new Exception("followers에 Follower가 아닌 자료가 들어갔습니다.");
                }
                cal_money += ((Follower)followers[i]).Get_offer();
            }
            return cal_money;
        } // 신도들에게서 들어올 돈 계산
        
        public void Increase_all_followers_faith(int faith)
        {
            for (int i = 0; i < num_followers; i++)
            {
                if (followers[i].GetType() != typeof(Follower))
                {
                    throw new Exception("followers에 Follower가 아닌 자료가 들어갔습니다.");
                }
                ((Follower)followers[i]).Add_faith(faith);
            }
        }
        public void Increase_all_followers_offer(int offer)
        {
            for (int i = 0; i < num_followers; i++)
            {
                if (followers[i].GetType() != typeof(Follower))
                {
                    throw new Exception("followers에 Follower가 아닌 자료가 들어갔습니다.");
                }
                ((Follower)followers[i]).Add_offer(offer);
            }
        }

        // 생성자 선언
        public Church()
        {
            Set_money(0);
            followers = new ArrayList();
            num_followers = 0;
        }
        public Church(int money)
        {
            Set_money(money);
            followers = new ArrayList();
            num_followers = 0;
        }
        public Church(int money, ArrayList followers, int num_followers)
        {
            Set_money(money);
            this.followers = followers;
            this.num_followers = num_followers;
        }
    }

    // 사람 클래스(비어있음)
    class Person
    {
        // 일단 비어있음
        public Person()
        {
        }
    }

    // 신도 클래스
    class Follower : Person
    {
        // 변수들 private으로 선언
        private int offer;	// 헌금 액수
        private int faith;  // 충성도

        public int Get_offer() { return offer; }
        public void Set_offer(int offer) { this.offer = offer; }
        public void Add_offer(int offer) { this.offer += offer; }
        public int Get_faith() { return faith; }
        public void Set_faith(int faith) { this.faith = faith; }
        public void Add_faith(int faith) { this.faith += faith; }

        public Follower()
        {
            Set_offer(0);
            Set_faith(0);
        }
        public Follower(int offer, int loyalty)
        {
            Set_offer(offer);
            Set_faith(loyalty);
        }
    }

    // 비 신도 클래스
    class NonFollower : Person
    {
        // 변수들 private으로 선언
        private int favor;	// 종교에 가지는 호감도

        public int Get_favor() { return favor; }
        public void Set_favor(int favor) { this.favor = favor; }
    }


    class Upgrade
    {
        private const int money_increse = 50;
        private const int follower_increse = 5;
        private const int faith_increse = 20;
        private const int favor_increse = 10;

        private void gospel(int money, int num_follower, int offer, int faith, int favor)
        {
            Global.church_test.Add_money(money);
            for(int i=0; i<num_follower; i++)
            {
                Global.church_test.Add_follower(new Follower());
            }
            Global.church_test.Increase_all_followers_offer(offer);
            Global.church_test.Increase_all_followers_faith(faith);
            Global.favor_test += favor;
        }


    }
}
