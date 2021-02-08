using UnityEngine;
using UnityEngine.UI;
using UniRx;

namespace GameDevelopment.Scenes.CompanyScenes.UI.OfficeHUDs.DevelopmentUIs.GameSoftDevUIs.HouseDevUIs
{
    /// <summary>
    /// ゲームソフト作成UI
    /// </summary>
    public class CreateGameSoftUI : NewBehaviour
    {
        #region field 

        /// <summary>
        /// 自社開発UI
        /// </summary>
        [SerializeField]
        private HouseDevUI _houseDevUI = default;

        /// <summary>
        /// ゲームハードを選ぶボタン
        /// </summary>
        [SerializeField]
        private Button _selectHardButton = default;

        /// <summary>
        /// ジャンルを選ぶボタン
        /// </summary>
        [SerializeField]
        private Button _selectGenereButton = default;

        /// <summary>
        /// 内容を選ぶボタン
        /// </summary>
        [SerializeField]
        private Button _selectContentsButton = default;

        /// <summary>
        /// 監督を選ぶボタン
        /// </summary>
        [SerializeField]
        private Button _selectDirectorButton = default;

        /// <summary>
        /// 開発メンバーを選ぶボタン
        /// </summary>
        [SerializeField]
        private Button _selectDevMemberButton = default;

        /// <summary>
        /// 開発規模を選ぶボタン
        /// </summary>
        [SerializeField]
        private Button _selectDevScaleButton = default;

        /// <summary>
        /// 閉じるボタン
        /// </summary>
        [SerializeField]
        private Button _closeButton = default;

        /// <summary>
        /// 決定ボタン
        /// </summary>
        [SerializeField]
        private Button _okButton = default;

        #endregion

        #region getter/setter

        /// <summary>
        /// ゲームハードテキスト
        /// </summary>
        private Text _hardText = default;
        public  Text HardText
        {
            get
            {
                if(!_hardText)
                {
                    _hardText = _selectHardButton.transform.Find("Text").GetComponent<Text>();
                }
                return _hardText;
            }
        }

        /// <summary>
        /// ゲームジャンルテキスト
        /// </summary>
        private Text _genreText = default;
        public Text GenreText
        {
            get
            {
                if (!_genreText)
                {
                    _genreText = _selectGenereButton.transform.Find("Text").GetComponent<Text>();
                }
                return _genreText;
            }
        }

        /// <summary>
        /// ゲーム内容テキスト
        /// </summary>
        private Text _contentsText = default;
        public Text ContentsText
        {
            get
            {
                if (!_contentsText)
                {
                    _contentsText = _selectContentsButton.transform.Find("Text").GetComponent<Text>();
                }
                return _contentsText;
            }
        }

        /// <summary>
        /// ゲーム内容テキスト
        /// </summary>
        private Text _directorText = default;
        public Text DirectorText
        {
            get
            {
                if (!_directorText)
                {
                    _directorText = _selectDirectorButton.transform.Find("Text").GetComponent<Text>();
                }
                return _directorText;
            }
        }

        /// <summary>
        /// ゲーム内容テキスト
        /// </summary>
        private Text _devScaleText = default;
        public Text DevScaleText
        {
            get
            {
                if (!_devScaleText)
                {
                    _devScaleText = _selectDevScaleButton.transform.Find("Text").GetComponent<Text>();
                }
                return _devScaleText;
            }
        }

        #endregion

        /// <summary>
        /// Start
        /// </summary>
        private void Start()
        {
            // ハード選択ボタン押下時
            // ハード選択UI表示
            _selectHardButton
                .OnClickAsObservable()
                .Subscribe(_ => _houseDevUI.DisplaySelectGameHardUI())
                .AddTo(this);

            // 内容選択ボタン押下時
            // 内容選択UI表示
            _selectContentsButton
                .OnClickAsObservable()
                .Subscribe(_ => _houseDevUI.DisplaySelectGameContentsUI())
                .AddTo(this);

            // ジャンル選択ボタン押下時
            // ジャンル選択UI表示
            _selectGenereButton
                .OnClickAsObservable()
                .Subscribe(_ => _houseDevUI.DisplaySelectGameGenreUI())
                .AddTo(this);

            // ディレクター選択ボタン押下時
            // ディレクター選択UI表示
            _selectDirectorButton
                .OnClickAsObservable()
                .Subscribe(_ => _houseDevUI.DisplaySelectGameDirectorUI())
                .AddTo(this);

            // 開発規模選択ボタン押下時
            // 開発規模選択UIを表示
            _selectDevScaleButton
                .OnClickAsObservable()
                .Subscribe(_ => _houseDevUI.DisplaySelectGameScaleUI())
                .AddTo(this);

            // 閉じるボタン押下時
            // UIを非表示にする。
            _closeButton
                .OnClickAsObservable()
                .Subscribe(_ => _houseDevUI.Close())
                .AddTo(this);

            // 決定ボタン押下時
            // 遷移へ
            _okButton
                .OnClickAsObservable()
                .Subscribe(_ => Decision())
                .AddTo(this);

        }

        /// <summary>
        /// ゲームオブジェクト表示時
        /// </summary>
        private void OnEnable()
        {
            // 選択されたハードを表示
            HardText.text     = _houseDevUI.GameSoft.DevInfo.Hard != null ? _houseDevUI.GameSoft.DevInfo.Hard.Name : "None"; 

            // 選択されたジャンルを表示
            GenreText.text    = _houseDevUI.GameSoft.DevInfo.Genre != null ? _houseDevUI.GameSoft.DevInfo.Genre.Name.ToString() : "None";

            // 選択された内容を表示
            ContentsText.text = _houseDevUI.GameSoft.DevInfo.Content != null ? _houseDevUI.GameSoft.DevInfo.Content.Name.ToString() : "None";

            // 選択されたディレクターを表示
            DirectorText.text = _houseDevUI.GameSoft.DevInfo.Director != null ? _houseDevUI.GameSoft.DevInfo.Director.Name : "None";

            // 選択された開発規模を表示
            DevScaleText.text = _houseDevUI.GameSoft.DevInfo.Scale != null ? _houseDevUI.GameSoft.DevInfo.Scale.Name.ToString() : "None";
        }

        /// <summary>
        /// 決定
        /// </summary>
        private void Decision()
        {
            // 全て選択されていなければ処理を返す
            if (_houseDevUI.GameSoft.DevInfo.Hard == null)     { return; }
            if (_houseDevUI.GameSoft.DevInfo.Genre == null)    { return; }
            if (_houseDevUI.GameSoft.DevInfo.Content == null)  { return; }
            if (_houseDevUI.GameSoft.DevInfo.Director == null) { return; }
            if (_houseDevUI.GameSoft.DevInfo.Scale == null)    { return; }

            _houseDevUI.Decision();
        }

    }
}