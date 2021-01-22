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
    public class EmployeeAnimator : NewBehaviour
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
        /// アイドル
        /// </summary>
        public bool Idle 
        {
            set { _animator.SetBool(Hash_Idle, value); }
        }

        /// <summary>
        /// 移動
        /// </summary>
        public bool Move
        {
            set { _animator.SetBool(Hash_Move, value); }
        }

        /// <summary>
        /// 作業
        /// </summary>
        public bool Work
        {
            set{ _animator.SetBool(Hash_Work, value); }
        }

        /// <summary>
        /// 休む
        /// </summary>
        public bool Rest 
        {
            set { _animator.SetBool(Hash_Rest, value); }
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
                // 状態が変わりしだい発行
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