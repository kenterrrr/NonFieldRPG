using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public new string name;
    public int hp;
    public int at;

    // �U������
    public void Attack(PlayerManager player)
    {
        player.Damage(at);
    }

    // �_���[�W���󂯂�
    public void Damage(int damage)
    {
        hp -= damage;
        Debug.Log("�G�l�~�[��HP��" + hp);
    }

    public void OnTap()
    {
        Debug.Log("�N���b�N���ꂽ");
    }
}
