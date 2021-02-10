using UnityEngine;

/// <summary>
/// オブジェクト単位ではなく、クラス単位でのオブジェクト表示/非表示
/// を可能にしたMonoBehaviour
/// </summary>
public class BehaviourEnabled : MonoBehaviour, IEnabled
{
    /// <summary>
    /// ゲームオブジェクトの表示/非表示
    /// </summary>
    /// <param name="flg">識別用flg</param>
    public void SetEnabled(bool flg)
    {
        this.gameObject.SetActive(flg);
    }
}
