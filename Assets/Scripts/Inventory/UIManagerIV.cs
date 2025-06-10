using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UIManagerIV : MonoBehaviour
{
    public static UIManagerIV Instance;

    //public CharacterIV character;


    [SerializeField]
    private UIMainMenuIV mainMenuUI;
    public UIMainMenuIV Mainmenu { get { return mainMenuUI; } }

    [SerializeField]
    private UIStatusIV statusUI;
    public UIStatusIV StatusUI { get { return statusUI; } }



    [SerializeField]
    private UIInventoryIV inventoryUI;
    public UIInventoryIV InventoryUI { get { return inventoryUI; } }

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


    public void OpenMainMenu()
    {
        mainMenuUI.gameObject.SetActive(true);
        statusUI.gameObject.SetActive(false);
        inventoryUI.gameObject.SetActive(false);
    }

    public void OpenStatus()
    {
        mainMenuUI.gameObject.SetActive(true);
        statusUI.gameObject.SetActive(true);
        inventoryUI.gameObject.SetActive(false);
    }

    public void OpenInventory()
    {
        mainMenuUI.gameObject.SetActive(true);
        statusUI.gameObject.SetActive(false);
        inventoryUI.gameObject.SetActive(true);
    }

}
