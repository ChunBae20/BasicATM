using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
//using System.Numerics;
[System.Serializable]
public class UserData
{
    //얘는 문자열로 해야되나보네
    //BigInteger bigNumber = BigInteger.Parse("9999999999999999999999999999999999999999999999999999999999999");
    public UserData(string userName, ulong userCash, ulong userBalance)
    {
        Debug.Log("생성자 호출");

        //진짜 UserData클래스에 들어있는 변수들 = 매개변수
        //이번경우에는 이름이 같은 경우가 나옴 그리니 구분하기위해서this라고 쓰는것임
        this.userName = userName;
        this.userCash = userCash;
        this.userBalance = userBalance;
    }

    [SerializeField]
    private string userName = "나는 개발자"; // 유저 이름
    [SerializeField]
    private ulong userCash = 100_001; // 유저 현금
    [SerializeField]
    private ulong userBalance = 50_001; // 유저 통장 잔액

    public string GetUserName()
    {
        return userName;
    }
    public ulong GetUserBasicCash()
    {
        return userCash;
    }

    public ulong GetUserBasicBalance()
    {
        return userBalance;
    }

    //입금 
    //case1 현금을 내 통장으로 입금했을때 + 
    //case2 현금을 다른 사람의 통장으로 입금했을때 -
    //이런 노가다 말고 그냥 Deposit(30000)일케하면 한번에 캐시에서 3만빼고 밸런스에 3만더하는 로직도 짜봐서 테스트해보자
    //튜플 진짜 야무지네

    #region (입금)다른 스크립트에서 현재 cash 와 balance에 접근하는 함수

    public (ulong, ulong) DepositButtonPreset(ulong DepositValue)
    {
        userCash -= DepositValue;
        userBalance += DepositValue;
        GameManager.Instance.Refresh(this);
        return (userCash, userBalance);
    }

    public (ulong, ulong) CustomDepositSend(ulong number)
    {
        userCash -= number;
        userBalance += (ulong)number;
        GameManager.Instance.Refresh(this);
        return (userCash, userBalance);
    }

    //받는이가 접근할 함수 /userBalance를 더해준다.
    [Tooltip("받는이가 접근할 함수 /userBalance를 더해준다.")]
    public ulong SendGetMoney(ulong number)
    {
        userBalance += number;
        return userBalance;
    }
    //보낸이가 접근할 함수 /userBalance를 빼준다.
    [Tooltip("보낸이가 접근할 함수 /userBalance를 빼준다.")]
    public ulong SendLoseMoney(ulong number)
    {
        userBalance -= number;
        return userBalance;
    }

    #endregion

    #region (출금)다른 스크립트에서 현재 cash 와 balance에 접근하는 함수


    //근데 이렇게 하면 사실상 함수 하나만 있으면 되는거아님?어? 와 이거네 이거 와 뗴끄널러지아!
    //진짜 내 역대급최 고 아웃풋 최적화다 이야
    //이렇게 하면 접근할때 그냥 WithdrawButtonpreset(10_000)이렇게 하면 되는거잖아와 레전드
    //이미 사용 해놓고 왜 이걸 모르고있었지?
    public (ulong, ulong) WithdrawButtonpreset(ulong witdrawValue)
    {
        userCash += witdrawValue;
        userBalance -= witdrawValue;
        GameManager.Instance.Refresh(this);
        return (userCash, userBalance);
    }
    public (ulong, ulong) CustomWithdrawSend(ulong number)
    {
        userCash += number;
        userBalance -= (ulong)number;
        GameManager.Instance.Refresh(this);
        return (userCash, userBalance);
    }

    public void Set(string userName,ulong userCash,ulong userBalance)
    {
        this.userName = userName;
        this.userCash = userCash;
        this.userBalance = userBalance;
    }


    #region 기존 코드를 단 한줄로 줄일수 있다고?
    /*
    public (ulong, ulong) WithdrawOne()
    {
        //ulong withdrawValue = 10_000;
        userCash += 10_000;
        userBalance -= 10_000;
        GameManager.Instance.Refresh(this);
        return (userCash, userBalance);
    }
    public (ulong, ulong) WithdrawThree()
    {
        //ulong withdrawValue = 30_000;
        userCash += 30_000;
        userBalance -= 30_000;
        GameManager.Instance.Refresh(this);
        return (userCash, userBalance);
    }
    public (ulong, ulong) WithdrawFive()
    {
        //ulong withdrawValue = 50_000;
        userCash += 50_000;
        userBalance -= 50_000;
        GameManager.Instance.Refresh(this);
        return (userCash, userBalance);

    }
    public (ulong, ulong) WithdrawSend(ulong number)
    {
        //
        userCash += number;
        userBalance -= (ulong)number;
        GameManager.Instance.Refresh(this);
        return (userCash, userBalance);
    }
    */
    #endregion

    #endregion

    #region 입금가능과 출금 가능을 판정하는 함수.
    //bool값을 넘기는 함수를 판정해야하는데
    //현재 현금>현재 통장잔액 / 트루면 *입금* 가능/ 현재 현금잔액 >= 선택한 입금 값
    //현재 현금<현재 통장잔액 / 트루면 *출금* 가능/ 현재 통장잔액 >= 선택한 출금 값

    //근데 데이터는 게임매니저에 있는데 게임매니저에서 해야하는거 아닌가?
    //아 아니네 이걸 여기서 하는게 아니라 버튼로직에서 해야하는거 아닌가?
    //현재 현금잔액 >= 선택한 입금 값  (입금가능)
    
    //현재 통장잔액 >= 선택한 출금 값  (출금가능)
    #endregion
}
