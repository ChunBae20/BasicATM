using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RemitManager : MonoBehaviour
{
    public UserData userData;

    public TMP_InputField whoTakeMyMoney; //보낼 유저아이디
    public TMP_InputField sendAmount; // 보낼 금액

    public GameObject remitErrorPopup;
    public GameObject remitUI;
    //public GameObject closeUI_Except_RemitUI;

    public GameObject backRemitUI1; //항상 트루여야함 이거없으면 버티컬레이아웃깨짐/밸런스 이름 ui임
    public GameObject backRemitUI2; //버튼 3slice

    public TextMeshProUGUI remitErrorMessageReason;
    //송금 대상/금액을입력안했을시 => 입력 정보를 확인하세요
    //잔액이 부족할시 => 잔액이부족합니다.
    //송금대상이 없는 사람이면 => 대상이 존재하지 않습니다.


    public bool CanSend(UserData data, ulong sendValue)
    {
        if (data.GetUserBasicCash() >= sendValue)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    //돈을 보낼시

    // 해당 아이디가 존재하는지 판단한다.
    // PlayerPrefs.SetString($"ID/{nowLoginID}/UserBalance", userData.GetUserBasicBalance().ToString()); 현재 이런식으로 돈을 저장했지.
    // haskey로 존재하는 아이디 인지 확인
    // 잔액이 부족한지 판단한다.
    // 돈을 잃는다.
    // 받는이는 돈을 얻는다.


    public void SendMoney()
    {
        string whoTake = whoTakeMyMoney.text;
        string sendMoney = sendAmount.text;

        //해당 아이디가 존재하는지를 판정
        if (PlayerPrefs.HasKey($"ID/{whoTake}"))
        {
            //현재 로그인 아이디
            string nowID = GameManager.Instance.nowLoginID;
            //ulong senderBalance = ulong.Parse(PlayerPrefs.GetString($"ID/{nowID}/UserBalance", "0"));
            //참일경우 잔액을 검사
            
            //현재 로그인 한 계정의 Balance와 보낼 금액을 검사
            //현재 로그인 한 계정의 Balance값 :   ulong nowBalance = PlayerPerfs.GetString($"ID/{nowID}UserBalance" 이렇게 하는게 아닌가? 이건가?
            ulong nowBalance = GameManager.Instance.userData.GetUserBasicBalance();
            if (ulong.TryParse(sendMoney, out ulong sendM))
            {
                //송금대상이 나일케이스
                if (whoTake == nowID)
                {
                    GameManager.Instance.userData.SendLoseMoney(sendM);
                    Debug.Log($"{sendM}원 만큼 잃습니다");
                    GameManager.Instance.userData.SendGetMoney(sendM);
                    Debug.Log($"{sendM}원 만큼 얻습니다");

                    GameManager.Instance.SaveUserData();//저장
                    GameManager.Instance.Refresh(GameManager.Instance.userData);
                    return;

                }
                if (nowBalance >= sendM)
                {
                    //보낸 사람 돈 제거
                    GameManager.Instance.userData.SendLoseMoney(sendM);
                    //받는 사람 돈 추가
                    ulong receiverBalance = ulong.Parse(PlayerPrefs.GetString($"ID/{whoTake}/UserBalance", "0"));
                    receiverBalance += sendM;

                    PlayerPrefs.SetString($"ID/{whoTake}/UserBalance", receiverBalance.ToString());
                    GameManager.Instance.SaveUserData();//저장
                    GameManager.Instance.Refresh(GameManager.Instance.userData);
                }
                else if (nowBalance < sendM)
                {
                    Debug.Log("잔액이 부족합니다");
                    remitErrorPopup.SetActive(true);
                    remitErrorMessageReason.text = "잔액이 부족합니다.";
                    Debug.Log($"nowCash:{nowBalance},sendM{sendM}");
                }
                
            }
            else
            {
                Debug.Log("보낼 금액이 잘못되었습니다.");
                remitErrorPopup.SetActive(true);
                remitErrorMessageReason.text = "보낼 금액이 잘못되었습니다.";
            }
            //if (nowCash>=sendMoney)
        }

        else
        {
            Debug.Log("존재하지 않는 유저입니다.");
            remitErrorPopup.SetActive(true);
            remitErrorMessageReason.text = "존재하지 않는 유저입니다.";
        }
    }

    public void CloseremitErrorPopup()
    {
        remitErrorPopup.SetActive(false);
    }

    public void ClickOpenRemitUI()
    {
        backRemitUI1.SetActive(true);
        backRemitUI2.SetActive(false);
        remitUI.SetActive(true);

    }
    public void ClickBackRemitUI()
    {
        backRemitUI1.SetActive(true);
        backRemitUI2.SetActive(true);
        remitUI.SetActive(false);
    }

}
