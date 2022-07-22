using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Standby : MonoBehaviour
{
    [SerializeField] Text playerName = null; //�ҋ@���v���C���[�\��
    [SerializeField] string[] waitPlayer = null;
    [SerializeField] Text waitText = null;//�ҋ@���\������
    [SerializeField] Text back = null; //�߂�{�^�� �܂�
    [SerializeField] GameObject wait = null;
    bool waitFlag = false; //�ҋ@��ʂ�\�����邩�ۂ�
    float time = 0; //�_�ő��x
    int playerCount = 0;
    void Start()
    {
        wait = GetComponent<GameObject>();
    }


    void Update()
    {
        time += Time.deltaTime;

        //�X�|�[���|�C���g�̐���Max�Ƃ���
        GameObject[] sp = GameObject.FindGameObjectsWithTag("Untagged");
        GameObject[] pl = GameObject.FindGameObjectsWithTag("Player");
        if (playerCount < sp.Length - 1) //�v���C���[���X�|�[���|�C���g���ɖ����Ȃ��ꍇ
        {
            waitFlag = true;
            waitText.text = "�ҋ@��...";
            playerName.text = PlayerNameInput._playerNameStr;
        }
        else
        {
            waitText = null;
            waitFlag = false;
        }

        //�ҋ@�����̓_��
        var alpha = Mathf.Cos(2 * Mathf.PI * time / 2) * 0.5f + 0.5f;
        var color = waitText.color;
        color.a = alpha;
        waitText.color = color;

        if(waitFlag == false)
        {
            Destroy(wait);
        }

        //public void ChangeScene(Scene scene) => SceneManager.LoadScene("Title");
    }
}
