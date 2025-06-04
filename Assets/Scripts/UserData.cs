using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UserData
{

    public UserData(string userName, int userCash, int userBalance)
    {
        Debug.Log("생성자 호출");

        //진짜 UserData클래스에 들어있는 변수들 = 매개변수
        //이번경우에는 이름이 같은 경우가 나옴 그리니 구분하기위해서this라고 쓰는것임
        this.userName = userName;
        this.userCash = userCash;
        this.userBalance = userBalance;
    }

    //후에 시간남으면 내가만들어둔 시간시스템 건져와서 cash 다 decimal로 선언하고 이자같은거 실시간적용이나 코인한번 구현해보자
    [SerializeField]
    private string userName = "나는 개발자"; // 유저 이름
    [SerializeField]
    private int userCash = 100_001; // 유저 현금
    [SerializeField]
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
    //이런 노가다 말고 그냥 Deposit(30000)일케하면 한번에 캐시에서 3만빼고 밸런스에 3만더하는 로직도 짜봐서 테스트해보자
    //튜플 진짜 야무지네
    public (int,int) DepositOne()
    {
        userCash -= 10_000;
        userBalance += 10_000;
        GameManager.Instance.Refresh(this);
        return (userCash, userBalance);
    }
    public (int, int) DepositThree()
    {
        //애초에
        userCash -= 30_000;
        userBalance += 30_000;
        GameManager.Instance.Refresh(this);
        return (userCash, userBalance);
    }
    public (int, int) DepositFive()
    {
        userCash -= 50_000;
        userBalance += 50_000;
        GameManager.Instance.Refresh(this);
        return (userCash, userBalance);

    }
    public (int, int) CustomSend(int number)
    {

        userCash -= number;
        userBalance += number;
        GameManager.Instance.Refresh(this);
        return (userCash, userBalance);
    }


    void GetUserCash()
    {

    }
    void GetUserBalance()
    {

    }
}
