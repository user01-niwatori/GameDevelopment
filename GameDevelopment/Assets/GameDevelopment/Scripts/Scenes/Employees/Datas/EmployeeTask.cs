using UnityEngine;
using GameDevelopment.Common.Datas;
using GameDevelopment.Scenes.Games.Datas;
using GameDevelopment.Scenes.Employees.Entitys;

namespace GameDevelopment.Scenes.Employees.Datas
{
    /// <summary>
    /// 社員タスクのインターフェース
    /// </summary>
    public interface IEmployeeTask
    {
        /// <summary>
        /// 更新できるか？
        /// </summary>
        /// <returns></returns>
        bool IsUpdate();

        /// <summary>
        /// 開始時に呼ばれる
        /// </summary>
        void OnEnter();

        /// <summary>
        /// 毎フレーム呼ばれる
        /// </summary>
        void OnUpdate();

        /// <summary>
        /// 処理を抜けたら呼ばれる
        /// </summary>
        void OnExit();
    }

    /// <summary>
    /// 社員タスクの抽象クラス
    /// </summary>
    public abstract class EmployeeTask : IEmployeeTask
    {
        /// <summary>
        /// 社員のコア部分
        /// </summary>
        protected EmployeeCore _core = default;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public EmployeeTask(EmployeeCore core)
        {
            _core = core;
        }

        /// <summary>
        /// 更新できるか？
        /// </summary>
        /// <returns></returns>
        public virtual bool IsUpdate()
        {
            // 体力が0以下なら更新終了
            if (_core.HP.Value <= 0) { return false; }
            return true;
        }

        /// <summary>
        /// 開始時に呼ばれる
        /// </summary>
        public virtual void OnEnter()
        {
            //Debug.LogError($"{_core.gameObject.name}:開始");
        }

        /// <summary>
        /// 終了時に呼ばれる
        /// </summary>
        public virtual void OnExit()
        {
            //Debug.LogError($"{_core.gameObject.name}:終了");
            //_core = null;
        }

        /// <summary>
        /// 更新時に呼ばれる
        /// </summary>
        public virtual void OnUpdate()
        {
            // 開発フェーズに合わせて処理を分岐
            switch(GameInfo.User.Company.CurrentOffice.GameSoftProject.DevInfo.Phase.Value)
            {
                case EPhaseType.Proto:
                case EPhaseType.Alpha:
                case EPhaseType.Beta:
                case EPhaseType.Master:
                    Development();
                    break;
                case EPhaseType.Completed:
                    break;
                case EPhaseType.Debug:
                    Debug();
                    break;
            }

        }

        /// <summary>
        /// 開発中
        /// </summary>
        private void Development()
        {
            var currentHp = _core.HP.Value - 1;
            _core.SetHP(currentHp);

            var program  = Random.Range(_core.Program.Value - 2, _core.Program.Value + 2);
            var graphic  = Random.Range(_core.Graphic.Value - 2, _core.Graphic.Value + 2);
            var scenario = Random.Range(_core.Scenario.Value - 2, _core.Scenario.Value + 2);
            var sound    = Random.Range(_core.Sound.Value - 2, _core.Sound.Value + 2);
            var bug      = Random.Range(0, 2);

            // 開発中ゲームソフト
            // パラメーターを追加
            GameInfo.User.Company.CurrentOffice.GameSoftProject.AddProgram(program);
            GameInfo.User.Company.CurrentOffice.GameSoftProject.AddGraphic(graphic);
            GameInfo.User.Company.CurrentOffice.GameSoftProject.AddScenario(scenario);
            GameInfo.User.Company.CurrentOffice.GameSoftProject.AddSound(sound);
            GameInfo.User.Company.CurrentOffice.GameSoftProject.AddBug(bug);
        }

        /// <summary>
        /// デバッグ
        /// </summary>
        private void Debug()
        {
            var currentHp = _core.HP.Value - 1;
            _core.SetHP(currentHp);

            // バグを修正する。
            var bug = Random.Range(0, 5);
            GameInfo.User.Company.CurrentOffice.GameSoftProject.AddBug(-bug);
        }
    }



    /// <summary>
    /// ゲームソフト開発の仕事
    /// </summary>
    public class ETaskGameSoft : EmployeeTask
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ETaskGameSoft(EmployeeCore core) : base(core) { }

        ///// <summary>
        ///// 開始時に呼ばれる
        ///// </summary>
        //public override void OnEnter()
        //{
        //}

        ///// <summary>
        ///// 終了時に呼ばれる
        ///// </summary>
        //public override void OnExit()
        //{
        //}

        ///// <summary>
        ///// 更新時に呼ばれる
        ///// </summary>
        //public override void OnUpdate()
        //{
        //}
    }

    /// <summary>
    /// ゲームハードの開発の仕事
    /// </summary>
    public class ETaskGameHard : EmployeeTask
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="core"></param>
        public ETaskGameHard(EmployeeCore core) : base(core) { }

        ///// <summary>
        ///// 開始時に呼ばれる
        ///// </summary>
        //public override void OnEnter()
        //{
        //}

        ///// <summary>
        ///// 終了時に呼ばれる
        ///// </summary>
        //public override void OnExit()
        //{
        //}

        ///// <summary>
        ///// 更新時に呼ばれる
        ///// </summary>
        //public override void OnUpdate()
        //{
        //}
    }
}