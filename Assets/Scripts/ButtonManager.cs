using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class ButtonManager : MonoBehaviour
{
    public UserData userdata;

    public TMP_InputField userInputField;


    public void DepositOneButton()
    {
        GameManager.Instance.userdata.DepositOne();
        Debug.Log("1만원짜리 눌림");

    }
    public void DepositThreeButton()
    {
        GameManager.Instance.userdata.DepositThree();
        Debug.Log("3만원짜리 눌림");

    }
    public void DepositFiveButton()
    {
        GameManager.Instance.userdata.DepositFive();
        Debug.Log("5만원짜리 눌림"+userdata.GetUserBasicBalance());
    }

    public void DepositCutomButton()
    {
        string customSendMoney = userInputField.text;

        if(int.TryParse(customSendMoney,out int number))
        {
            Debug.Log(number);
            GameManager.Instance.userdata.CustomSend(number);
        }
    }

    
}
