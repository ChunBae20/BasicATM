using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserData : MonoBehaviour
{
    


    //후에 시간남으면 내가만들어둔 시간시스템 건져와서 cash 다 decimal로 선언하고 이자같은거 실시간적용이나 코인한번 구현해보자

    private string userName = "나는 개발자"; // 유저 이름
    private int userCash = 100_001; // 유저 현금
    private int userBalance = 50_001; // 유저 통장 잔액

    public string GetUserName()
    {
        return userName;
    }
    public int GetUserBasicCash()
    {
        return userCash;
    }

    public int GetUserBasicBalance()
    {
        return userBalance;
    }

    //출금 무조건 -
    void WithDraw()
    {

    }

    //입금 
    //case1 현금을 내 통장으로 입금했을때 + 
    //case2 현금을 다른 사람의 통장으로 입금했을때 -
    void Deposit()
    {

    }

    

    void GetUserCash()
    {

    }
    void GetUserBalance()
    {

    }
}
