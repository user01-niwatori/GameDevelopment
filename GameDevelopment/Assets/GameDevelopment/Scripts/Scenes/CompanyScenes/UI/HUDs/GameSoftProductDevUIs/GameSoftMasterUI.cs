using UniRx;
using GameDevelopment.Common.Datas;

namespace GameDevelopment.Scenes.CompanyScenes.UI.HUDs.GameSoftProjectDevUIs
{
    /// <summary>
    /// ゲームソフトマスター版開発前に表示されるUI
    /// </summary>
    public class GameSoftMasterUI : BaseGamePhaseUI
    {
        /// <summary>
        /// Start
        /// </summary>
        private void Start()
        {
            // 「OK」ボタン押下時
            _okButton
                .OnClickAsObservable()
                .Subscribe(_ =>
                {
                    // 作曲者を選択（Composer）
                    if (_tempCreator == null) { return; }
                    GameInfo.User.Company.CurrentOffice.GameSoftProject.DevInfo.Composer = _tempCreator;
                    this.gameObject.SetActive(false);
                })
                .AddTo(this);
        }

        /// <summary>
        /// 表示時に呼ばれるメソッド
        /// </summary>
        protected override void OnEnable()
        {
            _messageText.text = "作曲者を選択してください";
            base.OnEnable();
        }
    }

}