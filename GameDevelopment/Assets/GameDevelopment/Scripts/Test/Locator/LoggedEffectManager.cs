using UnityEngine;
using UnityEditor;

public class LoggedEffectManager : EffectManager
{
    public override void PlayEffect(Vector3 pos)
    {
        base.PlayEffect(pos);
        Debug.Log(pos);
    }
}