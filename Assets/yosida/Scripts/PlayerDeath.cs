using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤーが落ちたかどうかを判定するコンポーネント
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
