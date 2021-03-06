using System;
using UnityEngine;
using DG.Tweening;

public class EnemyManager : MonoBehaviour
{
    // 関数登録
    Action tapAction; // クリックされた時に実行したい関数（外部から設定）

    public new string name;
    public int hp;
    public int at;

    // 攻撃する
    public void Attack(PlayerManager player)
    {
        player.Damage(at);
    }

    // ダメージを受ける
    public void Damage(int damage)
    {
        transform.DOShakePosition(0.3f , 0.5f, 20, 0);
        hp -= damage;
        if(hp <= 0)
        {
            hp = 0;
        }
    }

    // tapActionに関数を登録する関数
    public void AddEventListenerOnTap(Action action)
    {
        tapAction += action;
    }

    public void OnTap()
    {
        Debug.Log("クリックされた");
        tapAction();
    }
}
