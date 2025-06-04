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
        userdata = new UserData("개발자",5001,100001);
        

    }
    void Update()
    {
        Refresh(userdata);
    }

    public void Refresh(UserData use)
    {
        showUserNameText.text = use.GetUserName();
        showUserCashText.text = use.GetUserBasicCash().ToString("N0");
        showUserBalanceText.text = use.GetUserBasicBalance().ToString("N0");
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
