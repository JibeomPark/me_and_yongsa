using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitChanger : MonoBehaviour
{
    public GameObject Unit, PlayerUnit, BattleMgr;
    private GameObject ActionBar, passiveSkillBar, ultSkillBar;
    // Start is called before the first frame update
    void Start()
    {
        ActionBar = GameObject.FindGameObjectWithTag("ActiveSkillBtn");
        passiveSkillBar = GameObject.FindGameObjectWithTag("PassiveSkillBtn");
        ultSkillBar = GameObject.FindGameObjectWithTag("UltSkillBtn");

    }
    public void unitChange()
    {
        ActionBar.gameObject.GetComponent<Image>().sprite = Unit.GetComponent<Status>().unitSkillIcon;
        passiveSkillBar.GetComponent<Image>().sprite = Unit.GetComponent<Status>().unitPassiveIcon;

        BattleMgr.GetComponent<BattleManager>().isPlayerUnitChanged = true;
        GameObject temp = Unit;
        Unit = PlayerUnit.GetComponent<PlayerUnitManager>().PlayerUnit;
        PlayerUnit.GetComponent<PlayerUnitManager>().PlayerUnit = temp;

        Unit.transform.GetChild(0).gameObject.SetActive(false);
        PlayerUnit.GetComponent<PlayerUnitManager>().PlayerUnit.transform.GetChild(0).gameObject.SetActive(true);
        gameObject.GetComponent<Image>().sprite = Unit.GetComponent<Status>().unitIcon;
        
        //        gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load(Unit.GetComponent<Status>().unitName) as Sprite;
    }
}
