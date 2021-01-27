using UnityEngine;
using System.Collections;

public class LoggedCubeCreator : CubeCreator
{
    public override void Create(Vector3 pos)
    {
        base.Create(pos);
        Debug.Log("Cube生成");
    }
}
