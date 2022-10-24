using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System;

public class Standby : MonoBehaviour
{
    [SerializeField] Text numberText = null;
    [SerializeField] Text waitText = null;//�ҋ@���\������
    [SerializeField] Text back = null;
    bool waitFlag = false; //�ҋ@��ʂ�\�����邩�ۂ�
    float time = 0; //�_�ő��x
    [SerializeField] List<GameObject> sp = new List<GameObject>();
    [SerializeField] GameObject[] pl;
    [SerializeField] int plNum = 0; //�ȑO�̃v���C���[��



    void Update()
    {
        pl = GameObject.FindGameObjectsWithTag("Player");
        Func<int, int, string> nowText = (ply, spl) => { return ply + "�l / " + spl + "�l��"; }; //���݂̐l����
            numberText.text = $"{nowText(pl.Length, sp.Count)}";

        

        time += Time.deltaTime;

        //�v���C���[���X�|�[���|�C���g���ɖ����Ȃ��ꍇ
        if (pl.Length == sp.Count) waitFlag = true;
        else
        {
            waitFlag = false;
            waitText.text = "�ҋ@��...";
        }

        //�ҋ@�����̓_��
        var alpha = Mathf.Cos(2 * Mathf.PI * time / 2) * 0.5f + 0.5f;
        var color = waitText.color;
        color.a = alpha;
        waitText.color = color;
        if(waitFlag == true)
        {
            Destroy(this.gameObject);
        }
    }
}
