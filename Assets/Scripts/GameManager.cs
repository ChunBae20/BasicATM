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
        //GetUserinfo();
        userdata = new UserData("이주현",5000,100000);
        

    }
    void Update()
    {

    }
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

}
