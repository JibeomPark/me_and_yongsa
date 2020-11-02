using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class movescene : MonoBehaviour
{
    public string SceneToLoad_0;
    public string SceneToLoad_1;
    public string SceneToLoad_2;
    public string SceneToLoad_3;
    public string SceneToLoad_4;
    public string SceneToLoad_5;
    public string SceneToLoad_6;
    public string SceneToLoad_7;
    public string SceneToLoad_8;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
 
    }

    public void changeGameScene_0()
    {
        Debug.Log(SceneToLoad_0);
        SceneManager.LoadScene(SceneToLoad_0);
    }

    public void changeGameScene_1()
    {
        Debug.Log(SceneToLoad_1);
        SceneManager.LoadScene(SceneToLoad_1);
    }

    public void changeGameScene_2()
    {
        Debug.Log(SceneToLoad_2);
        SceneManager.LoadScene(SceneToLoad_2);
    }

    public void changeGameScene_3()
    {
        Debug.Log(SceneToLoad_3);
        SceneManager.LoadScene(SceneToLoad_3);
    }

    public void changeGameScene_4()//if you need loading sence
    {
        Debug.Log(SceneToLoad_4);
//        SceneManager.LoadScene(SceneToLoad_4);
        LOADING.changeGameScene(SceneToLoad_4);
    }

    public void changeGameScene_5()//if you need loading sence
    {
        Debug.Log(SceneToLoad_5);
        //SceneManager.LoadScene(SceneToLoad_4);
        LOADING.changeGameScene(SceneToLoad_5);
    }

    public void changeGameScene_6()//if you need loading sence
    {
        Debug.Log(SceneToLoad_6);
        //SceneManager.LoadScene(SceneToLoad_4);
        LOADING.changeGameScene(SceneToLoad_6);
    }

    public void changeGameScene_7()//if you need loading sence
    {
        Debug.Log(SceneToLoad_7);
        //SceneManager.LoadScene(SceneToLoad_4);
        LOADING.changeGameScene(SceneToLoad_7);
    }

    public void changeGameScene_8()//if you need loading sence
    {
        Debug.Log(SceneToLoad_8);
        //SceneManager.LoadScene(SceneToLoad_4);
        LOADING.changeGameScene(SceneToLoad_8);
    }

}
