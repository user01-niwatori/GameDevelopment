using UnityEngine;
using System.Collections;

public class DummyEffectManager : IEffectManager
{
    /// <summary>
    /// エフェクト生成
    /// </summary>
    /// <param name="pos"></param>
    public void PlayEffect(Vector3 pos)
    {
        Debug.Log($"Dummy position{pos}");
    }
}
