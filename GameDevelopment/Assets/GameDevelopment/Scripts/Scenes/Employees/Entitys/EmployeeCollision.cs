using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.EventSystems;

namespace GameDevelopment.Scenes.Employees.Entitys
{
    /// <summary>
    /// 社員の当たり判定
    /// </summary>
    [RequireComponent(typeof(EmployeeCore))]
    [RequireComponent(typeof(ObservableEventTrigger))]
    public class EmployeeCollision : BehaviourInitialized
    {
        /// <summary>
        /// 社員情報表示用クラス
        /// </summary>
        [SerializeField]
        private EmployeeView _employeeView = default;

        /// <summary>
        /// イベントトリガー
        /// </summary>
        [SerializeField]
        private ObservableEventTrigger _eventTrigger = default;

        /// <summary>
        /// Start
        /// </summary>
        private async void Start()
        {
            await _employeeView?.OnInitialized;

            // マウスがオブジェクトに乗ったら
            // HUD表示
            _eventTrigger
                .OnPointerEnterAsObservable()
                .Subscribe(_ => PointerEnter_DisplayHUD());

            // マウスがオブジェクトから離れたら
            // HUD非表示
            _eventTrigger
                .OnPointerExitAsObservable()
                .Subscribe(_ => PointerExit_HideHUD());

            // 初期化完了
            _isInitialized.Value = true;
        }

        /// <summary>
        /// コントローラーのRayがオブジェクトに乗ったときHUD表示
        /// </summary>
        public void PointerEnter_DisplayHUD()
        {
            Debug.LogError("かざされました");
            _employeeView.gameObject.SetActive(true);
        }

        /// <summary>
        /// コントローラーのRayがオブジェクトから離れたときHUD非表示
        /// </summary>
        public void PointerExit_HideHUD()
        {
            _employeeView.gameObject.SetActive(false);
        }
    }
}
