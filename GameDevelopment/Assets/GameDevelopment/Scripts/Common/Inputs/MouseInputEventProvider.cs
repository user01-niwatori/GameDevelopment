using UnityEngine;
using UnityEngine.EventSystems;
using GameDevelopment.Scenes.Employees.Entitys;

namespace GameDevelopment.Common.Inputs
{
    [RequireComponent(typeof(EmployeeCore))]
    [RequireComponent(typeof(EventTrigger))]
    public class MouseInputEventProvider : MonoBehaviour, IInputEventProvider
    {
    }
}
