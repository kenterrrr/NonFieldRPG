using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BattleManager : MonoBehaviour
{
    public Transform cameraObj;
    public QuestManager questManager;
    public PlayerUIManager playerUI;
    public EnemyUIManager enemyUI;
    public PlayerManager player;
    public EnemyManager enemy;

    private void Start()
    {
        enemyUI.gameObject.SetActive(false);
        //StartCoroutine(SampleCol());
    }

    // サンプルコルーチン
    /*
    IEnumerator SampleCol()
    {
        Debug.Log("コルーチン開始");
        yield return new WaitForSeconds(2);
        Debug.Log("2秒経過");
    }
    */

    public void Setup(EnemyManager enemyManager)
    {
        SoundManager.instance.PlayBGM(SoundManager.BATTLE);
        enemyUI.gameObject.SetActive(true);
        enemy = enemyManager;
        playerUI.SetupUI(player);
        enemyUI.SetupUI(enemy);

        enemy.AddEventListenerOnTap(PlayerAttack);
        //enemy.transform.DOMove(new Vector3(0, 10, 0), 5f);
    }

    void PlayerAttack()
    {
        StopAllCoroutines();
        SoundManager.instance.PlaySE(1);
        player.Attack(enemy);
        enemyUI.UpdateUI(enemy);
        if(enemy.hp <= 0)
        {
            StartCoroutine(EndBattle());
        } 
        else
        {
            StartCoroutine(EnemyTurn());
        }
    }

    IEnumerator EnemyTurn()
    {
        yield return new WaitForSeconds(1f);
        SoundManager.instance.PlaySE(1);
        cameraObj.DOShakePosition(0.3f, 0.5f, 20, 0);
        enemy.Attack(player);
        playerUI.UpdateUI(player);
    }

    IEnumerator EndBattle()
    {
        yield return new WaitForSeconds(1f);

        SoundManager.instance.PlayBGM(SoundManager.QUEST);
        Destroy(enemy.gameObject);
        enemyUI.gameObject.SetActive(false);
        questManager.EndBattle();
    }
}
