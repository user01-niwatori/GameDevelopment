using System;

namespace GameDevelopment.Scenes.Employees.Datas
{
    /// <summary>
    /// 会社に対しての評価タイプ
    /// </summary>
    public enum ECompanyEvaluationType
    {
        Dissatisfaction,    // 不満
        General,            // 普通
        Highest,            // 最高
        Max,
    }

    /// <summary>
    /// 会社に対しての評価クラス
    /// </summary>
    [Serializable]
    public class CompanyEvaluationData
    {
        /// <summary>
        /// 会社に対しての評価タイプ
        /// </summary>
        public ECompanyEvaluationType Type = ECompanyEvaluationType.General;

        /// <summary>
        /// メッセージ
        /// </summary>
        public string[,] Message =
        {
            {
                "この会社で働けて幸せです。",
                "この会社の為に一生働く覚悟です。",
            },
            {
                "今の収入で満足です。",
                "会社に貢献して行きたいです。",
            },
            {
                "現状の待遇に不満を感じています。",
                "辞めようかな...。",
            },
        };
    }
}
