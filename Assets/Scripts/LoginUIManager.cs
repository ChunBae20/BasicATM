using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;


public class LoginUIManager : MonoBehaviour
{
    public GameObject startLoginUISetting;
    public GameObject signUpUIPopUp;
    public GameObject errorPopUp;
    public GameObject SuccessPopUP;

    //가입시 반드시 해야함 안하면 신고할게^^
    public TMP_InputField necessarySignUpID;
    public TMP_InputField necessarySignUpName;
    public TMP_InputField necessarySignUpPassword;
    public TMP_InputField necessarySignUpPasswordConfirm;

    public bool isSignUpIDExist;
    public bool isSignUpNameExist;
    public bool isSignUpPasswordExist;
    public bool isSignUpPasswordConfirmExist;

    //가입시 반드시 확인해야할 조건
    public bool CanSignUp()
    {

        if (!string.IsNullOrWhiteSpace(necessarySignUpID.text))
        {
            isSignUpIDExist = true;

            if (!string.IsNullOrWhiteSpace(necessarySignUpName.text))
            {
                isSignUpNameExist = true;

                if (!string.IsNullOrWhiteSpace(necessarySignUpPassword.text))
                {
                    isSignUpPasswordExist = true;

                    if (necessarySignUpPassword.text == necessarySignUpPasswordConfirm.text && !string.IsNullOrWhiteSpace(necessarySignUpPasswordConfirm.text))
                    {
                        isSignUpPasswordConfirmExist = true;
                        return isSignUpIDExist ==true && isSignUpNameExist == true && isSignUpPasswordExist == true && isSignUpPasswordConfirmExist == true;
                        
                    }
                    else return false;

                }
                else return false;

            }
            else return false;

        }
        else return false;
    }

    public void MakeID()
    {
        if(CanSignUp() ==true)
        {
            Debug.Log("회원 가입 성공");
            SuccessPopUP.SetActive(true);
            
        }
        else if (CanSignUp() == false)
        {
            Debug.Log("회원 가입 실패");
            errorPopUp.SetActive(true);
            
        }
    }

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

    
    public void ShowErrorPopUpCancel()
    {
        errorPopUp.SetActive(false);
    }

    public void ShowSuccessSignUpPopUpCancel()
    {
        SuccessPopUP.SetActive(false);
    }

}
