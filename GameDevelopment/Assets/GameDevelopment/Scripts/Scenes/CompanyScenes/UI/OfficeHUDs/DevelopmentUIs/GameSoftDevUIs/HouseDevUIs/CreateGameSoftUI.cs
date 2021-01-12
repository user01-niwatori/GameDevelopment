using UnityEngine;
using UnityEngine.UI;

namespace GameDevelopment.Scenes.CompanyScenes.UI.OfficeHUDs.DevelopmentUIs.GameSoftDevUIs.HouseDevUIs
{
    /// <summary>
    /// ゲームソフト作成UI
    /// </summary>
    public class CreateGameSoftUI : NewBehaviour
    {
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

    }
}