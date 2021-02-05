using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveExplainButton : MonoBehaviour
{
    void explainPassvie()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
    }
    void offExplain()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }
}
