using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    int playerAttackCool, enemyAttackCool;
    public GameObject player, enemy;        //  player unit과 enemy unit의 manager object를 가져옴.
    public GameObject DamageText;           // Damage Text manager 가져옴
    public bool isPlayerUnitChanged = false;
    public bool isEnemyUnitChanged = false;
    void Start()
    {
        playerAttackCool = player.GetComponent<PlayerUnitManager>().PlayerUnit.GetComponent<Status>().AS;
        enemyAttackCool = enemy.GetComponent<EnemyUnitManager>().EnemyUnit.GetComponent<Status>().AS;
        // 플레이어 유닛과 상대 유닛의 공격속도(공격 쿨타임)을 가져옴.
        StartCoroutine("PlayerAttack");
        StartCoroutine("EnemyAttack");
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerUnitChanged)
        {
            StopCoroutine("PlayerAttack");
            playerAttackCool = player.GetComponent<PlayerUnitManager>().PlayerUnit.GetComponent<Status>().AS;
            isPlayerUnitChanged = false;
            StartCoroutine("PlayerAttack");
        }
        if (isEnemyUnitChanged)
        {
            StopCoroutine("EnemyAttack");
            enemyAttackCool = enemy.GetComponent<EnemyUnitManager>().EnemyUnit.GetComponent<Status>().AS;
            isEnemyUnitChanged = false;
            StartCoroutine("EnemyAttack");
        }
    }

    IEnumerator PlayerAttack()
    {
        int damage;
        while (true)
        {
            if(player.GetComponent<PlayerUnitManager>().PlayerUnit.GetComponent<Status>().AD != 0)
                damage = player.GetComponent<PlayerUnitManager>().PlayerUnit.GetComponent<Status>().AD - enemy.GetComponent<EnemyUnitManager>().EnemyUnit.GetComponent<Status>().DEF;
            else
                damage = player.GetComponent<PlayerUnitManager>().PlayerUnit.GetComponent<Status>().AP - enemy.GetComponent<EnemyUnitManager>().EnemyUnit.GetComponent<Status>().RES;
            enemy.GetComponent<EnemyUnitManager>().EnemyUnit.GetComponent<Status>().HP -= damage;
            DamageText.transform.GetChild(0).GetComponent<ShowDamage>().TakeDamage(damage);
            if (enemy.GetComponent<EnemyUnitManager>().EnemyUnit.GetComponent<Status>().HP <= 0)
            {
                if (enemy.GetComponent<EnemyUnitManager>().EnemyUnit.GetComponent<Status>().nextEnemy != null)
                {
                    enemy.GetComponent<EnemyUnitManager>().EnemyUnit.transform.GetChild(0).gameObject.SetActive(false);
                    enemy.GetComponent<EnemyUnitManager>().EnemyUnit = enemy.GetComponent<EnemyUnitManager>().EnemyUnit.GetComponent<Status>().nextEnemy;
                    enemy.GetComponent<EnemyUnitManager>().EnemyUnit.transform.GetChild(0).gameObject.SetActive(true);
                    isEnemyUnitChanged = true;
                    
                }
                else
                {
                    StopCoroutine("PlayerAttack");
                    StopCoroutine("EnemyAttack");
                }
            }
            yield return new WaitForSeconds(playerAttackCool);
        }
    }
    IEnumerator EnemyAttack()
    {
        int damage;
        while (true)
        {
            if (player.GetComponent<PlayerUnitManager>().PlayerUnit.GetComponent<Status>().AD != 0)
                damage = player.GetComponent<PlayerUnitManager>().PlayerUnit.GetComponent<Status>().AD - enemy.GetComponent<EnemyUnitManager>().EnemyUnit.GetComponent<Status>().DEF;
            else
                damage = player.GetComponent<PlayerUnitManager>().PlayerUnit.GetComponent<Status>().AP - enemy.GetComponent<EnemyUnitManager>().EnemyUnit.GetComponent<Status>().RES;
            player.GetComponent<PlayerUnitManager>().PlayerUnit.GetComponent<Status>().HP -= damage;
            DamageText.transform.GetChild(1).GetComponent<ShowDamage>().TakeDamage(damage);
            if (player.GetComponent<PlayerUnitManager>().PlayerUnit.GetComponent<Status>().HP <= 0)
            {
                StopCoroutine("PlayerAttack");
                StopCoroutine("EnemyAttack");
            }
            yield return new WaitForSeconds(enemyAttackCool);
        }
    } 
}
