using UniRx;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
using System.Collections;
using GameDevelopment.Common.Datas;

namespace GameDevelopment.Scenes.CompanyScenes.UI.OfficeHUDs.DevelopmentUIs.GameSoftDevUIs.HouseDevUIs
{

    /// <summary>
    /// 開発するゲームソフトのゲームハードを選択するUI
    /// </summary>
    public class SelectGameHardUI : NewBehaviour
    {
        /// <summary>
        /// 移動量
        /// </summary>
        private const int MoveDistance = 500;

        /// <summary>
        /// 移動に掛かる時間
        /// </summary>
        private const float MoveTime = 0.35f;

        /// <summary>
        /// 自社開発UI
        /// </summary>
        [SerializeField]
        private HouseDevUI _houseDevUI = default;

        /// <summary>
        /// Content
        /// </summary>
        [SerializeField]
        private GameObject _content = default;

        /// <summary>
        /// 右に移動するボタン
        /// </summary>
        [SerializeField]
        private Button _rightButton = default;

        /// <summary>
        /// 左に移動するボタン
        /// </summary>
        [SerializeField]
        private Button _leftButton = default;

        /// <summary>
        /// 戻るボタン
        /// </summary>
        [SerializeField]
        private Button _returnButton = default;

        /// <summary>
        /// OKボタン
        /// </summary>
        [SerializeField]
        private Button _okButton = default;

        /// <summary>
        /// コルーチンを止めるため
        /// </summary>
        private IDisposable _coroutineDisposable = default;

        /// <summary>
        /// ゲームハードの情報が記載されているUIのリスト
        /// </summary>
        private List<GameHardInfoUI> _gameHardList = new List<GameHardInfoUI>();

        /// <summary>
        /// ContentのRect
        /// </summary>
        private RectTransform _contentRect = default;

        /// <summary>
        /// 選択中のハード
        /// </summary>
        private int _selectHard = 0;

        /// <summary>
        /// 現在移動中か？
        /// </summary>
        private bool _isMoving = false;

        /// <summary>
        /// Start
        /// </summary>
        private void Start()
        {
            // 右ボタン押下時
            // 移動できるなら...
            // 右に移動する
            _rightButton
                .OnClickAsObservable()
                .Where(_ => IsMovingRight())
                .Subscribe(_ => MoveRight())
                .AddTo(this);

            // 左ボタン押下時
            // 移動できるなら...
            // 左に移動する
            _leftButton
                .OnClickAsObservable()
                .Where(_ => IsMovingLeft())
                .Subscribe(_ => MoveLeft())
                .AddTo(this);

            // 戻るボタン押下時
            // 前の画面に戻る
            _returnButton
                .OnClickAsObservable()
                .Subscribe(_ =>
                {
                    if (_coroutineDisposable != null) { _coroutineDisposable.Dispose(); }
                    _houseDevUI.DisplayCreateGameSoftUI();
                })
                .AddTo(this);

            // 決定ボタン押下時
            // ハードを選択し、前の画面に戻る
            _okButton
                .OnClickAsObservable()
                .Subscribe(_ =>
                {
                    if (_coroutineDisposable != null) { _coroutineDisposable.Dispose(); }
                    _houseDevUI.GameSoft.Hard = GameInfo.Industry.Hards[_selectHard];
                    _houseDevUI.DisplayCreateGameSoftUI();
                })
                .AddTo(this);
        }


        /// <summary>
        /// ゲームオブジェクト表示時
        /// </summary>
        private void OnEnable()
        {
            Initialized();
            CreateHardList();
        }

        /// <summary>
        /// 初期化
        /// </summary>
        private void Initialized()
        {
            _contentRect = _content.GetComponent<RectTransform>();
            _contentRect.localPosition = Vector3.zero;
            _coroutineDisposable = default;
            _selectHard = 0;
            _isMoving = false;
        }

        /// <summary>
        /// ゲームハードリストを作成
        /// </summary>
        private void CreateHardList()
        {
            // 業界で販売されているハードだけ選択肢に表示
            foreach (var hard in GameInfo.Industry.Hards)
            {
                // 選択肢として既に生成済みなら処理を返す
                if (IsSameHardName(hard.Name)) { continue; }

                // 選択肢を生成
                // リストに格納
                var prefab = Instantiate(Resources.Load($"{PathData.SelectGameHard}"), _content.transform) as GameObject;
                var gameInfoUI = prefab.GetComponent<GameHardInfoUI>();
                gameInfoUI.Initialized(hard);
                _gameHardList.Add(gameInfoUI);
            }
        }

        /// <summary>
        /// 同じ名前のゲームハードがあるか？
        /// </summary>
        /// <remarks>
        /// TRUE:  同じ名前のゲームハードがあった
        /// FALSE: 無かった
        /// </remarks>
        /// <param name="name">ゲームハードの名前</param>
        /// <returns></returns>
        private bool IsSameHardName(string name)
        {
            for (int i = 0; i < _gameHardList.Count; i++)
            {
                if (_gameHardList[i].Name == name)
                {
                    return true;
                }
            }
            return false;
        }

        #region 移動処理

        /// <summary>
        /// 右に移動
        /// </summary>
        private void MoveRight()
        {
            // コルーチン内で yield return null しか利用できないとう制約がある代わりに、
            // Unity標準のコルーチンと比べ非常に高速に起動し動作する仕組み「マイクロコルーチン」を使用している。
            _coroutineDisposable = Observable.FromMicroCoroutine(_ => MoveRightCoroutine())
                                           .Subscribe()
                                           .AddTo(this);
        }

        /// <summary>
        /// 左に移動
        /// </summary>
        private void MoveLeft()
        {
            // コルーチン内で yield return null しか利用できないとう制約がある代わりに、
            // Unity標準のコルーチンと比べ非常に高速に起動し動作する仕組み「マイクロコルーチン」を使用している。
            _coroutineDisposable = Observable.FromMicroCoroutine(_ => MoveLeftCoroutine())
                                           .Subscribe()
                                           .AddTo(this);
        }

        /// <summary>
        /// 右に移動できるか？
        /// </summary>
        /// <remarks>
        /// TRUE:  移動できる
        /// FALSE: 移動できない
        /// </remarks>
        /// <returns></returns>
        private bool IsMovingRight()
        {
            // 既に移動中ならfalse
            // これ以上右に行けないならfalse
            if (_isMoving) { return false; }
            if (_selectHard >= _gameHardList.Count - 1) { return false; }

            return true;
        }

        /// <summary>
        /// 左に移動できるか？
        /// </summary>
        /// <remarks>
        /// TRUE:  移動できる
        /// FALSE: 移動できない
        /// </remarks>
        /// <returns></returns>
        private bool IsMovingLeft()
        {
            // 既に移動中ならfalse
            // これ以上左に行けないならfalse
            if (_isMoving) { return false; }
            if (_selectHard <= 0) { return false; }

            return true;

        }

        /// <summary>
        /// 右に移動するコルーチン
        /// </summary>
        /// <returns></returns>
        private IEnumerator MoveRightCoroutine()
        {
            var startTime = Time.timeSinceLevelLoad;
            var startPos = _content.transform.localPosition;
            var endPos = startPos - new Vector3(MoveDistance, 0f, 0f);
            _isMoving = true;

            while (true)
            {
                var diff = Time.timeSinceLevelLoad - startTime;
                var rate = diff / MoveTime;
                _contentRect.localPosition = Vector3.Lerp(startPos, endPos, rate);

                if (rate >= 1f) { break; }
                yield return null;
            }

            ++_selectHard;
            _isMoving = false;
        }

        /// <summary>
        /// 左に移動するコルーチン
        /// </summary>
        /// <returns></returns>
        private IEnumerator MoveLeftCoroutine()
        {
            var startTime = Time.timeSinceLevelLoad;
            var startPos = _content.transform.localPosition;
            var endPos = startPos + new Vector3(MoveDistance, 0f, 0f);
            _isMoving = true;

            while (true)
            {
                var diff = Time.timeSinceLevelLoad - startTime;
                var rate = diff / MoveTime;
                _contentRect.localPosition = Vector3.Lerp(startPos, endPos, rate);

                if (rate >= 1f) { break; }
                yield return null;
            }

            --_selectHard;
            _isMoving = false;
        }

        #endregion
    }
}