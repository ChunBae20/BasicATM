using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RemitManager : MonoBehaviour
{
    public TMP_InputField whoTakeMyMoney;
    public TMP_InputField sendAmount;

    public GameObject remitErrorPopup;

    public TextMeshProUGUI remitErrorMessageReason;
    //송금 대상/금액을입력안했을시 => 입력 정보를 확인하세요
    //잔액이 부족할시 => 잔액이부족합니다.
    //송금대상이 없는 사람이면 => 대상이 존재하지 않습니다.

    void SendMoney()
    {

    }
}
