using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// クエスト全体を管理
public class QuestManager : MonoBehaviour
{
    int currentStage = 0;  // 現在のステージ

    public void OnNextButton()
    {
        currentStage++;
        Debug.Log("進行" + currentStage);
    }
}
