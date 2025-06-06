using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class LoginUIManager : MonoBehaviour
{
    public GameObject startLoginUISetting;
    public GameObject signUpUIPopUp;
    public GameObject errorPopUp;

    //패스워드 입력하면 *로 변환시켜야함
    public TMP_InputField PassWord_Art_Star;

    void Start()
    {
        startLoginUISetting.SetActive(true);
        signUpUIPopUp.SetActive(false);
        errorPopUp.SetActive(false);
    }

    //회원가입 버튼
    public void SignUpPopUp()
    {
        signUpUIPopUp.SetActive(true);
    }

    public void SignUpPupUpCancel()
    {
        signUpUIPopUp.SetActive(false);
    }

    public void ShowErrorPopUp()
    {
        errorPopUp.SetActive(true);
    }
    public void ShowErrorPopUpCancel()
    {
        errorPopUp.SetActive(false);
    }

}
