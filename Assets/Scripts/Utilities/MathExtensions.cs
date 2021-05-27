using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MathExtensions
{
    public static float GetTime(Vector3 fromVector, Vector3 toVector, float time)
    {
        return Vector3.Distance(fromVector, toVector) / (time / Time.deltaTime);
    }
}
