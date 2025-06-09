using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIInventoryIV : MonoBehaviour
{

    [SerializeField]
    Button openMainMenuButton;

    void Start()
    {
        openMainMenuButton.onClick.AddListener(OpenMainMenu);
    }
    public void OpenMainMenu()
    {
        UIManagerIV.Instance.OpenMainMenu();
    }
}
