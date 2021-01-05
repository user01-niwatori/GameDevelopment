using UnityEngine;
using UniRx;
using System;
using RotaryHeart.Lib.SerializableDictionary;
using System.Collections;
using UniRx.Triggers;

#region Enum

/// <summary>
/// サウンドのスイッチ
/// </summary>
public enum SoundSwitch
{
    On,
    Off,
};

/// <summary>
/// BGMの名前
/// </summary>
public enum BgmName
{
    None,
    Title,
    Main,
};

/// <summary>
/// SEの名前
/// </summary>
public enum SeName
{
    None,
    Ok,
    Cancel,
};

#endregion

#region DictionayClass

/// <summary>
/// DictionaryのBGMの型
/// </summary>
/// <remarks>
/// inspector上で表示できるようにするためにはこの型を使用する
/// </remarks>
[System.Serializable]
public class BGMDictionary : SerializableDictionaryBase<BgmName, AudioClip> { }

/// <summary>
/// DictionaryのSEの型
/// </summary>
/// <remarks>
/// inspector上で表示できるようにするためにはこの型を使用する
/// </remarks>
[System.Serializable]
public class SEDictionary : SerializableDictionaryBase<SeName, AudioClip> { }

#endregion

/// <summary>
/// オーディオ管理クラス
/// </summary>
public class AudioManager : SingletonMonoBehaviour<AudioManager>
{
    /// <summary>
    /// BgmNameのデフォルトボリューム
    /// </summary>
    private const float DefaultBgmVolume = 1.0f;

    /// <summary>
    /// SEのデフォルトボリューム
    /// </summary>
    private const float DefaultSeVolume = 1.0f;

    /// <summary>
    /// BGM再生オブジェクト
    /// </summary>
    [SerializeField]
    private AudioSource _bgmSource = default;

    /// <summary>
    /// SE再生オブジェクト
    /// </summary>
    [SerializeField]
    private AudioSource _seSource = default;

    /// <summary>
    /// BGM一覧
    /// </summary>
    [SerializeField]
    private BGMDictionary _bgmDictionary = new BGMDictionary();

    /// <summary>
    /// SE一覧
    /// </summary>
    [SerializeField]
    private SEDictionary _seDictionary = new SEDictionary();

    /// <summary>
    /// 次に再生するBGMの名前
    /// </summary>
    private BgmName _nextBgmName = BgmName.None;

    /// <summary>
    /// 次に再生するSEの名前
    /// </summary>
    private SeName _nextSeName = SeName.None;

    /// <summary>
    /// 現在再生中のBGMの名前
    /// </summary>
    private BgmName _currentBgmName = BgmName.None;

    /// <summary>
    /// BGMのスイッチ(On/Off)
    /// </summary>
    private SoundSwitch _bgmSwitch = SoundSwitch.On;

    /// <summary>
    /// SEのスイッチ(On/Off)
    /// </summary>
    private SoundSwitch _seSwitch = SoundSwitch.On;

    /// <summary>
    /// PlaySECoroutine()メソッドを格納する変数
    /// </summary>
    /// <remarks>
    /// この変数を用いる事で、コルーチンを完全に止める事が出来るようになる。
    /// </remarks>
    private IEnumerator _playSECorountine = default;

    /// <summary>
    /// BGMフェードアウト中か？
    /// </summary>
    /// <remarks>
    /// TRUE:  フェードアウト中
    /// FALSE: フェードアウト中ではない
    /// </remarks>
    private BoolReactiveProperty _isFadeOut = new BoolReactiveProperty(false);

    /// <summary>
    /// BGMをフェードアウトさせるのにかかる秒数
    /// </summary>
    private float _bgmFadeOutSeconds = 0.5f;

    /// <summary>
    /// フェードアウトが終了していたらイベントを発行する
    /// </summary>
    public IObservable<Unit> OnFadeOutFinished
    {
        get
        {
            if (!_isFadeOut.Value) return Observable.Return(Unit.Default);
            return _isFadeOut.FirstOrDefault(x => !x).AsUnitObservable();
        }
    }

    /// <summary>
    /// Start
    /// </summary>
    private void Start()
    {
        // _isFadeOutがTrueなら...
        // FadeOutBgm処理へ
        this.UpdateAsObservable()
            .Where(_ => _isFadeOut.Value)
            .Subscribe(_ =>
            {
                FadeOutBgm();
            });
    }

    //======================================================================
    // SE
    //======================================================================

    /// <summary>
    /// 指定したファイル名のSEを流す処理
    /// </summary>
    /// <param name="seName">再生するSEの名前</param>
    public void PlaySE(SeName seName)
    {
        if (!IsPlaySE()) { return; }

        if (!_seDictionary.ContainsKey(seName))
        {
            Debug.LogError(seName + "という名前のSEがありません");
            return;
        }

        _seSource.PlayOneShot(_seDictionary[seName] as AudioClip);
    }


    /// <summary>
    /// 指定したファイル名のSEを流す処理 (非同期再生)
    /// </summary>
    /// <param name="seName">再生するSEの名前</param>
    /// <param name="delay">指定した時間だけ再生までの間隔を開ける</param>
    public void PlaySE(SeName seName, float delay)
    {
        if (!IsPlaySE()) { return; }

        if (!_seDictionary.ContainsKey(seName))
        {
            Debug.LogError(seName + "という名前のSEがありません");
            return;
        }

        _playSECorountine = PlaySECoroutine(delay);
        StartCoroutine(_playSECorountine);
    }

    /// <summary>
    /// SEを再生させるコルーチン
    /// </summary>
    /// <returns></returns>
    private IEnumerator PlaySECoroutine(float delay)
    {
        yield return new WaitForSeconds(delay);
        _seSource.PlayOneShot(_seDictionary[_nextSeName] as AudioClip);
        yield break;
    }

    /// <summary>
    /// 再生中のSEを停止する。
    /// </summary>
    public void StopSE()
    {
        // SEが非同期再生中なら非同期処理を終了する。
        if (_playSECorountine != null)
        {
            StopCoroutine(_playSECorountine);
            _playSECorountine = default;
        }

        _seSource.Stop();
        _seSource.clip = null;
        _nextSeName = SeName.None;
    }

    /// <summary>
    /// SE再生の可否を設定
    /// </summary>
    public void SetSESwitch(SoundSwitch seSwitch)
    {
        _seSwitch = seSwitch;
    }

    /// <summary>
    /// SE再生できるか？
    /// </summary>
    　　/// <remarks>
    /// TRUE:  再生できる
    /// FALSE: 再生できない
    /// </remarks>
    /// <returns></returns>
    public bool IsPlaySE()
    {
        if (_seSwitch == SoundSwitch.On) { return true; }
        return false;
    }

    //======================================================================
    // BGM
    //======================================================================

    /// <summary>
    /// 指定したファイル名のBGMを流す。
    /// </summary>
    /// <param name="bgmName">再生するBGMの名前</param>
    public void PlayBGM(BgmName bgmName)
    {
        if (!IsPlayBGM()) { return; }

        if (!_bgmDictionary.ContainsKey(bgmName))
        {
            Debug.Log(bgmName + "という名前のBGMがありません");
            return;
        }

        _bgmSource.clip = _bgmDictionary[bgmName] as AudioClip;
        _currentBgmName = bgmName;
        _bgmSource.Play();
    }

    /// <summary>
    /// 指定したファイル名のBGMを流す。
    /// ただしすでに流れている場合はフェードアウトさせてから。
    /// </summary>
    /// <param name="bgmName">再生するBGMの名前</param>
    /// <param name="fadeOutSeconds">指定した秒数でフェードアウトが終了する</param>
    public void PlayBGM(BgmName bgmName, float fadeOutSeconds)
    {
        if (!IsPlayBGM()) { return; }

        if (!_bgmDictionary.ContainsKey(bgmName))
        {
            Debug.Log(bgmName + "という名前のBGMがありません");
            return;
        }

        // 現在のBGMが流れていないときはそのまま流す。
        // 違うBGMが流れているときは、流れているBGMをフェードアウトさせてから
        // 次を流す。同じBGMが流れているときはスルー
        if (!_bgmSource.isPlaying)
        {
            _bgmSource.clip = _bgmDictionary[bgmName] as AudioClip;
            _currentBgmName = bgmName;
            _bgmSource.Play();
        }
        else if (_bgmSource.clip.name != bgmName.ToString())
        {
            _nextBgmName = bgmName;
            _bgmFadeOutSeconds = fadeOutSeconds;
            _isFadeOut.Value = true;
        }
    }

    /// <summary>
    /// フェードアウト処理
    /// </summary>
    private void FadeOutBgm()
    {
        // 徐々にボリュームを下げていき
        // ボリュームが０になったらボリュームを戻し、次の曲を再生させる。
        _bgmSource.volume -= Time.deltaTime * _bgmFadeOutSeconds;
        if (_bgmSource.volume <= 0)
        {
            _bgmSource.Stop();
            _bgmSource.volume = DefaultBgmVolume;
            _isFadeOut.Value = false;

            if (!string.IsNullOrEmpty(_nextBgmName.ToString()))
            {
                PlayBGM(_nextBgmName);
            }
        }
    }

    /// <summary>
    /// 再生中のSEを停止する。
    /// </summary>
    public void StopBGM()
    {
        _bgmSource.Stop();
        _bgmSource.clip = null;
        _nextBgmName = BgmName.None;
    }

    /// <summary>
    /// BGM再生の可否を設定
    /// </summary>
    public void SetBGMSwitch(SoundSwitch bgmSwitch)
    {
        _bgmSwitch = bgmSwitch;
    }

    /// <summary>
    /// BGM再生できるか？
    /// </summary>
    /// <remarks>
    /// TRUE:  再生できる
    /// FALSE: 再生できない
    /// </remarks>
    /// <returns></returns>
    private bool IsPlayBGM()
    {
        if (!_isFadeOut.Value || _bgmSwitch == SoundSwitch.On)
        {
            return true;
        }
        return false;
    }
}