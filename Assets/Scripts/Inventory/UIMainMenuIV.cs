using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Numerics;
using Unity.VisualScripting;
using TMPro;

public class UIMainMenuIV : MonoBehaviour
{
    [SerializeField]
    Button openStatusButton;
    [SerializeField]
    Button openInventoryButton;

    public TextMeshProUGUI moneyGold;
    public string outputStringGold;

    public TextMeshProUGUI playerName_Text;
    public TextMeshProUGUI playerjob_Text;
    public TextMeshProUGUI playerLevel_Text;
    public TextMeshProUGUI playerDes_Text;





    //아 c#은 int lon ulong 중 하나로 인식해야 new에 컴파일 해서 넣어주는구나
    //999_999_999_999_999_999_999_999_999_999_999_999_999_999_999_999 _언더바 사용하면 오류뜨네
    //BigInteger goldOutput = BigInteger.Parse("999999999999999999999999999999999999999999999999");

    static readonly string[] stringPreset = {
        "", "K", "M", "B", "T", // 10^3 ~ 10^12
        "aa", "ab", "ac", "ad", "ae", "af", "ag", "ah", "ai", "aj", "ak", "al","am","an","aO","ap","aq","ar","as","at","au","av","aw","ax","ay","az" // 10^15 ~ 10^48
    };

    public string CalGoldOutPut(BigInteger goldOutput)
    {
        BigInteger moneyTier = new BigInteger(999_999_999);
        int index = 0;

        if (goldOutput <= moneyTier)
        {
            return goldOutput.ToString("N0");
        }

        while (goldOutput > moneyTier && index < stringPreset.Length - 1)
        {
            goldOutput /= 1_000;
            index++;
        }

        return goldOutput.ToString("N0") + stringPreset[index];
    }

    void Start()
    {
        SetMainUIText();

        openStatusButton.onClick.AddListener(OpenStatus);
        openInventoryButton.onClick.AddListener(OpenInventory);
    }
    void Update()
    {
        BigInteger result;
        if (BigInteger.TryParse(outputStringGold, out result))
        {
            moneyGold.text = CalGoldOutPut(result);
        }
        else
        {
            Debug.Log("잘못된 값이 입력되어 변환 실패");
        }
    }
    public void OpenStatus()
    {
        UIManagerIV.Instance.OpenStatus();

    }

    public void OpenInventory()
    {
        UIManagerIV.Instance.OpenInventory();

    }

    void SetMainUIText()
    {
        playerName_Text.text = GameManagerIV.Instance.Player.GetBasicName();
        playerjob_Text.text = GameManagerIV.Instance.Player.GetBasicJob();
        playerLevel_Text.text = $"LV. {GameManagerIV.Instance.Player.GetBasicLevel().ToString()}";
        playerDes_Text.text = GameManagerIV.Instance.Player.GetBasicDes();


    }

    #region 출력테스트
    /*
    BigInteger[] testValues = {
            999_999_999,                      
            1_000_000_000,                    
            999_999_999_999,
            1_000_000_000_000,                
            999_999_999_999_999,
            1_000_000_000_000_000,            
            BigInteger.Parse("1000000000000000000"), 
            BigInteger.Parse("1000000000000000000000") 
        };

        foreach (var val in testValues)
        {
            Debug.Log(CalGoldOutPut(val));
        }

    BigInteger result;
        if(BigInteger.TryParse(outputStringGold, out result))
        {
            moneyGold.text = CalGoldOutPut(result);
        }
        else
        {
            Debug.Log("잘못된 값이 입력되어 변환 실패");
        }
        //string resultMoney = CalGoldOutPut(ResultMoney);



        */
    #endregion



}
