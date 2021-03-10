using UnityEngine;
using GameDevelopment.Scenes.Companys.Entitys;
using GameDevelopment.Scenes.Games.Datas;

namespace GameDevelopment.Scenes.CompanyScenes.UI.OfficeHUDs.DevelopmentUIs.GameSoftDevUIs.HouseDevUIs
{
    /// <summary>
    /// 自社開発UI
    /// </summary>
    public class HouseDevUI : BehaviourEnabled
    {
        /// <summary>
        /// オフィス
        /// </summary>
        [SerializeField]
        private Office _office = default; 

        /// <summary>
        /// ゲームソフト開発UI
        /// </summary>
        [SerializeField]
        private GameSoftDevUI _gameSoftDevUI = default;

        /// <summary>
        /// ゲームソフト作成UI
        /// </summary>
        [SerializeField]
        private CreateGameSoftUI _createGameSoftUI = default;

        /// <summary>
        /// ゲームハード選択UI
        /// </summary>
        [SerializeField]
        private SelectGameHardUI _selectGameHardUI = default;

        /// <summary>
        /// ゲームジャンル選択UI
        /// </summary>
        [SerializeField]
        private SelectGameGenreUI _selectGameGenreUI = default;

        /// <summary>
        /// ゲーム内容選択UI
        /// </summary>
        [SerializeField]
        private SelectGameContentsUI _selectGameContentsUI = default;

        /// <summary>
        /// ゲームディレクター選択UI
        /// </summary>
        [SerializeField]
        private SelectGameDirectorUI _selectGameDirectorUI = default;

        /// <summary>
        /// ゲーム開発規模選択UI
        /// </summary>
        [SerializeField]
        private SelectGameScaleUI _selectGameScaleUI = default;

        /// <summary>
        /// 開発予定のゲームソフト
        /// </summary>
        private GameSoftwareData _gameSoft = new GameSoftwareData();
        public  GameSoftwareData GameSoft { get { return _gameSoft; } set { _gameSoft = value; } }

        #region 表示/非表示

        /// <summary>
        /// ゲームオブジェクト表示時
        /// </summary>
        private void OnEnable()
        {
            DisplayCreateGameSoftUI();
        }

        /// <summary>
        /// ゲームソフト作成UI表示
        /// </summary>
        public void DisplayCreateGameSoftUI()
        {
            Hide();
            _createGameSoftUI.SetEnabled(true);
        }

        /// <summary>
        /// ゲームハード選択UI表示
        /// </summary>
        public void DisplaySelectGameHardUI()
        {
            Hide();
            _selectGameHardUI.SetEnabled(true);
        }

        /// <summary>
        /// ゲームジャンル選択UI表示
        /// </summary>
        public void DisplaySelectGameGenreUI()
        {
            Hide();
            _selectGameGenreUI.SetEnabled(true);
        }

        /// <summary>
        /// ゲーム内容選択UI表示
        /// </summary>
        public void DisplaySelectGameContentsUI()
        {
            Hide();
            _selectGameContentsUI.SetEnabled(true);
        }

        /// <summary>
        /// ゲームディレクターを選択UI表示
        /// </summary>
        public void DisplaySelectGameDirectorUI()
        {
            Hide();
            _selectGameDirectorUI.SetEnabled(true);
        }

        /// <summary>
        /// ゲーム開発規模選択UI表示
        /// </summary>
        public void DisplaySelectGameScaleUI()
        {
            Hide();
            _selectGameScaleUI.SetEnabled(true);
        }

        /// <summary>
        /// 子オブジェクトのUIを非表示にする
        /// </summary>
        private void Hide()
        {
            _createGameSoftUI.SetEnabled(false);
            _selectGameHardUI.SetEnabled(false);
            _selectGameGenreUI.SetEnabled(false);
            _selectGameContentsUI.SetEnabled(false);
            _selectGameDirectorUI.SetEnabled(false);
            _selectGameScaleUI.SetEnabled(false);
        }

        /// <summary>
        /// オブジェクトを非表示にする
        /// </summary>
        public void Close()
        {
            Hide();

            // ゲームソフト情報を初期化する。
            _gameSoft = null;
            _gameSoft = new GameSoftwareData();
            this.gameObject.SetActive(false);
            _gameSoftDevUI.Close();
        }

        /// <summary>
        /// 決定ボタン押下時
        /// </summary>
        public void Decision()
        {
            Hide();

            // ゲームソフト開発を開始する。
            _office.StartGameSoftProject(_gameSoft);
            _gameSoft = default;
            this.gameObject.SetActive(false);
            _gameSoftDevUI.Close();
        }

        #endregion


    }
}