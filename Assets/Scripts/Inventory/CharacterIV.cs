using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

[System.Serializable]
public class CharacterIV
{

    //외부의 매개변수 값을 받아서 클래스 내부멤버변수에 대입한다.매개변수입력받으면, 멤버변수 = 매개변수
    //이게 생성자의 역할인가 근데 애초에 기본값으로 할거면 그냥 이거 이렇게 안써도되는거아닌가?
    //이거 나 값들은 다 
    /*ushort basicLevel, ulong basicSTR, ulong basicDEF, ulong basicHP, ushort basicCRT, BigInteger basicGold*/
    public CharacterIV(string basicName,string basicJob,string basicDes)
    {
        Debug.Log("나는야 신기한 생성자");

        this.basicName = basicName;
        this.basicJob = basicJob;
        this.basicDes = basicDes;
        /*
        this.basicLevel = basicLevel;
        this.basicSTR = basicSTR;
        this.basicDEF = basicDEF;
        this.basicHP = basicHP;
        this.basicCRT = basicCRT;
        this.basicGold = basicGold;
        */
    }


    string basicJob = "코딩노예6";//어...가이드라인님 이거 진짜에요?
    string basicName = "Chad6";
    string basicDes = "6코딩의 노예가 된지 10년짜리 되는 머슴입니다.오늘도 뱀샐일만 남아서 치킨을 시킬지도 모른다는 생각에 배민을 키고 있네요.";

    ulong basicSTR = 66;
    ulong basicDEF = 67;
    ulong basicHP = 68;

    ushort basicLevel = 19;
    float basicCRT = 31;

    BigInteger basicGold = new BigInteger(20000);


    //장비로 얻을수있는 최대 공격력
    [Tooltip("오를수있는 무기 최대 공격력 범위를 넘으면 치트감지")]
    ulong maxWeaponSTR=500;
    //장비로 얻을수있는 최대 방어력
    [Tooltip("오를수있는 무기 최대 방어력 범위를 넘으면 치트감지")]
    ulong maxWeaponDEF= 500;
    //장비로 얻을수있는 최대 체력
    [Tooltip("오를수있는 무기 최대 체력범위를 넘으면 치트감지")]
    ulong maxWeaponHP= 10_000;
    //장비로 얻을수있는 최대 치명타율
    [Tooltip("오를수있는 무기 최대 치명타율범위를 넘으면 치트감지")]
    ushort maxWeaponCRT = 100;
    //치확은 float타입을 쓰는게 나은가?

    //인게임 내에서 한번에 얻을수있는 최대 골드량? 
    BigInteger maxOnceGold = new BigInteger(200_000_000);


    public string GetBasicName()
    {
        return basicName;
    }

    public string GetBasicJob()
    {
        return basicJob;
    }

    public string GetBasicDes()
    {
        return basicDes;
    }


    //레벨 get, set
    public ushort GetBasicLevel()
    {
        return basicLevel;
    }
    public void SetBasicLevel(ushort BasicLevel)
    {
        //흠 근데이거 이렇게 하면 원본값 보장을 못받지 않나? 제한된 범위에서 수정이 목표?

        if (BasicLevel >= basicLevel)
        {
            basicLevel = BasicLevel;

        }
        else { Debug.Log(" 으흐 레벨은 절대 초기값보다 낮을 수가 없는데 유저 네이놈 치트 썼구나"); }
    }

    //공격력get,set
    public ulong GetbasicSTR()
    {
        return basicSTR;
    }
    public void SetBasicSTR(ulong BasisSTR)
    {
        if (BasisSTR >= basicSTR && BasisSTR <= maxWeaponSTR)
        {
            basicSTR = BasisSTR;
        }
        else { Debug.Log(" 으흐 유저 네이놈! 기어코 내가 지정한 최대공격력을 넘는 치트를 썼구나 "); }
    }

    //방어력 get, set
    public ulong GetBasicDEF()
    {
        return basicDEF;
    }
    public void SetBasicDEF(ulong BasicDEF)
    {
        if (BasicDEF >= basicDEF && BasicDEF <= maxWeaponDEF)
        {
            basicDEF = BasicDEF;
        }
        else { Debug.Log(" 으흐 유저 네이놈! 기어코 내가 지정한 최대공격력을 넘는 치트를 썼구나 "); }
    }

    //HP get,set
    public ulong GetbasicHP()
    {
        return basicHP;
    }
    public void SetBasicHP(ulong BasicHP)
    {
        if (BasicHP >= basicHP && BasicHP <= maxWeaponHP)
        {
            basicHP = BasicHP;
        }
        else { Debug.Log(" 으흐 유저 네이놈! 기어코 내가 지정한 최대공격력을 넘는 치트를 썼구나 "); }
    }


    //치명타확률 get, set
    public float GetBasicCRT()
    {
        return basicCRT;
    }
    public void SetBasicCRT(float BasicCRT)
    {
        if (BasicCRT >= basicCRT && BasicCRT <= maxWeaponCRT)
        {
            basicCRT = BasicCRT;
        }
        else
        {
            Debug.Log("아니 이상한나라의 유저유저야 내 게임이 뭐라고 치트까지쓰냐");
        }
    }


    //골드 get, set
    public BigInteger GetbasicGold()
    {
        return basicGold;
    }
    public void SetBasicGold(BigInteger BasicGold)
    {
        if (BasicGold >= basicGold && BasicGold <= maxOnceGold)
        {
            basicGold = BasicGold;
        }
        else
        {
            Debug.Log("에휴 고마해라");
            //치트팝업을 띄우며...
        }
    }

}
