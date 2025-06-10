using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class UIStatusIV : MonoBehaviour
{
    [SerializeField]
    Button openMainMenuButton;

    public TextMeshProUGUI basicSTR_Text;
    public TextMeshProUGUI basicDEF_Text;
    public TextMeshProUGUI basicHP_Text;
    public TextMeshProUGUI basicCRT_Text;

    void Start()
    {
        openMainMenuButton.onClick.AddListener(OpenMainMenu);
        SetStatUI();
    }

    //aba씬으로 오면 두번 등록될수도 있는것임. 리스너 관리가 별도로 필요하다.
    //애드리스터 하고 해제하는거도 세트로 해야한다. 오브젝트를 껐다켰을때 이게 계속 추가돼서 스타트가 두번타면 두개가 장착될수있음. 해제 하는것도 해야함.
    



    public void OpenMainMenu()
    {
        UIManagerIV.Instance.OpenMainMenu();


    }
    public void SetStatUI()
    {
        basicSTR_Text.text = GameManagerIV.Instance.Player.GetbasicSTR().ToString();
        basicDEF_Text.text = GameManagerIV.Instance.Player.GetBasicDEF().ToString();
        basicHP_Text.text = GameManagerIV.Instance.Player.GetbasicHP().ToString();
        basicCRT_Text.text = GameManagerIV.Instance.Player.GetBasicCRT().ToString();
    }
}
