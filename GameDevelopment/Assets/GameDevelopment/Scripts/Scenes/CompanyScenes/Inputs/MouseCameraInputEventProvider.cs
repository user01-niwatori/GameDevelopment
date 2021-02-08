using UnityEngine;
using GameDevelopment.Common.Inputs;
using UniRx;
using UniRx.Triggers;

namespace GameDevelopment.Scenes.CompanyScenes.Inputs
{
    /// <summary>
    /// マウスでのカメラ移動処理
    /// </summary>
    public class MouseCameraInputEventProvider : MonoBehaviour, IInputEventProvider
    {
        /// <summary>
        /// 新たなズーム位置
        /// </summary>
        private readonly ReactiveProperty<Vector3> _newZoom = new ReactiveProperty<Vector3>();
        public  IReadOnlyReactiveProperty<Vector3> NewZoom => _newZoom;

        /// <summary>
        /// 新たな座標
        /// </summary>
        private readonly ReactiveProperty<Vector3> _newPosition = new ReactiveProperty<Vector3>();
        public  IReadOnlyReactiveProperty<Vector3> NewPosition => _newPosition;

        private Quaternion _newRotation = default;

        [SerializeField, Header("移動速度")]
        private float _movementSpeed = 1;

        [SerializeField, Header("移動時間")]
        private float _movementTime = 5;

        [SerializeField, Header("回転量")]
        private float _rotationAmout = 1;

        /// <summary>
        /// ズーム量
        /// </summary>
        private Vector3 _zoomAmount = new Vector3(0, -10, 10);

        /// <summary>
        /// キャッシュしたTransform
        /// </summary>
        private Transform _casheTransform = default;

        /// <summary>
        /// 開始したドラッグの位置
        /// </summary>
        private Vector3 _dragStartPosition = default;

        /// <summary>
        /// 現在のドラッグの位置
        /// </summary>
        private Vector3 _dragCurrentPosition = default;

        /// <summary>
        /// 開始した回転の位置
        /// </summary>
        private Vector3 _rotateStartPosition = default;

        /// <summary>
        /// 現在の回転の位置
        /// </summary>
        private Vector3 _rotateCurrentPosition = default;

        /// <summary>
        /// Start
        /// </summary>
        private void Start()
        {
            _casheTransform    = GetComponent<Transform>();
            _newPosition.Value = _casheTransform.position;
            _newZoom.Value     = _casheTransform.localPosition;

            // 毎フレームマウス入力を調べる
            this.UpdateAsObservable()
                .Subscribe(_ => HandleMouseInput())
                .AddTo(this);

            // 新しい座標が更新されたら
            // 現在の座標に格納
            _newPosition
                .Subscribe(x => _casheTransform.position = x)
                .AddTo(this);

        }

        /// <summary>
        /// マウス入力移動
        /// </summary>
        private void HandleMouseInput()
        {
            // マウスホイールがスクロールされていたら
            // 拡大/縮小
            if(Input.mouseScrollDelta.y != 0)
            {
                _newZoom.Value = Input.mouseScrollDelta.y * _zoomAmount;
            }

            // マウス右ボタン押下時
            // ドラッグの開始地点を格納
            if(Input.GetMouseButtonDown(0))
            {
                _dragStartPosition = GetPoint();
            }

            // マウス右ボタン押下中
            // ドラッグの現在地点格納、新しい座標を計算し格納
            if (Input.GetMouseButton(0))
            {
                _dragCurrentPosition = GetPoint();
                _newPosition.Value   = _casheTransform.position + _dragStartPosition - _dragCurrentPosition;
            }

            if(Input.GetMouseButtonDown(2))
            {
                _rotateStartPosition = Input.mousePosition;
            }

            if(Input.GetMouseButton(2))
            {
                _rotateCurrentPosition = Input.mousePosition;
                Vector3 differnce      = _rotateStartPosition - _rotateCurrentPosition;
                _rotateStartPosition   = _rotateCurrentPosition;
                _newRotation          *= Quaternion.Euler(Vector3.up * (-differnce.x / 5f));
            }

            _casheTransform.position      = Vector3.Lerp(_casheTransform.position, _newPosition.Value, Time.deltaTime * _movementTime);
            _casheTransform.rotation      = Quaternion.Lerp(_casheTransform.rotation, _newRotation, Time.deltaTime * _movementTime);
            _casheTransform.localPosition = Vector3.Lerp(_casheTransform.localPosition, _newZoom.Value, Time.deltaTime * _movementTime);
        }

        /// <summary>
        /// ポイントを取得
        /// </summary>
        /// <returns></returns>
        public Vector3 GetPoint()
        {
            Vector3 targetPoint = default;
            Plane plane         = new Plane(Vector3.up, Vector3.zero);
            Ray ray             = Camera.main.ScreenPointToRay(Input.mousePosition);
            float entry         = default;
            if (plane.Raycast(ray, out entry))
            {
                targetPoint = ray.GetPoint(entry);
            }
            return targetPoint;
        }
    }
}