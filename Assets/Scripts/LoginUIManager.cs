using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.Windows;
using System;
using System.Linq;


public class LoginUIManager : MonoBehaviour
{
    public UserData userData;

    //끄고 킬 UI들
    public GameObject startLoginUISetting;
    public GameObject signUpUIPopUp;
    public GameObject errorPopUp;
    public GameObject SuccessPopUP;
    public GameObject ErrorPopUpBlocked;

    //로그인 캔버스
    public GameObject LoginUICanvas;
    public GameObject ATMUICanvas;

    //ATM 캔버스

    //에러팝업 텍스트 고치기
    public TextMeshProUGUI ControlErrorReason;

    //오류메시지TMP
    public TextMeshProUGUI errorReason;

    //가입시 반드시 해야함 안하면 신고할게^^
    public TMP_InputField necessarySignUpID;
    public TMP_InputField necessarySignUpName;
    public TMP_InputField necessarySignUpPassword;
    public TMP_InputField necessarySignUpPasswordConfirm;

    //로그인 인풋 필드
    public TMP_InputField loginInputID;
    public TMP_InputField loginInputPW;

    public bool isSignUpIDExist;
    public bool isSignUpNameExist;
    public bool isSignUpPasswordExist;
    public bool isSignUpPasswordConfirmExist;

    public bool isLoginIDExist;
    public bool isLoginPWExist;

    //가입시 반드시 확인해야할 조건
    public bool CanSignUp()
    {
        //아니 그 지금 return false로 해도 이게 아닐때만 return false를 하는거잖아 머리 왤케 안돌아가지 버그가 나야하는데 왜 안나는건데
        //결국엔 true값에서 다시 false로 안바뀌는데
        //유지된 상황에서 회원가입 버튼을 누르는 상황을 재현을 해야하는데 어떻게하는건데

        //오류메시지 출력은 근데 어차피 누를때마다 검사하는거니까 한개씩만보여줘도 유저가 해결하면 다음안된걸 출력해주니까 뭐
        //스위치문이나 if문 써서 2&&4번 출력안됨 이런거 안해도되겠지?
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
                        return isSignUpIDExist == true && isSignUpNameExist == true && isSignUpPasswordExist == true && isSignUpPasswordConfirmExist == true;

                    }
                    else
                    {
                        errorReason.text = "패스워드가 똑같지 않음";
                        return false;
                    }

                }
                else
                {
                    errorReason.text = "패스워드 입력 안함";
                    return false;
                }

            }
            else
            {
                errorReason.text = "이름 입력 안함";
                return false;
            }

        }
        else 
        {
            errorReason.text = "아이디 입력 안함";
            return false; 
        }
    }

    public void MakeID()
    {
        signUpUIPopUp.SetActive(true);
        ErrorPopUpBlocked.SetActive(false);

        bool canSignUp = CanSignUp();

        if (canSignUp==true)
        {

            string newUserID = necessarySignUpID.text;
            string newUserPW = necessarySignUpPassword.text;
            string newUserNM = necessarySignUpName.text;
            string userList = PlayerPrefs.GetString("UserList", "");

            if (PlayerPrefs.HasKey($"ID/{newUserID}/PW") )
            {
                Debug.Log("이미 존재하는 아이디입니다.");

                errorPopUp.SetActive(true);
                ControlErrorReason.text = "이미 존재하는 아이디라고 좀 ";
                return;
            }
            else
            {
                Debug.Log("회원 가입 성공");
                SuccessPopUP.SetActive(true);
                //ControlErrorReason.text = "님아 이거 중복아이디임 고치셈";
                

                PlayerPrefs.SetString($"ID/{newUserID}", necessarySignUpID.text); //아이디
                PlayerPrefs.SetString($"ID/{newUserID}/PW", necessarySignUpPassword.text); //패스워드
                PlayerPrefs.SetString($"ID/{newUserID}/NM", necessarySignUpName.text); //이름
                PlayerPrefs.SetString($"ID/{newUserID}/UserCash", "50005"); //기본 현금
                PlayerPrefs.SetString($"ID/{newUserID}/UserBalance", "100005"); //기본 통장 잔고

                userList += "ID:" + newUserID + "PW:" + newUserPW+";";
                PlayerPrefs.SetString("UserList", userList);

                //저장이 되고나서 배열을 해주니까 크기 변경 상관없나?
                //이걸 makeid에서하는게아니라 Canlogin에서 불러와야하네?
                //string[] sepUserList = userList.Split(';', StringSplitOptions.RemoveEmptyEntries);
                //for (int i = 0; i < sepUserList.Length; i++) ;

                Debug.Log("현재아이디: "+PlayerPrefs.GetString($"ID/{newUserID}", ""));
                Debug.Log("현재비밀번호: "+PlayerPrefs.GetString($"ID/{newUserID}/PW", ""));
                GameManager.Instance.userData = new UserData(newUserID, 50005, 100005);
            }

            //PlayerPrefs.DeleteKey("ID/ID");       // "ID/ID" 키 삭제
            //PlayerPrefs.DeleteKey("ID/Password");


        }
        else 
        {
            //아니 이거 지금 치명적인 결함이 있네? 메이크 ID버튼을 누르면 처음에는 당연히 인풋필드에 아무것도없으니까 무조건 errorpopui가 뜨네 
            Debug.Log("회원 가입 실패");
            errorPopUp.SetActive(true);
            
        }
    }
              //  PlayerPrefs.SetString($"ID/{newUserID}", necessarySignUpID.text);
    public bool TestCanLogin()
    {
        string userIDPWList = PlayerPrefs.GetString("UserList");
        string[] sepUserList = userIDPWList.Split(';', StringSplitOptions.RemoveEmptyEntries);
        

        string loginUserID = loginInputID.text;
        string loginUserPW = loginInputPW.text;

        //userList += "ID:" + newUserID + "PW:" + newUserPW + ";"; 지금 이런식으로 저장됐잖아.


        for (int i = 0; i < sepUserList.Length; i++)
        {
            if (sepUserList[i] == "ID:" + loginUserID + "PW:"+ loginUserPW)
            {
                return true;
            }
        }

        Debug.Log("for문으로 아이디 패스워드 검색 해봤지만 일치하는 결과를 찾을수 없음");
        return false;
    }
    public bool CanLogin()
    {
        string userIDPWList = PlayerPrefs.GetString("UserList");
        string[] sepUserList = userIDPWList.Split(';', StringSplitOptions.RemoveEmptyEntries);


        string loginUserID = loginInputID.text;
        string loginUserPW = loginInputPW.text;
        string loginUserNM = PlayerPrefs.GetString($"ID/{loginUserID}/NM");

        //아이디 패스워드 두개다 입력했을 케이스
        // => 로그인 성공
        if (!string.IsNullOrWhiteSpace(loginInputID.text) && !string.IsNullOrWhiteSpace(loginInputPW.text))
        {
            //해당아이디가 존재하는지 && 비밀번호가 일치하는지 => 로그인성공
            if (PlayerPrefs.HasKey($"ID/{loginUserID}"))
            {
                if(PlayerPrefs.HasKey($"ID/{loginUserID}/PW") )
                {
                    for (int i = 0; i < sepUserList.Length; i++)
                    {
                        if (sepUserList[i] == "ID:" + loginUserID + "PW:" + loginUserPW)
                        {
                            Debug.Log("for문을 돌린결과 성공적으로 해당 아이디 패스워드를 찾았어요,로그인 성공!");

                            GameManager.Instance.nowLoginID = loginUserID;
                            GameManager.Instance.LoadUserData(loginUserID);
                            GameManager.Instance.Refresh(GameManager.Instance.userData);

                            return true;
                        }
                    }

                    Debug.Log("for문으로 아이디 패스워드 검색 해봤지만 일치하는 결과를 찾을수 없음");
                    return false;


                }
            }
            //비밀번호가 일치하지 않을경우
            else
            {
                Debug.Log("아이디 패스워드 두개다 입력했을케이스에서 오류발생");
                return false;
            }

        }
        //  아이디, !패스워드
        // => 패스워드를 입력해주세요 출력
        else if (!string.IsNullOrWhiteSpace(loginInputID.text) && string.IsNullOrWhiteSpace(loginInputPW.text))
        {
            Debug.Log("패스워드를 입력하세요!");
            return false;

        }
        //  !아이디, 패스워드 케이스
        // => 아이디를 입력해주세요
        else if (string.IsNullOrWhiteSpace(loginInputID.text) && !string.IsNullOrWhiteSpace(loginInputPW.text))
        {
            Debug.Log("아이디를 입력하세요!");
            return false;

        }
        //  !아이디, !패스워드
        // =>아이디,패스워드를 입력해주세요 출력
        else if (string.IsNullOrWhiteSpace(loginInputID.text) && string.IsNullOrWhiteSpace(loginInputPW.text))
        {
            Debug.Log("아이디,패스워드를 입력하세요!");
            return false;

        }
        return false;
    }

    public void Login()
    {
        if(CanLogin() == true)
        {
            //GameManager.Instance.LoadUserData(nowLogI);
            Debug.Log("로그인이 성공했으니 해당 UI로 넘어갑니다...");
            LoginUICanvas.SetActive(false);
            ATMUICanvas.SetActive(true);
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
