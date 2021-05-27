using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBehaviour : IObjectBehaviour
{
    public void InitAction(GameObject gameObject, Vector3 fromVector)
    {
        gameObject.transform.position = fromVector;
    }

    public bool DoAction(GameObject gameObject, Vector3 toVector, float time, ref Vector3 currentVector)
    {
        gameObject.transform.position = 
            Vector3.MoveTowards(gameObject.transform.position, toVector, time);
        currentVector = gameObject.transform.position;
        
        return Vector3.Distance(gameObject.transform.position, toVector) <= 0.01f;
    }
}
