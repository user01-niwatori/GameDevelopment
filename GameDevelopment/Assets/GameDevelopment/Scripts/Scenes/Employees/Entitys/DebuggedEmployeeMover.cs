using UnityEngine;

namespace GameDevelopment.Scenes.Employees.Entitys
{
    /// <summary>
    /// デバッグ用社員移動クラス
    /// </summary>
    public class DebuggedEmployeeMover : EmployeeMover
    {

        /// <summary>
        /// デバッグ用に経路をGizmoに表示
        /// </summary>
        void OnDrawGizmos()
        {
            if (_navMeshAgent && _navMeshAgent.enabled)
            {
                Gizmos.color = Color.red;
                var prefPos = transform.position;

                foreach (var pos in _navMeshAgent.path.corners)
                {
                    Gizmos.DrawLine(prefPos, pos);
                    prefPos = pos;
                }
            }
        }

        //protected override void CheckGoToWork()
        //{
        //    var navMeshHit = _navMeshAgent.Raycast(_defalutPosition, out NavMeshHit hit);
            
        //    //if(navMeshHit)
        //    //{
        //    //    _navMeshAgent.ResetPath();
        //    //    _navMeshAgent.SetDestination(_defalutPosition);
        //    //    Debug.LogError("進行経路に社員がいるので中断");
        //    //}

        //    base.CheckGoToWork();
        //}

        //protected override void CheckGoToHome()
        //{
        //    var navMeshHit = _navMeshAgent.Raycast(_homePosition, out NavMeshHit hit);

        //    //if(navMeshHit)
        //    //{
        //    //    _navMeshAgent.ResetPath();
        //    //    _navMeshAgent.SetDestination(_homePosition);
        //    //    Debug.LogError("進行経路に社員がいるので中断");
        //    //}

        //    base.CheckGoToHome();
        //}
    }
}