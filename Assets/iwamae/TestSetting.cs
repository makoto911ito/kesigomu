using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// �v���C���[�̖��O���Ăяo���g�p��
/// </summary>
public class TestSetting : MonoBehaviour
{
    [Tooltip("�v���C���[�̖��O�̃e�L�X�g")]
    [SerializeField] Text _playername = default;

    void Start()
    {
        _playername.text = PlayerNameInput._playerNameStr;
    }
}
