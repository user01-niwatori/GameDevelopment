using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour, IEffectManager
{
    /// <summary>
    /// エフェクト
    /// </summary>
    [SerializeField]
    private ParticleSystem effect = null;

    /// <summary>
    /// 表示
    /// </summary>
    private void OnEnable()
    {
        Locator<IEffectManager>.Bind(this);
    }

    /// <summary>
    /// 非表示
    /// </summary>
    private void OnDisable()
    {
        Locator<IEffectManager>.UnBind(this);
    }

    /// <summary>
    /// エフェクト再生
    /// </summary>
    /// <param name="pos"></param>
    public virtual void PlayEffect(Vector3 pos)
    {
        effect.Stop();
        effect.transform.position = pos;
        effect.Play();
    }
}
