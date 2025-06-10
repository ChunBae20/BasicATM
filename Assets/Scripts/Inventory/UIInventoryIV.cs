using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIInventoryIV : MonoBehaviour
{

    [SerializeField]
    Button openMainMenuButton;

    public GameObject slotPrefabs; //생성될 슬롯 프리팹들 기본 120개

    //public UISlotIV uiSlots;

    public Transform content; //스크롤뷰아래의 content를 부모로두고 자식을 프리팹으로 생성하면 되겟지..?

    public List<UISlotIV> uiSlots = new List<UISlotIV>();

    int basicUIslotCount = 120;
    

    void Start()
    {
        openMainMenuButton.onClick.AddListener(OpenMainMenu);

        SpawnSlots();

    }
    public void OpenMainMenu()
    {
        UIManagerIV.Instance.OpenMainMenu();
    }

    void SpawnSlots()
    {

        for (int i =0;i< basicUIslotCount; i++)
        {
            uiSlots.Add(new UISlotIV());


        }



    }



}
