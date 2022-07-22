using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �v���C���[�����������ǂ����𔻒肷��R���|�[�l���g
/// </summary>
public class PlayerDeath : MonoBehaviour
{
    [SerializeField] int _deadZone = -10;

    private void Update()
    {
        if (this.gameObject.transform.position.y < _deadZone)
        {
            this.gameObject.SetActive(false);
        }
    }
}
