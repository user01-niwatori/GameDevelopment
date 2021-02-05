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
        private Button _selectDevPeriodButton = default;

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

            // 閉じるボタン押下時
            // UIを非表示にする。
            _closeButton
                .OnClickAsObservable()
                .Subscribe(_ => _houseDevUI.Close())
                .AddTo(this);

        }

        /// <summary>
        /// ゲームオブジェクト表示時
        /// </summary>
        private void OnEnable()
        {
            // 選択されたハードを表示する
            // 選択されていなければNoneを表示する
            //if(_houseDevUI.GameSoft.DevInfo.Hard != null)
            //{
            //    var hardText = _selectHardButton.transform.Find("Text").GetComponent<Text>(); 
            //    hardText.text     = _houseDevUI.GameSoft.DevInfo.Hard.Name;
            //}
            //else
            //{
            //    var hardText = _selectHardButton.transform.Find("Text").GetComponent<Text>();
            //    hardText.text = "None";
            //}

            // 選択されたハードを表示する
            var hardText  = _selectHardButton.transform.Find("Text").GetComponent<Text>();
            hardText.text = _houseDevUI.GameSoft.DevInfo.Hard != null ? _houseDevUI.GameSoft.DevInfo.Hard.Name : "None"; 

            // 選択されたジャンルを表示
            var genreText  = _selectGenereButton.transform.Find("Text").GetComponent<Text>();
            genreText.text = _houseDevUI.GameSoft.DevInfo.Genre != null ? _houseDevUI.GameSoft.DevInfo.Genre?.Name.ToString() : "None";

            // 選択された内容を表示
            var contentsText  = _selectContentsButton.transform.Find("Text").GetComponent<Text>();
            contentsText.text = _houseDevUI.GameSoft.DevInfo.Content != null ? _houseDevUI.GameSoft.DevInfo.Content?.Name.ToString() : "None";

            // 選択されたディレクターを表示
            var directorText  = _selectDirectorButton.transform.Find("Text").GetComponent<Text>();
            directorText.text = _houseDevUI.GameSoft.DevInfo.Director != null ? _houseDevUI.GameSoft.DevInfo.Director.Name : "None";
        }

    }
}