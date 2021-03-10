using UniRx;
using System;
using GameDevelopment.Scenes.Games.Datas;
using GameDevelopment.Scenes.Employees.Datas;

namespace GameDevelopment.Common.Expansions
{
    /// <summary>
    /// EEmployeeStateのReactiveProperty版
    /// </summary>
    [Serializable]
    public class EmployeeStateReactiveProperty : ReactiveProperty<EEmployeeState>
    {
        public EmployeeStateReactiveProperty() { }
        public EmployeeStateReactiveProperty(EEmployeeState initialValue) : base(initialValue) { }
    }

    /// <summary>
    /// EEmployeeTaskのReactiveProperty版
    /// </summary>
    [Serializable]
    public class EmployeeTaskReactiveProperty : ReactiveProperty<EEmployeeTask>
    {
        public EmployeeTaskReactiveProperty() { }
        public EmployeeTaskReactiveProperty(EEmployeeTask initialValue) : base(initialValue) { }
    }

    /// <summary>
    /// DateTimeのReactiveProperty版
    /// </summary>
    [Serializable]
    public class DateTimeReactiveProperty : ReactiveProperty<DateTime>
    {
        public DateTimeReactiveProperty() { }
        public DateTimeReactiveProperty(DateTime initialValue) : base(initialValue) { }
    }

    /// <summary>
    /// EPhaseTypeのReactiveProperty版
    /// </summary>
    [Serializable]
    public class PhaseTypeReactiveProperty : ReactiveProperty<EPhaseType>
    {
        public PhaseTypeReactiveProperty() { }
        public PhaseTypeReactiveProperty(EPhaseType initialValue) : base(initialValue) { }
    }

}