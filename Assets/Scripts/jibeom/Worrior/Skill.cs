using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour      //  Worrior skill
{
    public GameObject Unit;
    public int skillCoolTime = 5, needMP = 30;

    GameObject enemy, floatingText;
    int max_HP, max_MP;
    void Start()
    {
        max_HP = Unit.GetComponent<Status>().max_HP;
        max_MP = Unit.GetComponent<Status>().max_MP;
        StartCoroutine("passiveSkill");
        enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyUnitManager>().EnemyUnit;
        floatingText = GameObject.FindGameObjectWithTag("FloatingText").transform.GetChild(0).gameObject;
    }
    IEnumerator passiveSkill()      //  전사 패시브스킬. 1초당 체력 10 회복
    {                               // 모든 캐릭터 공용 - 초당 마나 회복(마나 젠)
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
            if (0 < Unit.GetComponent<Status>().HP && Unit.GetComponent<Status>().MP <= max_MP)
            {
                if (Unit.GetComponent<Status>().MP + 5 > max_MP)
                    Unit.GetComponent<Status>().MP = max_MP;
                else
                    Unit.GetComponent<Status>().MP += 5;
            }
            yield return new WaitForSeconds(1);
        }

    }
    public int activeSkill()            //  적의 체력을 30 깎고, 나의 체력을 30 회복합니다.
    {
        Unit.GetComponent<Status>().MP -= needMP;
        Unit.GetComponent<Status>().HP += 30;
        enemy.GetComponent<Status>().HP -= 30;
        GameObject explodeEffect = Instantiate(Resources.Load<GameObject>("Effects/Explode"));
        explodeEffect.transform.parent = GameObject.FindGameObjectWithTag("Enemy").transform;
        explodeEffect.transform.position = explodeEffect.transform.parent.transform.position;
        explodeEffect.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        floatingText.GetComponent<ShowDamage>().TakeDamage(30);
        Debug.Log("스킬을 사용했습니다.");
        return skillCoolTime;
    }
}
