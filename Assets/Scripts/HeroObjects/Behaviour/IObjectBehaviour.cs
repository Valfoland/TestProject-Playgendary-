using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObjectBehaviour
{
    void InitAction(GameObject gameObject, Vector3 fromVector);
    bool DoAction(GameObject gameObject, Vector3 toVector, float time, ref Vector3 currentVector);
}
