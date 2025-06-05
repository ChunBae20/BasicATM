using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    //메인 메뉴 오브젝트
    public GameObject UserInfo;
    public GameObject ButtonTwoSlice;

    //입금 오브 젝트
    public GameObject DepositFiveSlice;

    //출금 오브젝트
    public GameObject WithdrawFiveSlice;

    //잔액부족 오브젝트
    public GameObject NoHaveMoneyMenuUI;

    //입금 메뉴 보이기 버튼
    public void ThisButtonDisplayDepositMenu()
    {
        UserInfo.SetActive(true);
        ButtonTwoSlice.SetActive(false);
        DepositFiveSlice.SetActive(true);
        WithdrawFiveSlice.SetActive(false);
    }

    //출금 메뉴 보이기 버튼
    public void ThisButtonDisplayWithdrawMenu()
    {
        UserInfo.SetActive(true);
        ButtonTwoSlice.SetActive(false);
        DepositFiveSlice.SetActive(false);
        WithdrawFiveSlice.SetActive(true);
    }

    
    //뒤로가기 버튼
    public void ThisButtonCancelMenu()
    {
        UserInfo.SetActive(true);
        ButtonTwoSlice.SetActive(true);
        DepositFiveSlice.SetActive(false);
        WithdrawFiveSlice.SetActive(false);
    }

    /*
    public void NoHaveMoneyMenu()
    {
        NoHaveMoneyMenuUI.SetActive(true);
    }
    */
    public void NoHaveMoneyMenuAccept()
    {
        NoHaveMoneyMenuUI.SetActive(false);
    }
}
