using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �N�G�X�g�S�̂��Ǘ�
public class QuestManager : MonoBehaviour
{
    int currentStage = 0;  // ���݂̃X�e�[�W

    public void OnNextButton()
    {
        currentStage++;
        Debug.Log("�i�s" + currentStage);
    }
}