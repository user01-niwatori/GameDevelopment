using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;
using GameDevelopment.Common.Datas;

namespace GameDevelopment.Scenes.CompanyScenes.UI.OfficeHUDs.DevelopmentUIs.GameSoftDevUIs.HouseDevUIs
{
    /// <summary>
    /// 移動方向
    /// </summary>
    enum EMoveDir
    {
        Left,
        Right,
        Up,
        Down,
    }

    /// <summary>
    /// 開発するゲームソフトのゲームハードを選択するUI
    /// </summary>
    public class SelectGameHardUI : BehaviourEnabled
    {
        /// <summary>
        /// 移動量
        /// </summary>
        private const int MoveDistance = 500;

        /// <summary>
        /// 移動に掛かる時間
        /// </summary>
        private const float MoveTime = 0.4f;

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
        /// UniTaskのキャンセルを行うためのトークン
        /// </summary>
        private CancellationTokenSource _cts = default;

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
                .Subscribe(_ => HorizontalMoveAsync(EMoveDir.Right, _cts.Token).Forget())
                .AddTo(this);

            // 左ボタン押下時
            // 移動できるなら...
            // 左に移動する
            _leftButton
                .OnClickAsObservable()
                .Where(_ => IsMovingLeft())
                .Subscribe(_ => HorizontalMoveAsync(EMoveDir.Left, _cts.Token).Forget())
                .AddTo(this);

            // 戻るボタン押下時
            // 前の画面に戻る
            _returnButton
                .OnClickAsObservable()
                .Subscribe(_ =>
                {
                    _cts.Cancel();
                    _cts.Dispose();
                    _houseDevUI.DisplayCreateGameSoftUI();
                })
                .AddTo(this);

            // 決定ボタン押下時
            // ハードを選択し、前の画面に戻る
            _okButton
                .OnClickAsObservable()
                .Subscribe(_ =>
                {
                    _cts.Cancel();
                    _cts.Dispose();
                    _houseDevUI.GameSoft.DevInfo.Hard = GameInfo.Industry.Hards[_selectHard];
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
            if (!_contentRect)
            {
                _contentRect = _content.GetComponent<RectTransform>();
            }

            _cts                       = new CancellationTokenSource();      
            _contentRect.localPosition = Vector3.zero;
            _selectHard                = 0;
            _isMoving                  = false;

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
        /// 移動量を取得
        /// </summary>
        private int GetMoveDistance(EMoveDir dir)
        {
            switch (dir)
            {
                case EMoveDir.Left:
                    return MoveDistance;
                case EMoveDir.Right:
                    return -MoveDistance;
            }
            return 0;
        }

        /// <summary>
        /// 水平方向への移動処理（非同期）
        /// </summary>
        /// <remarks>
        /// Time.scaleTime時にも動作する
        /// </remarks>
        /// <param name="dir">移動方向</param>
        /// <param name="cancellationToken">キャンセル用トークン</param>
        /// <returns></returns>
        private async UniTask HorizontalMoveAsync(EMoveDir dir, CancellationToken cancellationToken = default)
        {
            var startTime = Time.unscaledTime;
            var startPos  = _content.transform.localPosition;
            var endPos    = startPos + new Vector3(GetMoveDistance(dir), 0f, 0f);
            _isMoving     = true;

            while (true)
            {
                var diff                　 = Time.unscaledTime - startTime;
                var rate                   = diff / MoveTime;
                _contentRect.localPosition = Vector3.Lerp(startPos, endPos, rate);

                if (rate >= 1f) { break; }

                // キャンセルされていたらOperationCanceledExceptionをスロー
                // 非同期処理を止める
                await UniTask.Yield(PlayerLoopTiming.Update, cancellationToken);
                
            }

            switch (dir)
            {
                case EMoveDir.Left:
                    --_selectHard;
                    break;
                case EMoveDir.Right:
                    ++_selectHard;
                    break;
            }
            _isMoving = false;

        }

        #endregion
    }
}