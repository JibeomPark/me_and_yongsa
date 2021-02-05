using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public int min = 3, sec = 0;
    public GameObject battleMgr;
    // Update is called once per frame
    void Start()
    {
        StartCoroutine("SetTimer");
    }
    void Update()
    {
        if (min == sec && min == 0)
        {
            StopCoroutine("SetTimer");
            battleMgr.GetComponent<BattleManager>().timeOut();
        }

    }
    IEnumerator SetTimer()
    {
        while (true) {
            if (sec == 0)
            {
                sec = 59;
                min--;
            }
            else
                sec--;
            if (sec <= 9)
            {
                gameObject.transform.GetChild(2).GetComponent<Text>().text = "0" + sec;
            }
            else
                gameObject.transform.GetChild(2).GetComponent<Text>().text = sec.ToString();
            gameObject.transform.GetChild(0).GetComponent<Text>().text = "0" + min;

            yield return new WaitForSeconds(1);
        }
        yield return null;
    }
}
