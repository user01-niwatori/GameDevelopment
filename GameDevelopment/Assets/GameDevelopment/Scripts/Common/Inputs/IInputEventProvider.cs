using UniRx;
using UnityEngine;

namespace GameDevelopment.Common.Inputs
{
    /// <summary>
    /// 入力周りのインターフェース
    /// </summary>
    public interface IInputEventProvider
    {
        /// <summary>
        /// 新しいズーム位置
        /// </summary>
        IReadOnlyReactiveProperty<Vector3> NewZoom { get; }

        /// <summary>
        /// 新しい座標
        /// </summary>
        IReadOnlyReactiveProperty<Vector3> NewPosition { get; }
    }
}
