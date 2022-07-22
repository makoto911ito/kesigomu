using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Standby : MonoBehaviour
{
    [SerializeField] Text waitPlayer = null; //�ҋ@���v���C���[�\��
    [SerializeField] Text waitText = null;//�ҋ@���\������
    [SerializeField] Text back = null; //�߂�{�^�� �܂�
    [SerializeField] GameObject wait = null;
    bool waitFlag = false; //�ҋ@��ʂ�\�����邩�ۂ�
    float time = 0;
    int playerCount = 0;
    void Start()
    {
        
    }


    void Update()
    {
        time += Time.deltaTime;
        //if()
        wait = GetComponent<GameObject>();

        //�ҋ@�����̓_��
        var alpha = Mathf.Cos(2 * Mathf.PI * time / 2) * 0.5f + 0.5f;
        var color = waitText.color;
        color.a = alpha;
        waitText.color = color;

        //if (playerCount < NetworkGameManagerTurnBased._maxPlayers) //Player�^�O��Obj�̐���Max�ɖ����Ȃ��ꍇ
        //{
        //    waitFlag = true;
        //    waitText.text = "�ҋ@��...";
        //    waitPlayer.text = PlayerNameInput._playerNameStr;
        //}
        //else
        //{
        //    waitText = null;
        //    waitFlag = false;
        //}

        //public void ChangeScene(Scene scene) => SceneManager.LoadScene("Title");
    }
}
