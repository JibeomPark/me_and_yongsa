using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class popup : MonoBehaviour
{
    public GameObject panel_0;
    public GameObject panel_1;
    public GameObject panel_2;
    public GameObject panel_3;
    public GameObject panel_4;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenPanel_0()
    {
        Debug.Log(panel_0);
        if(panel_0 != null)
        {
            bool isActive = panel_0.activeSelf;

            panel_0.SetActive(!isActive);
        }
    }

    public void OpenPanel_1()
    {
        Debug.Log(panel_1);
        if (panel_1 != null)
        {
            bool isActive = panel_1.activeSelf;

            panel_1.SetActive(!isActive);
        }
    }


    public void OpenPanel_2()
    {
        Debug.Log(panel_2);
        if (panel_2 != null)
        {
            bool isActive = panel_2.activeSelf;

            panel_2.SetActive(!isActive);
        }
    }


    public void OpenPanel_3()
    {
        Debug.Log(panel_3);
        if (panel_3 != null)
        {
            bool isActive = panel_3.activeSelf;

            panel_3.SetActive(!isActive);
        }
    }


    public void OpenPanel_4()
    {
        Debug.Log(panel_4);
        if (panel_4 != null)
        {
            bool isActive = panel_4.activeSelf;

            panel_4.SetActive(!isActive);
        }
    }




}
