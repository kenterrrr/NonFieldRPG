using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �N�G�X�g�S�̂��Ǘ�
public class QuestManager : MonoBehaviour
{
    public StageUIManager stageUI;
    public GameObject enemyPrefab;
    public BattleManager battleManager;
    public SceneTransitionManager sceneTransitionManager;

    int[] encountTable = { -1, -1, 0, -1, 0, -1 };

    int currentStage = 0;  // ���݂̃X�e�[�W

    private void Start()
    {
        stageUI.UpdateUI(currentStage);
    }

    public void OnNextButton()
    {
        SoundManager.instance.PlaySE(0);
        currentStage++;

        // �i�s�x��UI�ɔ��f
        stageUI.UpdateUI(currentStage);

        if (encountTable.Length <= currentStage)
        {
            Debug.Log("�N�G�X�g�N���A");
            QuestClear();
        }
        else if(encountTable[currentStage] == 0)
        {
            EncountEnemy();
        }
    }

    public void OnToTownButton()
    {
        SoundManager.instance.PlaySE(0);
    }

    void EncountEnemy()
    {
        stageUI.DisplayButton(false);
        GameObject enemyObj = Instantiate(enemyPrefab);
        EnemyManager enemy = enemyObj.GetComponent<EnemyManager>();
        battleManager.Setup(enemy);
    }

    public void EndBattle()
    {
        stageUI.DisplayButton(true);
    }

    void QuestClear()
    {
        SoundManager.instance.StopBGM();
        SoundManager.instance.PlaySE(2);
        stageUI.DisplayClearText();
        //sceneTransitionManager.LoadTo("Town");
    }
}
