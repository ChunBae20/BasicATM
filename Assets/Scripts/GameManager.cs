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
        //아 어떡하지 튜터님이 이거 쓰라고 하셨는데이러면 매번 생성습 뭐지?아

        if(PlayerPrefs.HasKey("UserName") && PlayerPrefs.HasKey("UserCash")&& PlayerPrefs.HasKey("UserBalance"))
        {
            LoadUserData();
        }
        else
        {
            userdata = new UserData("의문의 개발자", 50001, 100_001);
            Refresh(userdata);
            SaveUserData();
        }

    }


    void Update()
    {

    }

    public void Refresh(UserData use)
    {
        showUserNameText.text = use.GetUserName();
        showUserCashText.text = use.GetUserBasicCash().ToString("N0");
        showUserBalanceText.text = $"balance {use.GetUserBasicBalance().ToString("N0")}";
        //이게 밸런스 칸을 만든게 아니라 그냥 하드코딩으로 친거였어? 와 떼끄널러지아!
        //showUserNameText.text = use.GetUserName(); 기존에는 balcance표시할 ui만들고 거기다가 또 따로 기본ㄱ밧넣고 호리즌탈 레이아웃 구룹 써서 함 ㄷㄷ
    }

    //  PlayerPrefs.set타입(키,값);//스트링 인트 float로만 저장가능하므로 다른타입은 string변환해야함
    public void SaveUserData()
    {
        PlayerPrefs.SetString("UserName", userdata.GetUserName());
        PlayerPrefs.SetString("UserCash", userdata.GetUserBasicCash().ToString());
        PlayerPrefs.SetString("UserBalance", userdata.GetUserBasicBalance().ToString());
        PlayerPrefs.Save();
    }

    public void LoadUserData()
    {
        //여기세팅값은 없을때만 이렇게 값을 반환하나보네
        //ulong을 스트링으로 감싼걸
        string name = PlayerPrefs.GetString("UserName", "의문의 개발자2");
        string cashStr = PlayerPrefs.GetString("UserCash", "100002");
        string balanceStr = PlayerPrefs.GetString("UserBalance", "50002");

        //다시 ulong으로 변환
        ulong cash = ulong.Parse(cashStr);
        ulong balance = ulong.Parse(balanceStr);

        userdata.Set(name, cash, balance);
        Refresh(userdata);
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
