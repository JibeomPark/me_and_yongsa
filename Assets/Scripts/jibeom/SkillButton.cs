using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SkillButton : MonoBehaviour
{
    public GameObject player;
    int skillCoolTime;

    public void useSkill()
    {
        skillCoolTime = player.GetComponent<PlayerUnitManager>().PlayerUnit.GetComponent<Skill>().activeSkill();
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
        this.GetComponent<Button>().interactable = false;
        StartCoroutine(ActiveCoolTime(skillCoolTime));

    }

    IEnumerator ActiveCoolTime(int cool)
    {
        while (true)
        {
            if (cool == 0)
            {
                gameObject.transform.GetChild(0).gameObject.SetActive(false);
                this.GetComponent<Button>().interactable = true;
                break;
            }
            else
            {
                cool--;
                gameObject.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = cool.ToString();

            }
            yield return new WaitForSeconds(1);
        }
        yield return null;
    }

}
