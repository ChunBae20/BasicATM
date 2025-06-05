using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class ButtonManager : MonoBehaviour
{
    public UserData userdata;

    private ulong one = 10_000;
    private ulong three = 30_000;
    private ulong five = 50_000;

    //잔액부족시 나올 UI
    public GameObject noHaveMoney;

    public TMP_InputField userInputField;

    void Start()
    {
        //기존에는 update에서 쓰니까 실시간으로 최신화가 된거구나.
        userdata = GameManager.Instance.userdata;
    }

    //입금 판정
    public bool CanDeposit(UserData data, ulong depositValue)
    {
        if (data.GetUserBasicCash() >= depositValue)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    
    //입금버튼
    #region 입금 버튼
    public void DepositOneButton()
    {
        if (CanDeposit(userdata, one))
        {
            GameManager.Instance.userdata.DepositButtonPreset(one);
            Debug.Log($"{one}만원짜리 눌림");
        }
        else
        {
            noHaveMoney.SetActive(true);
        }
    }
    public void DepositThreeButton()
    {
        if (CanDeposit(userdata, three))
        {
            GameManager.Instance.userdata.DepositButtonPreset(three);
            Debug.Log($"{three}만원짜리 눌림");
        }
        else
        {
            noHaveMoney.SetActive(true);
        }
    }
    public void DepositFiveButton()
    {
        if (CanDeposit(userdata, five))
        {
            GameManager.Instance.userdata.DepositButtonPreset(five);
            Debug.Log($"{five}만원짜리 눌림");
        }
        else
        {
            noHaveMoney.SetActive(true);
        }
    }

    public void DepositCutomButton()
    {
        string customSendMoney = userInputField.text;

        if(ulong.TryParse(customSendMoney,out ulong number))
        {
            if (CanDeposit(userdata, number))
            {
                GameManager.Instance.userdata.CustomDepositSend(number);
                Debug.Log($"{number}만원 입금");
            }
            else
            {
                noHaveMoney.SetActive(true);
            }
        }
    }

    #endregion

    //출금판정
    public bool CanWithdraw(UserData data, ulong depositValue)
    {
        if (data.GetUserBasicBalance() >= depositValue)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    //출금 버튼
    #region 출금버튼
    public void WithDrawOneButton()
    {
        if (CanWithdraw(userdata, one))
        {
            GameManager.Instance.userdata.WithdrawButtonpreset(one);
            Debug.Log($"{one}만원짜리 눌림");
        }
        else
        {
            noHaveMoney.SetActive(true);
        }
    }
    public void WithDrawThreeButton()
    {
        if (CanWithdraw(userdata, three))
        {
            GameManager.Instance.userdata.WithdrawButtonpreset(three);
            Debug.Log($"{three}만원짜리 눌림");
        }
        else
        {
            noHaveMoney.SetActive(true);
        }
    }
    public void WithDrawFiveButton()
    {
        if (CanWithdraw(userdata, five))
        {
            GameManager.Instance.userdata.WithdrawButtonpreset(five);
            Debug.Log($"{five}만원짜리 눌림");
        }
        else
        {
            noHaveMoney.SetActive(true);
        }
    }

    public void WithDrawCutomButton()
    {
        string customSendMoney = userInputField.text;

        if (ulong.TryParse(customSendMoney, out ulong number))
        {
            if (CanWithdraw(userdata, number))
            {
                GameManager.Instance.userdata.CustomWithdrawSend(number);
                Debug.Log($"{number}만원 입금");
            }
            else
            {
                noHaveMoney.SetActive(true);
            }
        }
    }

    #endregion

    //bool값을 넘기는 함수를 판정해야하는데
    //현재 현금>현재 통장잔액 / 트루면 *입금* 가능/ 현재 현금잔액 >= 선택한 입금 값
    //현재 현금<현재 통장잔액 / 트루면 *출금* 가능/ 현재 통장잔액 >= 선택한 출금 값

    //근데 데이터는 게임매니저에 있는데 게임매니저에서 해야하는거 아닌가?
    //아 아니네 이걸 여기서 하는게 아니라 버튼로직에서 해야하는거 아닌가?
    //현재 현금잔액 >= 선택한 입금 값  (입금가능)
    
    
    //현재 통장잔액 >= 선택한 출금 값  (출금가능)
}
