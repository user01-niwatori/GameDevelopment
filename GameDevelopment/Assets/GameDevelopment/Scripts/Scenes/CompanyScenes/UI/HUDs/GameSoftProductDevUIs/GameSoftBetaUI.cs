using UniRx;
using GameDevelopment.Common.Datas;

namespace GameDevelopment.Scenes.CompanyScenes.UI.HUDs.GameSoftProjectDevUIs
{
    /// <summary>
    /// ゲームソフトベータ版開発前に表示されるUI
    /// </summary>
    public class GameSoftBetaUI : BaseGamePhaseUI
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
                    UnityEngine.Debug.Log(_tempCreator.Name);
                    // キャラクターデザイナーを選択（CharacterDesign）
                    if (_tempCreator == null) { return; }
                    GameInfo.User.Company.CurrentOffice.GameSoftProject.DevInfo.Designer = _tempCreator;
                    _tempCreator                                                         = default;
                    this.gameObject.SetActive(false);
                })
                .AddTo(this);
        }

        /// <summary>
        /// 表示時に呼ばれるメソッド
        /// </summary>
        protected override void OnEnable()
        {
            _messageText.text = "キャラクターデザイナーを選択してください";
            base.OnEnable();
        }
    }
}