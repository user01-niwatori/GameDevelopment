using UnityEngine;

public class EffectPlayer : MonoBehaviour
{
    /// <summary>
    /// Update
    /// </summary>
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (!Locator<IEffectManager>.IsValid())
            {
                Debug.Log("IEffectManagerがロケーターに設定されていない");
                Locator<IEffectManager>.Bind(new DummyEffectManager());
            }

            // エフェクト生成
            Locator<IEffectManager>.I.PlayEffect(Utility.ScreenToWorldPoint(Camera.main, Input.mousePosition));
        }

        if (Input.GetMouseButton(1))
        {
            Locator<ICubeCreator>.I.Create(Utility.ScreenToWorldPoint(Camera.main, Input.mousePosition));
        }
    }

    /// <summary>
    /// スクリーン（マウス）座標からワールド座標に変換
    /// </summary>
    /// <param name="mousePos">マウス座標</param>
    /// <returns></returns>
    private Vector3 ScreenToWorldPoint(Vector3 mousePos)
    {
        mousePos.z   = 10f;
        var worldPos = Camera.main.ScreenToWorldPoint(mousePos);
        return worldPos;
    }
}