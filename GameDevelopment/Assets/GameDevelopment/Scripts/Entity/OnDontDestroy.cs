using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDontDestroy : MonoBehaviour
{
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
