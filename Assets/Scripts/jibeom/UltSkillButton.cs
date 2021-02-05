using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UltSkillButton : MonoBehaviour
{
    public GameObject player, enemy;
    GameObject floatingText;
    public int UltCoolTime;
    public string UltName = "PowerfulAttack";

    void Start()
    {
        // 추후 타 씬에서 사용할 궁 이름 전달받아서 Start함수에서 UltName 초기화.
        ChangeUlt(UltName);
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
        this.GetComponent<Button>().interactable = false;
        StartCoroutine(ActiveCoolTime(UltCoolTime));
        enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyUnitManager>().EnemyUnit;
        floatingText = GameObject.FindGameObjectWithTag("FloatingText").transform.GetChild(0).gameObject;
    }
    public void useSkill()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
        this.GetComponent<Button>().interactable = false;
        StartCoroutine(ActiveCoolTime(UltCoolTime));
        if (UltName == "PowerfulAttack")
        {
            enemy.GetComponent<Status>().HP -= 100;
            floatingText.GetComponent<ShowDamage>().TakeDamage(100);

        }

    }

        void ChangeUlt(string UltName)
    {
        if (UltName == "PowerfulAttack")
        {
            gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Skills/Ult_PowerfulAttack");
            UltCoolTime = 15;
        }
    }

    IEnumerator ActiveCoolTime(int cool)
    {
        float cooltime = (float)cool;
        while (true)
        {
            if (cooltime == 0 || cooltime <= 0.1f)
            {
                gameObject.transform.GetChild(0).gameObject.SetActive(false);
                this.GetComponent<Button>().interactable = true;
                break;
            }
            else
            {
                cooltime = cooltime - 0.1f;
                gameObject.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = cooltime.ToString("N1");

            }
            yield return new WaitForSeconds(0.1f);
        }
        yield return null;
    }

}
