using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBehaviour : IObjectBehaviour
{
    public void InitAction(GameObject gameObject, Vector3 fromVector)
    {
        gameObject.transform.rotation = Quaternion.Euler(fromVector);
    }

    public bool DoAction(GameObject gameObject, Vector3 toVector, float time, ref Vector3 currentVector)
    {
        Quaternion startRotation = gameObject.transform.rotation;
        Quaternion endRotation = Quaternion.Euler(toVector);
        
        gameObject.transform.rotation =
            Quaternion.RotateTowards(startRotation, endRotation, time);
        currentVector = gameObject.transform.rotation.eulerAngles;
        
        return Vector3.Distance(gameObject.transform.rotation.eulerAngles, toVector) <= 0.01f;
    }
}
