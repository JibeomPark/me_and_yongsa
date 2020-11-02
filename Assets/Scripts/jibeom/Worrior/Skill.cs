using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    public GameObject Unit;
    int max_HP, max_MP;
    void Start()
    {
        max_HP = Unit.GetComponent<Status>().max_HP;
        max_MP = Unit.GetComponent<Status>().max_MP;
        StartCoroutine("passiveSkill");

    }

    IEnumerator passiveSkill()      //  전사 패시브스킬. 1초당 체력 10 회복
    {
        while (true)
        {
            if (0 < Unit.GetComponent<Status>().HP && Unit.GetComponent<Status>().HP <= max_HP)
            {
                if (Unit.GetComponent<Status>().HP + 10 > max_HP)
                    Unit.GetComponent<Status>().HP = max_HP;
                else
                    Unit.GetComponent<Status>().HP += 10;
            }
            else if (Unit.GetComponent<Status>().HP <= 0)
            {
                StopCoroutine("passiveSkill");
            }
            yield return new WaitForSeconds(1);
        }

    }
    public int activeSkill()
    {
        int skillCoolTime = 5;
        Debug.Log("use active Skill");
        return skillCoolTime;
    }
}
