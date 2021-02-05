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
        if (player.GetComponent<PlayerUnitManager>().PlayerUnit.GetComponent<Status>().MP < player.GetComponent<PlayerUnitManager>().PlayerUnit.GetComponent<Skill>().needMP)
            Debug.Log("마나가 부족합니다.");
        else
        {
            skillCoolTime = player.GetComponent<PlayerUnitManager>().PlayerUnit.GetComponent<Skill>().activeSkill();
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            this.GetComponent<Button>().interactable = false;
            StartCoroutine(ActiveCoolTime(skillCoolTime));
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
