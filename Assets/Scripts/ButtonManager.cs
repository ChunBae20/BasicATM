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

    //입금 입력 필드전용
    public TMP_InputField userDepositInputField;
    //출금 입력 필드전용
    public TMP_InputField userWithdrawInputField;


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

            ulong nowCash = userdata.GetUserBasicCash();
            ulong nowBalance = userdata.GetUserBasicBalance();

            GameManager.Instance.SaveUserData(); //저장
            Debug.Log($"[입금 버튼]{one}만원짜리 눌림,보유 현금:{nowCash},현재 잔고:{nowBalance}");
        }
        else
        {
            noHaveMoney.SetActive(true);
            Debug.Log($"[입금 버튼]잔액이 부족합니다 팝업실행.");

        }
    }
    public void DepositThreeButton()
    {
        if (CanDeposit(userdata, three))
        {
            GameManager.Instance.userdata.DepositButtonPreset(three);

            ulong nowCash = userdata.GetUserBasicCash();
            ulong nowBalance = userdata.GetUserBasicBalance();

            GameManager.Instance.SaveUserData();//저장
            Debug.Log($"[입금 버튼]{three}만원짜리 눌림,보유 현금:{nowCash},현재 잔고:{nowBalance}");
        }
        else
        {
            noHaveMoney.SetActive(true);
            Debug.Log($"[입금 버튼]잔액이 부족합니다 팝업실행.");

        }
    }
    public void DepositFiveButton()
    {

        if (CanDeposit(userdata, five))
        {
            GameManager.Instance.userdata.DepositButtonPreset(five);

            ulong nowCash = userdata.GetUserBasicCash();
            ulong nowBalance = userdata.GetUserBasicBalance();

            GameManager.Instance.SaveUserData();//저장
            Debug.Log($"[입금 버튼]{five}만원짜리 눌림,보유 현금:{nowCash},현재 잔고:{nowBalance}");
        }
        else
        {
            noHaveMoney.SetActive(true);
            Debug.Log($"[입금 버튼]잔액이 부족합니다 팝업실행.");

        }
    }

    public void DepositCutomButton()
    {

        string customSendMoney = userDepositInputField.text;

        if(ulong.TryParse(customSendMoney,out ulong number))
        {
            if (CanDeposit(userdata, number))
            {
                GameManager.Instance.userdata.CustomDepositSend(number);

                ulong nowCash = userdata.GetUserBasicCash();
                ulong nowBalance = userdata.GetUserBasicBalance();

                GameManager.Instance.SaveUserData();//저장
                Debug.Log($"[직접 입력 입금]{number}만원 입금,보유 현금:{nowCash},현재 잔고:{nowBalance}");
            }
            else
            {
                noHaveMoney.SetActive(true);
                Debug.Log($"[직접 입력 입금]잔액이 부족합니다 팝업실행.");

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

    //입금판정
    //출금 버튼
    #region 출금버튼
    public void WithDrawOneButton()
    {


        if (CanWithdraw(userdata, one))
        {
            GameManager.Instance.userdata.WithdrawButtonpreset(one);

            ulong nowCash = userdata.GetUserBasicCash();
            ulong nowBalance = userdata.GetUserBasicBalance();

            GameManager.Instance.SaveUserData();//저장

            Debug.Log($"[출금 버튼]{one}만원짜리 눌림,보유 현금:{nowCash},현재 잔고:{nowBalance}");
        }
        else
        {
            noHaveMoney.SetActive(true);
            Debug.Log($"[출금 버튼]잔액이 부족합니다 팝업실행.");

        }
    }
    public void WithDrawThreeButton()
    {

        if (CanWithdraw(userdata, three))
        {
            GameManager.Instance.userdata.WithdrawButtonpreset(three);

            ulong nowCash = userdata.GetUserBasicCash();
            ulong nowBalance = userdata.GetUserBasicBalance();

            GameManager.Instance.SaveUserData();//저장

            Debug.Log($"[출금 버튼]{three}만원짜리 눌림,보유 현금:{nowCash},현재 잔고:{nowBalance}");
        }
        else
        {
            noHaveMoney.SetActive(true);
            Debug.Log($"[출금 버튼]잔액이 부족합니다 팝업실행.");

        }
    }
    public void WithDrawFiveButton()
    {

        if (CanWithdraw(userdata, five))
        {
            GameManager.Instance.userdata.WithdrawButtonpreset(five);

            ulong nowCash = userdata.GetUserBasicCash();
            ulong nowBalance = userdata.GetUserBasicBalance();
            
            GameManager.Instance.SaveUserData();//저장

            Debug.Log($"[출금 버튼]{five}만원짜리 눌림,보유 현금:{nowCash},현재 잔고:{nowBalance}");
        }
        else
        {
            noHaveMoney.SetActive(true);
            Debug.Log($"[출금 버튼]잔액이 부족합니다 팝업실행.");

        }
    }

    public void WithDrawCutomButton()
    {

        string customSendMoney = userWithdrawInputField.text;

        if (ulong.TryParse(customSendMoney, out ulong number))
        {
            if (CanWithdraw(userdata, number))
            {
                GameManager.Instance.userdata.CustomWithdrawSend(number);

                ulong nowCash = userdata.GetUserBasicCash();
                ulong nowBalance = userdata.GetUserBasicBalance();

                GameManager.Instance.SaveUserData();//저장

                Debug.Log($"[직접 입력 출금]{number}만원 입금,보유 현금:{nowCash},현재 잔고:{nowBalance}");
            }
            else
            {
                noHaveMoney.SetActive(true);
                Debug.Log($"[직접 입력 출금]잔액이 부족합니다 팝업실행.");

            }
        }
    }


    public void DeleteAllDataAndRefresh()
    {
        /*
        //이렇게만 하면 게임다시켜야 적용되니 리프레시도한번 시원하게
        PlayerPrefs.DeleteAll();
        //GameManager.Instance.SaveUserData();
        GameManager.Instance.LoadUserData();
        GameManager.Instance.Refresh(GameManager.Instance.userdata);
        PlayerPrefs.Save();
        Debug.Log("세상의 모든 정보를 리셋하고 초기값으로 되돌립니다.");
        */

        //리셋시키기
        PlayerPrefs.DeleteAll();
        GameManager.Instance.userdata.Set(GameManager.Instance.userdata.GetUserName(), 50001, 100_001);
        //ui반영최신화
        GameManager.Instance.Refresh(GameManager.Instance.userdata);
        // ui최신화까지 완료하고 저장
        GameManager.Instance.SaveUserData();

        Debug.Log("세상의 모든 정보를 리셋하고 초기값으로 되돌립니다.");
    }
    #endregion


}
