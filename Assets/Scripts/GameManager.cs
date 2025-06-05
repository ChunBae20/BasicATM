using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    public TextMeshProUGUI showUserNameText;
    public TextMeshProUGUI showUserCashText;
    public TextMeshProUGUI showUserBalanceText;

    public static GameManager Instance;

    public UserData userdata;


    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

       
    }
    void Start()
    {
        userdata = new UserData("의문의 개발자",50001,100_001);
        Refresh(userdata); 


    }


    void Update()
    {

    }

    public void Refresh(UserData use)
    {
        showUserNameText.text = use.GetUserName();
        showUserCashText.text =  use.GetUserBasicCash().ToString("N0");
        showUserBalanceText.text = $"balance {use.GetUserBasicBalance().ToString("N0")}";
        //이게 밸런스 칸을 만든게 아니라 그냥 하드코딩으로 친거였어? 와 떼끄널러지아!
        //showUserNameText.text = use.GetUserName(); 기존에는 balcance표시할 ui만들고 거기다가 또 따로 기본ㄱ밧넣고 호리즌탈 레이아웃 구룹 써서 함 ㄷㄷ
    }

}



#region 더미데이터 
/*
//
    void GetUserinfo()
    {
        string userName = userdata.GetUserName();
        int userCash = userdata.GetUserBasicCash();
        int userBalance = userdata.GetUserBasicBalance();

        showUserNameText.text = userName;
        showUserCashText.text = userCash.ToString("N0");
        showUserBalanceText.text = userBalance.ToString("N0");
    }
*/
#endregion
