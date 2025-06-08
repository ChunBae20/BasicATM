using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Esc : MonoBehaviour
{
    public GameObject noNeedAccept;
    public GameObject deletedataPanel;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            noNeedAccept.SetActive(false);
            deletedataPanel.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            deletedataPanel.SetActive(true);
        }
    }


}
