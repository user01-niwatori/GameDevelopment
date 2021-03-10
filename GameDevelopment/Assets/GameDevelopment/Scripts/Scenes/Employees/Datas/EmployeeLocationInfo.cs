using UnityEngine;

namespace GameDevelopment.Scenes.Employees.Datas
{
    /// <summary>
    /// 社員の場所情報
    /// </summary>
    public class EmployeeLocationInfo
    {
        /// <summary>
        /// 位置
        /// </summary>
        public static Vector3[] Position = new Vector3[]
        {
            new Vector3(-1.5f, 1, 0),
            new Vector3(1.5f, 1, 0),
            new Vector3(-1.5f, 1, -2),
            new Vector3(1.5f, 1, -2),
            new Vector3(-1.5f, 1, -4),
            new Vector3(1.5f, 1, -4),
        };

        /// <summary>
        /// 回転
        /// </summary>
        public static Quaternion[] Rotation = new Quaternion[]
        {
            Quaternion.Euler(0, 90, 0),
            Quaternion.Euler(0, -90, 0),
            Quaternion.Euler(0, 90, 0),
            Quaternion.Euler(0, -90, 0),
            Quaternion.Euler(0, 90, 0),
            Quaternion.Euler(0, -90, 0),
        };
    }
}