using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace pseudoinc
{
    // 교회 클래스 생성
    static class Church
    {
        // 변수들 private으로 선언
        private static int money = 0;           // 자금
        private static ArrayList followers = new ArrayList();// 신도들의 배열 리스트
        private static int num_followers = 0;   // 총 신도 수
        private static int faith = 0;           // 신도들의 충성도 합
        private static int favor = 45;          // 비신도들에 대한 호감도

        // 변수들에 대한 접근 메서드를 public으로 선언
        public static int Get_money()          { return money; }
        public static void Set_money(int money_){ money = money_; }
        public static void Add_money(int money_){ money += money_; }
        
        public static int Get_favor()          { return favor; }
        public static void Set_favor(int favor_){ favor = favor_; }
        public static void Add_favor(int favor_){ favor += favor_; }
        
        public static int Get_num_followers() { return num_followers; }
        public static void Add_follower(Follower follower)
        {
            followers.Add(follower);
            num_followers++;
            Apply_faith();
            Calculate_offer();
        }
        
        public static int Get_faith()
        {
            return faith; }
        public static void Apply_faith()  // 신도들에게서 들어올 신앙 계산 및 적용
        {
            int cal_faith = 0;
            for (int i = 0; i < num_followers; i++){
                if (followers[i].GetType() != typeof(Follower)){
                    throw new Exception("followers에 Follower가 아닌 자료가 들어갔습니다.");
                }
                cal_faith += ((Follower)followers[i]).Get_faith();
            }
            faith = cal_faith;
        }  
        public static int Calculate_offer() // 신도들에게서 들어올 헌금(십일조) 계산
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
        } 
        
        public static void Increase_all_followers_faith(int faith) // 모든 신도들의 신앙심 증가
        {
            for (int i = 0; i < num_followers; i++)
            {
                if (followers[i].GetType() != typeof(Follower))
                {
                    throw new Exception("followers에 Follower가 아닌 자료가 들어갔습니다.");
                }
                ((Follower)followers[i]).Add_faith(faith);
            }
            Apply_faith();
        }
        public static void Increase_all_followers_offer(int offer) // 모든 신도들의 헌금량 증가
        {
            for (int i = 0; i < num_followers; i++)
            {
                if (followers[i].GetType() != typeof(Follower))
                {
                    throw new Exception("followers에 Follower가 아닌 자료가 들어갔습니다.");
                }
                ((Follower)followers[i]).Add_offer(offer);
            }
            Calculate_offer();
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
        private int income;

        public int Get_favor() { return favor; }
        public void Set_favor(int favor) { this.favor = favor; }
        public void Add_favor(int favor) { this.favor += favor; }
        public int Get_income() { return income; }
        public void Set_income(int income) { this.income = income; }

        public NonFollower(int favor, int income)
        {
            Set_favor(favor);
            Set_income(income);
        }
    }


    class Upgrade
    {
        private const int money_increse = 50;
        private const int follower_increse = 5;
        private const int faith_increse = 20;
        private const int favor_increse = 10;

        private void Upgrade_gospel(int money, int num_follower, int offer, int faith, int favor)
        {
            Church.Add_money(money);
            for(int i=0; i<num_follower; i++)
            {
                Church.Add_follower(new Follower());
            }
            Church.Increase_all_followers_offer(offer);
            Church.Increase_all_followers_faith(faith);
            Church.Add_favor(favor);
        }


    }
}
