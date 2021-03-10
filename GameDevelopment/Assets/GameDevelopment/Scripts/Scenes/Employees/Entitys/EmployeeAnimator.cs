using UnityEngine;
using UniRx;

namespace GameDevelopment.Scenes.Employees.Entitys
{
    /// <summary>
    /// アニメーションの名前
    /// </summary>
    public enum EAnimationName
    {
        None,
        Idle,
        Move,
        Rest,
        Work,
    }

    /// <summary>
    /// 社員のアニメータークラス
    /// </summary>
    [RequireComponent(typeof(Animator))]
    public class EmployeeAnimator : BehaviourInitialized
    {
        /// <summary>
        /// IdleのHash値
        /// </summary>
        private static int Hash_Idle = Animator.StringToHash(EAnimationName.Idle.ToString());

        /// <summary>
        /// MoveのHash値
        /// </summary>
        private static int Hash_Move = Animator.StringToHash(EAnimationName.Move.ToString());

        /// <summary>
        /// WorkのHash値
        /// </summary>
        private static int Hash_Work = Animator.StringToHash(EAnimationName.Work.ToString());

        /// <summary>
        /// RestのHash値
        /// </summary>
        private static int Hash_Rest = Animator.StringToHash(EAnimationName.Rest.ToString());

        /// <summary>
        /// Animator
        /// </summary>
        private Animator _animator = default;

        /// <summary>
        /// Start
        /// </summary>
        private async void Start()
        {
            _animator = GetComponent<Animator>();
            var mover = GetComponent<EmployeeMover>();
            await mover.OnInitialized;

            // 移動状態に応じてアニメーション再生
            mover?.MoveType
                .Subscribe(x => PlayAnimation(x))
                .AddTo(this);

            // 初期化完了
            _isInitialized.Value = true;
        }

        /// <summary>
        /// アニメーションを再生
        /// </summary>
        /// <param name="type">移動タイプ</param>
        public void PlayAnimation(EMoveType type)
        {
            // 再生中のアニメーションを止める
            StopAnimation();

            // 移動状態に合わせてアニメーションを再生
            switch (type)
            {
                case EMoveType.Idle:
                    _animator.SetBool(Hash_Idle, true);
                    break;
                case EMoveType.Move:
                    _animator.SetBool(Hash_Move, true);
                    break;
                case EMoveType.Work:
                    _animator.SetBool(Hash_Work, true);
                    break;
                case EMoveType.Rest:
                    _animator.SetBool(Hash_Rest, true);
                    break;
            }
        }

        /// <summary>
        /// アニメーションを停止
        /// </summary>
        private void StopAnimation()
        {
            _animator.SetBool(Hash_Idle, false);
            _animator.SetBool(Hash_Move, false);
            _animator.SetBool(Hash_Work, false);
            _animator.SetBool(Hash_Rest, false);
        }
    }
}