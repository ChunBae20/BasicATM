using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartUISetting : MonoBehaviour
{
    public GameObject Login;
    public GameObject ATM;
    void Start()
    {
        Login.SetActive(true);
        ATM.SetActive(false);
    }

    
}
