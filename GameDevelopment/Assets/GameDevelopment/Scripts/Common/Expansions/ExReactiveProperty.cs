using System;
using UniRx;
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

}