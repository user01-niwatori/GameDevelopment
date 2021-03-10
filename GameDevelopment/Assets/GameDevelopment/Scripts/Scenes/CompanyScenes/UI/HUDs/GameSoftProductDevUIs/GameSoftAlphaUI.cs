using UniRx;
using GameDevelopment.Common.Datas;

namespace GameDevelopment.Scenes.CompanyScenes.UI.HUDs.GameSoftProjectDevUIs
{
    /// <summary>
    /// ゲームソフトアルファ版開発前に表示されるUI
    /// </summary>
    public class GameSoftAlphaUI : BaseGamePhaseUI
    {
        /// <summary>
        /// 状態
        /// </summary>
        private int _state = 0;

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
                    if (_tempCreator == null) { return; }

                    switch(_state)
                    {
                        // メインプログラマー（MainProgrammer）を選択
                        case 0:
                            GameInfo.User.Company.CurrentOffice.GameSoftProject.DevInfo.Programmer = _tempCreator;
                            _tempCreator 　　 = null;
                            _messageText.text ="作曲家を選択してください";
                            _state++;
                            break;
                        // シナリオライターを選択
                        case 1:
                            GameInfo.User.Company.CurrentOffice.GameSoftProject.DevInfo.ScenarioWirter = _tempCreator;
                            _tempCreator = null;
                            this.gameObject.SetActive(false);
                            break;
                    }
                })
                .AddTo(this);
        }

        /// <summary>
        /// 表示時に呼ばれるメソッド
        /// </summary>
        protected override void OnEnable()
        {
            _messageText.text = "メインプログラマーを選択してください";
            base.OnEnable();
        }
    }
}