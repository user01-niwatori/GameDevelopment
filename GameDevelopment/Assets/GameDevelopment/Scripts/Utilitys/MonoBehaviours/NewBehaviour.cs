using UnityEngine;

/// <summary>
/// このゲーム専用のBehaviour
/// MonoBehaviourを使うのではなくこのクラスを利用してオブジェクトに干渉する。
/// </summary>
public class NewBehaviour : MonoBehaviour, IEnabled
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
