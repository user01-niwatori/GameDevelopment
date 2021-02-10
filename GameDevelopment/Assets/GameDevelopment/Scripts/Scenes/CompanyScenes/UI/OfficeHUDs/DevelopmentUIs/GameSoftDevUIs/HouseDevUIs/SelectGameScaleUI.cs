using UniRx;
using UnityEngine;
using UnityEngine.UI;
using GameDevelopment.Common.Datas;
using GameDevelopment.Scenes.Games.Datas.Scales;

namespace GameDevelopment.Scenes.CompanyScenes.UI.OfficeHUDs.DevelopmentUIs.GameSoftDevUIs.HouseDevUIs
{
    /// <summary>
    /// 開発規模選択UI
    /// </summary>
    public class SelectGameScaleUI : BehaviourEnabled
    {
        /// <summary>
        /// UIリストの最大値
        /// </summary>
        private const int MaxSelectGameScaleInfoUIList = 3;

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
        /// 戻るボタン
        /// </summary>
        [SerializeField]
        private Button _returnButton = default;

        /// <summary>
        /// 開発規模の情報に関するUI
        /// </summary>
        [SerializeField]
        private GameScaleInfoUI[] _selectGameScaleInfoUIs = new GameScaleInfoUI[MaxSelectGameScaleInfoUIList];

        /// <summary>
        /// 開発人数のテーブル
        /// </summary>
        private int[] _scaleTable = new int[MaxSelectGameScaleInfoUIList]
        {
            1, 4, 10,
        };

        /// <summary>
        /// ゲームオブジェクト表示時
        /// </summary>
        private void OnEnable()
        {
            HideDevScaleUIList();
            DisplayDevScaleUIList();
        }

        /// <summary>
        /// Start
        /// </summary>
        private void Start()
        {
            // 準備
            Setup();

            // 戻るボタン押下時
            // 前の画面に戻る
            _returnButton
                .OnClickAsObservable()
                .Subscribe(_ => _houseDevUI.DisplayCreateGameSoftUI())
                .AddTo(this);

        }

        /// <summary>
        /// 準備
        /// </summary>
        private void Setup()
        {
            // 開発規模の情報を設定する
            for (int i = 0; i < MaxSelectGameScaleInfoUIList; i++)
            {
                var scale = new GameSoftScaleData(i);
                _selectGameScaleInfoUIs[i].Initialized(scale, () => OnClick_DevScaleButton(scale));
            }
        }

        /// <summary>
        /// 開発規模のリストを表示
        /// </summary>
        private void DisplayDevScaleUIList()
        {
            for(int i = 0; i < MaxSelectGameScaleInfoUIList; i++)
            {
                // 指定した開発人数より上回っていたら...
                // UIを表示する
                if(_scaleTable[i] <= GameInfo.User.Company.CurrentOffice.EmployeeCount)
                {
                    _selectGameScaleInfoUIs[i].gameObject.SetActive(true);
                }
            }
        }

        /// <summary>
        /// 開発規模のリストを非表示
        /// </summary>
        private void HideDevScaleUIList()
        {
            for (int i = 0; i < MaxSelectGameScaleInfoUIList; i++)
            {
                _selectGameScaleInfoUIs[i].gameObject.SetActive(false);
            }
        }

        /// <summary>
        /// ボタン押下時、開発規模を選択
        /// </summary>
        /// <param name="scale">開発規模</param>
        private void OnClick_DevScaleButton(GameSoftScaleData scale)
        {
            _houseDevUI.GameSoft.DevInfo.Scale = scale;
            _houseDevUI.DisplayCreateGameSoftUI();
        }
    }
}
