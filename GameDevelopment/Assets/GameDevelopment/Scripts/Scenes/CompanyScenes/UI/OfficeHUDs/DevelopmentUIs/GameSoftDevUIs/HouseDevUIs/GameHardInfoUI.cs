using UnityEngine;
using UnityEngine.UI;
using GameDevelopment.Scenes.Games.Datas;

namespace GameDevelopment.Scenes.CompanyScenes.UI.OfficeHUDs.DevelopmentUIs.GameSoftDevUIs.HouseDevUIs
{
    public class GameHardInfoUI : NewBehaviour
    {
        /// <summary>
        /// ハードの名前
        /// </summary>
        [SerializeField]
        private Text _nameText = default;

        /// <summary>
        /// 外部から名前を取得できるようにしている
        /// </summary>
        public string Name { get { return _nameText.text; } }

        /// <summary>
        /// 初期化
        /// </summary>
        /// <param name="hard">ハード情報</param>
        public void Initialized(GameHardwareData hard)
        {
            _nameText.text = hard.Name;
        }
    }
}
