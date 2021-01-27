using UnityEngine;
using System.Collections;

public class CubeCreator : MonoBehaviour, ICubeCreator
{
    [SerializeField]
    private GameObject _cube;

    public virtual void Create(Vector3 pos)
    {
        Instantiate(_cube, pos, Quaternion.identity);
    }

    private void OnEnable()
    {
        Locator<ICubeCreator>.Bind(this);
    }

    private void OnDisable()
    {
        Locator<ICubeCreator>.UnBind(this);
    }
}
