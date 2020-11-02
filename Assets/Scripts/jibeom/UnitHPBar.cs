using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitHPBar : MonoBehaviour
{
    public Slider hpBar;
    public GameObject Unit;
    public string unit_type;
    // Start is called before the first frame update
    void Awake()
    {
        float HP = 0.0f, maxHP = 0.0f;
        if (unit_type.Equals("player"))
        {
            HP = (float)Unit.GetComponent<PlayerUnitManager>().PlayerUnit.GetComponent<Status>().HP;
            maxHP = (float)Unit.GetComponent<PlayerUnitManager>().PlayerUnit.GetComponent<Status>().max_HP;
        }
        else if (unit_type.Equals("enemy"))
        {
            HP = (float)Unit.GetComponent<EnemyUnitManager>().EnemyUnit.GetComponent<Status>().HP;
            maxHP = (float)Unit.GetComponent<EnemyUnitManager>().EnemyUnit.GetComponent<Status>().max_HP;
        }

        hpBar.value = HP / maxHP;


    }

    // Update is called once per frame
    void Update()
    {
        float HP = 0.0f, maxHP = 0.0f;
        if (unit_type.Equals("player"))
        {
            HP = (float)Unit.GetComponent<PlayerUnitManager>().PlayerUnit.GetComponent<Status>().HP;
            maxHP = (float)Unit.GetComponent<PlayerUnitManager>().PlayerUnit.GetComponent<Status>().max_HP;
        }
        else if (unit_type.Equals("enemy"))
        {
            HP = (float)Unit.GetComponent<EnemyUnitManager>().EnemyUnit.GetComponent<Status>().HP;
            maxHP = (float)Unit.GetComponent<EnemyUnitManager>().EnemyUnit.GetComponent<Status>().max_HP;
        }

        hpBar.value = HP / maxHP;
    }
}
