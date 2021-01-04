using System;
using System.Collections.Generic;
using GameDevelopment.Common.Datas;

namespace GameDevelopment.Scenes.Companys.Datas
{
    /*
     * お金
     * オフィス
     * 過去製品（ハード、ソフト）
     * ファン層（評価、人気度）
     * 売上（年ごと）
    */
    /// <summary>
    /// 会社データ
    /// </summary>
    [Serializable]
    public class CompanyData
    {
        /// <summary>
        /// 名前
        /// </summary>
        public string Name = "unnko";

        /// <summary>
        /// オフィス
        /// </summary>
        public List<OfficeData> Offices = new List<OfficeData>();

        /// <summary>
        /// 現在選択中のオフィス
        /// </summary>
        public OfficeData CurrentOffice { get { return Offices[GameInfo.CurrentOffice]; } }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="name"></param>
        public CompanyData(string name)
        {
            Name = name;
            UnityEngine.Debug.Log($"{Name}会社が作成されました");
        }

        /// <summary>
        /// オフィスを作成する
        /// </summary>
        public void CreateOffice(string name)
        {
            // オフィスを追加/作成
            // 作成したばかりのオフィスを現在のオフィスとして設定
            Offices.Add(new OfficeData(name));
            GameInfo.CurrentOffice = Offices.Count - 1;
        }
        
        /// <summary>
        /// お金
        /// </summary>
        /// <returns></returns>
        public int Money()
        {
            int money = 0;

            foreach(var office in Offices)
            {
                money += office.Money;
            }

            return money;
        }
    }
}
