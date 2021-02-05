using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitMPBar : MonoBehaviour
{
    public Slider mpBar;
    public GameObject Unit;
    public string unit_type;
    // Start is called before the first frame update
    void Awake()
    {
        float MP = 0.0f, maxMP = 0.0f;
        if (unit_type.Equals("player"))
        {
            MP = (float)Unit.GetComponent<PlayerUnitManager>().PlayerUnit.GetComponent<Status>().MP;
            maxMP = (float)Unit.GetComponent<PlayerUnitManager>().PlayerUnit.GetComponent<Status>().max_MP;
        }
        else if (unit_type.Equals("enemy"))
        {
            MP = (float)Unit.GetComponent<EnemyUnitManager>().EnemyUnit.GetComponent<Status>().MP;
            maxMP = (float)Unit.GetComponent<EnemyUnitManager>().EnemyUnit.GetComponent<Status>().max_MP;
        }

        mpBar.value = MP / maxMP;


    }

    // Update is called once per frame
    void Update()
    {
        float mp = 0.0f, maxmp = 0.0f;
        if (unit_type.Equals("player"))
        {
            mp = (float)Unit.GetComponent<PlayerUnitManager>().PlayerUnit.GetComponent<Status>().MP;
            maxmp = (float)Unit.GetComponent<PlayerUnitManager>().PlayerUnit.GetComponent<Status>().max_MP;
        }
        else if (unit_type.Equals("enemy"))
        {
            mp = (float)Unit.GetComponent<EnemyUnitManager>().EnemyUnit.GetComponent<Status>().MP;
            maxmp = (float)Unit.GetComponent<EnemyUnitManager>().EnemyUnit.GetComponent<Status>().max_MP;
        }

        mpBar.value = mp / maxmp;
    }
}
