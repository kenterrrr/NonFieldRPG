using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �N�G�X�g�S�̂��Ǘ�
public class QuestManager : MonoBehaviour
{
    public StageUIManager stageUI;
    public GameObject enemyPrefab;

    int[] encountTable = { -1, -1, 0, -1, 0, -1 };

    int currentStage = 0;  // ���݂̃X�e�[�W

    private void Start()
    {
        stageUI.UpdateUI(currentStage);
    }

    public void OnNextButton()
    {
        currentStage++;

        // �i�s�x��UI�ɔ��f
        stageUI.UpdateUI(currentStage);

        if (encountTable.Length <= currentStage)
        {
            Debug.Log("�N�G�X�g�N���A");
        }
        else if(encountTable[currentStage] == 0)
        {
            EncountEnemy();
        }
    }

    void EncountEnemy()
    {
        stageUI.DisplayButton(false);
        Instantiate(enemyPrefab);
    }
}
