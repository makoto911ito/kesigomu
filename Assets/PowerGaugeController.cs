using System.Collections;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// パワーゲージを制御するコンポーネント
/// 適当なオブジェクトにアタッチして使う。
/// </summary>
public class PowerGaugeController : MonoBehaviour
{
    /// <summary>パワーゲージとなる Slider</summary>
    [SerializeField] Slider _powerGauge = default;
    /// <summary>ゲージが上下する速度</summary>
    [SerializeField] float _gaugeSpeed = 3;
    Coroutine _coroutine = default;

    /// <summary>
    /// ゲージを動かす時に呼ぶ。
    /// </summary>
    public void StartGauge()
    {
        _coroutine = StartCoroutine(PingPongGauge());
    }

    /// <summary>
    /// ゲージを止める時に呼ぶ。ゲージの値を戻り値として返す。
    /// 得られるパワーは Slider.value になるため、パワーの値を調節したい場合は Slider の Min Value/Max Value でも調整できる。
    /// </summary>
    public float StopGauge()
    {
        StopCoroutine(_coroutine);
        _coroutine = null;
        Debug.Log($"Power value: {_powerGauge.value}");
        return _powerGauge.value;
    }

    /// <summary>
    /// ゲージを上下させる。
    /// </summary>
    /// <returns></returns>
    IEnumerator PingPongGauge()
    {
        float timer = 0;

        while (true)
        {
            _powerGauge.value = Mathf.PingPong(_gaugeSpeed * timer, _powerGauge.maxValue);
            timer += Time.deltaTime;    // 放置しておくといずれオーバーフローする。「制限時間を設けて強制的に押した事にする」機能を後で加えることになるだろうからこのままにしておく。
            yield return new WaitForEndOfFrame();
        }
    }
}