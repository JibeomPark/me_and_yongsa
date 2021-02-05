using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    int playerAttackCool, enemyAttackCool;
    public GameObject player, enemy;        //  player unit과 enemy unit의 manager object를 가져옴.
    public GameObject DamageText;           // Damage Text manager 가져옴
    public bool isPlayerUnitChanged = false; // 현재 컨트롤중인 유닛이 최근에 바뀌었는지
    public bool isEnemyUnitChanged = false;  // 현재 공격 대상인 적 유닛이 최근에 바뀌었는지 ==> 다대 다 전투이지만 공/방은 1대1

    private GameObject Canvas;
    void Start()
    {
        playerAttackCool = player.GetComponent<PlayerUnitManager>().PlayerUnit.GetComponent<Status>().AS;
        enemyAttackCool = enemy.GetComponent<EnemyUnitManager>().EnemyUnit.GetComponent<Status>().AS;
        // 플레이어 유닛과 상대 유닛의 공격속도(공격 쿨타임)을 가져옴.
        StartCoroutine("PlayerAttack");
        StartCoroutine("EnemyAttack");
        Canvas = GameObject.FindWithTag("Canvas");


    }

    // Update is called once per frame
    void Update()
    {
        // 최근에 유저/적 유닛이 바뀐 경우 공격 루프를 멈추고 스텟을 갱신함.
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
    public void timeOut()           //  스테이지 제한시간 초과
    {
        StopAllCoroutines();
        Canvas.transform.GetChild(4).gameObject.SetActive(true);
        Canvas.transform.GetChild(4).GetChild(1).gameObject.GetComponent<Text>().text = "패배";
        Canvas.transform.GetChild(4).GetChild(3).gameObject.SetActive(true);

    }

    IEnumerator PlayerAttack()
    {
        int damage, playerAD, playerAP, enemyDEF, enemyRES;
        damage = playerAD = playerAP = enemyDEF = enemyRES = 0;

        int maxMP, genMP;


        // AD = 물리공격력, AP = 마법공격력, DEF = 물리방어력, RES = 마법방어력
        // 유닛은 물리공격력과 마법공격력 중 한가지만을 가짐.
        // 만약 물리공격력이 존재한다면 마법공격력은 0이고, 마법공격력이 존재한다면 물리공격력은 0
        // 이를 이용하여 GetComponent 호출을 최소화함.

        playerAD = player.GetComponent<PlayerUnitManager>().PlayerUnit.GetComponent<Status>().AD;
        if (playerAD == 0) {
            playerAP = player.GetComponent<PlayerUnitManager>().PlayerUnit.GetComponent<Status>().AP;
            enemyRES = enemy.GetComponent<EnemyUnitManager>().EnemyUnit.GetComponent<Status>().RES;
        }
        else
        {
            enemyDEF = enemy.GetComponent<EnemyUnitManager>().EnemyUnit.GetComponent<Status>().DEF;

        }

        maxMP = player.GetComponent<PlayerUnitManager>().PlayerUnit.GetComponent<Status>().max_MP;
        genMP = player.GetComponent<PlayerUnitManager>().PlayerUnit.GetComponent<Status>().gen_MP;

        while (true)
        {
            if (playerAD != 0)
                damage = playerAD - enemyDEF;
            else
                damage = playerAP = enemyRES;
            enemy.GetComponent<EnemyUnitManager>().EnemyUnit.GetComponent<Status>().HP -= damage;
            DamageText.transform.GetChild(0).GetComponent<ShowDamage>().TakeDamage(damage);

            // 매 공격마다 정해진 수치만큼 마나 회복
            if (maxMP - player.GetComponent<PlayerUnitManager>().PlayerUnit.GetComponent<Status>().MP >= genMP)
                player.GetComponent<PlayerUnitManager>().PlayerUnit.GetComponent<Status>().MP += genMP;
            else
                player.GetComponent<PlayerUnitManager>().PlayerUnit.GetComponent<Status>().MP =maxMP;


            // 적 유닛에게 데미지를 준 이후 적 유닛이 사망하면
            // 1 대 1 슬롯 중 적 유닛 슬롯을 다음 적 유닛으로 교체 후 플래그를 이용해 Update에 의해 enemyAttack 코루틴 중단(이후 재시작).
            // 다음 적 유닛이 없다면 코루틴 즉시 중단.
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
                    // 적 유닛 사망 후 남은 적 유닛이 없을 경우 승리
                    StopCoroutine("PlayerAttack");
                    StopCoroutine("EnemyAttack");
                    Canvas.transform.GetChild(4).gameObject.SetActive(true);
                    Canvas.transform.GetChild(4).GetChild(1).gameObject.GetComponent<Text>().text = "승리";
                    Canvas.transform.GetChild(4).GetChild(2).gameObject.SetActive(true);
                }
            }
            yield return new WaitForSeconds(playerAttackCool);
        }
    }
    IEnumerator EnemyAttack()
    {
        int damage, playerDEF, playerRES, enemyAD, enemyAP;
        damage = playerDEF = playerRES = enemyAP = enemyAP = 0;

        enemyAD = enemy.GetComponent<EnemyUnitManager>().EnemyUnit.GetComponent<Status>().AD;
        if (enemyAD == 0)
        {
            enemyAP = enemy.GetComponent<EnemyUnitManager>().EnemyUnit.GetComponent<Status>().AP;
            playerRES = player.GetComponent<PlayerUnitManager>().PlayerUnit.GetComponent<Status>().RES;
        }
        else
        {
            playerDEF = player.GetComponent<PlayerUnitManager>().PlayerUnit.GetComponent<Status>().DEF;

        }
        while (true)
        {
            if (enemyAD != 0)
                damage = enemyAD - playerDEF;
            else
                damage = enemyAP - playerRES;
            player.GetComponent<PlayerUnitManager>().PlayerUnit.GetComponent<Status>().HP -= damage;
            DamageText.transform.GetChild(1).GetComponent<ShowDamage>().TakeDamage(damage);
            if (player.GetComponent<PlayerUnitManager>().PlayerUnit.GetComponent<Status>().HP <= 0)
            {
                StopCoroutine("PlayerAttack");
                StopCoroutine("EnemyAttack");
                Canvas.transform.GetChild(4).gameObject.SetActive(true);
                Canvas.transform.GetChild(4).GetChild(1).gameObject.GetComponent<Text>().text = "패배";
                Canvas.transform.GetChild(4).GetChild(3).gameObject.SetActive(true);
            }
            yield return new WaitForSeconds(enemyAttackCool);
        }
    } 
}
