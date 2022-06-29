using UnityEngine;

/// <summary>
/// �͂̕�����������𐧌䂷��R���|�[�l���g
/// TODO: �p���[�����߂�t�F�[�Y�ł����������̂Ŏ~�߂�ׂ��B
/// </summary>
public class ArrowController : MonoBehaviour
{
    /// <summary>�v���C���[�I�u�W�F�N�g</summary>
    [SerializeField] GameObject _player;
    /// <summary>Raycast �̃��C���[�}�X�N</summary>
    [SerializeField] LayerMask _layerMask;
    /// <summary>Raycast �̋���</summary>
    [SerializeField] float _raycastDistance = 20f;
    /// <summary>����v���C���[���炢���痣���ĕ\�����邩</summary>
    [SerializeField] float _distanceFromPlayer = 1.5f;
    /// <summary>����v���C���[����ǂꂭ�炢��ɕ\�����邩</summary>
    [SerializeField] float _offsetY = 0.01f;

    /// <summary>�v���C���[�� GameObject</summary>
    public GameObject Player
    {
        set { _player = value; }
    }

    void Update()
    {
        if (!_player) return;

        // �}�E�X�̈ʒu�̕����ɖ���������
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, _raycastDistance, _layerMask))
        {
            var dir = (hit.point - _player.transform.position).normalized;
            transform.position = dir * _distanceFromPlayer + _player.transform.position + Vector3.up * _offsetY;
            transform.forward = dir;
        }
    }
}
