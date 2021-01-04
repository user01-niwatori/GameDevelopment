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
    [RequireComponent(typeof(EmployeeMover))]
    public class EmployeeAnimator : MonoBehaviour
    {
        /// <summary>
        /// Animator
        /// </summary>
        private Animator _animator = default;

        /// <summary>
        /// アイドル
        /// </summary>
        public bool Idle 
        {
            set { _animator.SetBool(EAnimationName.Idle.ToString(), value); }
        }

        /// <summary>
        /// 移動
        /// </summary>
        public bool Move
        {
            set { _animator.SetBool(EAnimationName.Move.ToString(), value); }
        }

        /// <summary>
        /// 作業
        /// </summary>
        public bool Work
        {
            set{ _animator.SetBool(EAnimationName.Work.ToString(), value); }
        }

        /// <summary>
        /// 休む
        /// </summary>
        public bool Rest 
        {
            set { _animator.SetBool(EAnimationName.Rest.ToString(), value); }
        }

        /// <summary>
        /// Start
        /// </summary>
        private void Start()
        {
            _animator  = GetComponent<Animator>();
            var mover  = GetComponent<EmployeeMover>();

            if(mover)
            {
                mover.MoveType.Subscribe(x => SetAnimation(x));
            }
        }

        /// <summary>
        /// アニメーションを設定
        /// </summary>
        /// <param name="type"></param>
        private void SetAnimation(EMoveType type)
        {
            InitializeAnimation();

            // 移動状態に合わせてアニメーションを再生
            switch (type)
            {
                case EMoveType.Idle:
                    Idle = true;
                    break;
                case EMoveType.Move:
                    Move = true;
                    break;
                case EMoveType.Work:
                    Work = true;
                    break;
                case EMoveType.Rest:
                    Rest = true;
                    break;
            }
        }

        /// <summary>
        /// アニメーション情報を初期化
        /// </summary>
        private void InitializeAnimation()
        {
            Idle = false;
            Move = false;
            Work = false;
            Rest = false;
        }
    }
}