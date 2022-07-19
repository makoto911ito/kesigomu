using UnityEngine;

/// <summary>
/// 力の方向を示す矢を制御するコンポーネント
/// TODO: パワーを決めるフェーズでも矢が動かせるので止めるべき。(Done)
/// </summary>
public class ArrowController : MonoBehaviour
{
    /// <summary>プレイヤーオブジェクト</summary>
    [SerializeField] GameObject _player;
    /// <summary>Raycast のレイヤーマスク</summary>
    [SerializeField] LayerMask _layerMask;
    /// <summary>Raycast の距離</summary>
    [SerializeField] float _raycastDistance = 20f;
    /// <summary>矢をプレイヤーからいくら離して表示するか</summary>
    [SerializeField] float _distanceFromPlayer = 1.5f;
    /// <summary>矢をプレイヤーからどれくらい上に表示するか</summary>
    [SerializeField] float _offsetY = 0.01f;

    bool _isStop = false;

    /// <summary>プレイヤーの GameObject</summary>
    public GameObject Player
    {
        set { _player = value; }
    }

    /// <summary>
    /// 方向を決めたらパワーを決めるフェーズの際にArrowが動かないようにする
    /// </summary>
    public void Stop()
    {
        _isStop = true;
    }

    void Update()
    {
        if (!_player) return;
        if (_isStop) return;

        // マウスの位置の方向に矢印を向ける
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, _raycastDistance, _layerMask))
        {
            var dir = (hit.point - _player.transform.position).normalized;
            transform.position = dir * _distanceFromPlayer + _player.transform.position + Vector3.up * _offsetY;
            transform.forward = dir;
        }
    }
}
