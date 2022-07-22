using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Standby : MonoBehaviour
{
    [SerializeField] Text playersName = null;
    [SerializeField] Text memberText = null;
    [SerializeField] Text waitText = null;//�ҋ@���\������
    [SerializeField] Text back = null; //�߂�{�^�� �܂�
    [SerializeField] GameObject wait = null;
    bool waitFlag = false; //�ҋ@��ʂ�\�����邩�ۂ�
    float time = 0; //�_�ő��x
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
        memberText.text = "�ҋ@���̃v���C���[\n" + pl.Length +"/" + sp.Length;
        playersName.text += "Player" + pl[pl.Length + 1] + ":" + pl[pl.Length].name + "\n";

        //�v���C���[���X�|�[���|�C���g���ɖ����Ȃ��ꍇ
        if (pl.Length == sp.Length) waitFlag = false;
        else
        {
            waitFlag = true;
            waitText.text = "�ҋ@��...";
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
