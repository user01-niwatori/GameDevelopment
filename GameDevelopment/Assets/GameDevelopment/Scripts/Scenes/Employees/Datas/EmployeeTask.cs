using UnityEngine;
using GameDevelopment.Scenes.Employees.Entitys;
using GameDevelopment.Common.Datas;

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
            var currentHp = _core.HP.Value - 1;
            _core.SetHP(currentHp);

            var program  = Random.Range(_core.Program.Value - 2, _core.Program.Value + 2);
            var graphic  = Random.Range(_core.Graphic.Value - 2, _core.Graphic.Value + 2);
            var scenario = Random.Range(_core.Scenario.Value - 2, _core.Scenario.Value + 2);
            var sound    = Random.Range(_core.Sound.Value - 2, _core.Sound.Value + 2);
            var bug      = Random.Range(0, 5);

            // 開発中ゲームソフト
            // パラメーターを追加
            GameInfo.User.Company.CurrentOffice.GameSoftProduct.AddProgram(program);
            GameInfo.User.Company.CurrentOffice.GameSoftProduct.AddGraphic(graphic);
            GameInfo.User.Company.CurrentOffice.GameSoftProduct.AddScenario(scenario);
            GameInfo.User.Company.CurrentOffice.GameSoftProduct.AddSound(sound);
            GameInfo.User.Company.CurrentOffice.GameSoftProduct.AddBug(bug);

            //Debug.Log("更新処理");
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