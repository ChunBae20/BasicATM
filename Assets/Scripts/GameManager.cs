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

    public string nowLoginID;

    public UserData userData;


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
        PlayerPrefs.SetString($"ID/{nowLoginID}/UserNM", userData.GetUserName());
        PlayerPrefs.SetString($"ID/{nowLoginID}/UserCash", userData.GetUserBasicCash().ToString());
        PlayerPrefs.SetString($"ID/{nowLoginID}/UserBalance", userData.GetUserBasicBalance().ToString());
        PlayerPrefs.Save();
    }

    public void LoadUserData(string userID)
    {
        nowLoginID = userID;
        //여기세팅값은 없을때만 이렇게 값을 반환하나보네
        //ulong을 스트링으로 감싼걸
        string name = PlayerPrefs.GetString($"ID/{userID}/NM", "의문의 개발자가 보인다는건 뭔가 잘못됐다는것임");
        string cashStr = PlayerPrefs.GetString($"ID/{userID}/UserCash", "100002");
        string balanceStr = PlayerPrefs.GetString($"ID/{userID}/UserBalance", "50002");

        //다시 ulong으로 변환
        ulong cash = ulong.Parse(PlayerPrefs.GetString($"ID/{userID}/UserCash", "0"));
        ulong balance = ulong.Parse(PlayerPrefs.GetString($"ID/{userID}/UserBalance", "0"));

        userData.Set(name, cash, balance);
        Refresh(userData);
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

/*
 void Start()
    {
        //아 어떡하지 튜터님이 이거 쓰라고 하셨는데이러면 매번 생성습 뭐지?아
        
        if(PlayerPrefs.HasKey("UserName") && PlayerPrefs.HasKey("UserCash")&& PlayerPrefs.HasKey("UserBalance"))
        {
            LoadUserData();
        }
        else
        {
            userData = new UserData("의문의 개발자", 50001, 100_001);
            Refresh(userData);
            SaveUserData();
        }
        
    }

*/
#endregion
