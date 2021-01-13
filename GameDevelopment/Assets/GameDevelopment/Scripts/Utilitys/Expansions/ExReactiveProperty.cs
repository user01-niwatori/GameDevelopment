using System;
using GameDevelopment.Scenes.Employees.Datas;
using UniRx;

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

}