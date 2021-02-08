using System;
using GameDevelopment.Scenes.Companys.Datas;

namespace GameDevelopment.Common.Datas
{
    /// <summary>
    /// ユーザーデータ
    /// </summary>
    [Serializable]
    public class UserData
    {
        /// <summary>
        /// 会社
        /// </summary>
        public CompanyData Company = default;

        /// <summary>
        /// ロックされているデータ
        /// </summary>
        public RockData Rock = new RockData();

        /// <summary>
        /// 会社を生成
        /// </summary>
        /// <param name="name">会社名</param>
        public void CreateCompany(string name)
        {
            Company = new CompanyData(name);
        }
    }
}
