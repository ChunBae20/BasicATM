using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerIV : MonoBehaviour
{
    public static GameManagerIV Instance;

    //public CharacterIV Character = new CharacterIV("개발자", "코딩", "너무너무 졸리네");  아 이게아니라 프로퍼티
    public CharacterIV Player { get;private set; }
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            SetPlayerData();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void SetPlayerData()
    {
        Player = new CharacterIV("개발자", "코딩", "너무너무 졸리네");
    }


    //구조체를 생성해서 어딘가에서 받아오게 한다. 구조체에서만 베이스 스탯을 받으면 인자 가 줄어든다 지금 생성자 3번하는거보다 그냥 구조체로 베이스 스택 만들어서
    // 값을 박아넣는건 별로 좋지 않음 예를들어 in a = 5;이렇게 하면 처음에 만든사람만 알지 이게 뭔지를 다른사람은 모름
    //수학공식을 쓸때는 const랑 주석으로 쓴다. 협업 유지보수 좋음 매직넘버 방지하기도 좋다.

}
