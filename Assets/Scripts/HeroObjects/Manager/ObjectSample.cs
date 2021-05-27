using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectActionContainer
{
    public IObjectBehaviour ObjectBehaviour;
    public Vector3 FromVector;
    public Vector3 ToVector;
    public Vector3 CurrentVector;
    public float TimeAction;
    public bool IsEndedAction;
}

public class ObjectSample : MonoBehaviour
{
    public ObjectTypes TypeObject;
    public List<Queue<ObjectActionContainer>> ObjectBehaviourList = new List<Queue<ObjectActionContainer>>();

    private void Update()
    {
        DoActions();
    }

    public void InitState(bool isInitial = true)
    {
        foreach (var objQueue in ObjectBehaviourList)
        {
            if (!isInitial)
            {
                IObjectBehaviour objectBehaviour = null;
                
                foreach (var objectAction in objQueue)
                {
                    if (objectBehaviour != objectAction.ObjectBehaviour)
                    {
                        objectAction.ObjectBehaviour.InitAction(gameObject, objectAction.CurrentVector);
                        objectBehaviour = objectAction.ObjectBehaviour;
                    }
                }
            }
            else
            {
                objQueue.Peek().ObjectBehaviour.InitAction(gameObject, objQueue.Peek().FromVector);
            }
        }
    }

    private void DoActions()
    {
        for (int i = 0; i < ObjectBehaviourList.Count; i++)
        {
            ObjectActionContainer objectContainer = ObjectBehaviourList[i].Peek();
            
            try
            {
                ChangeAction(i, ref objectContainer);
            }
            catch (NullReferenceException)
            {
                continue;
            }
            
            objectContainer.IsEndedAction = objectContainer.ObjectBehaviour.DoAction(
                gameObject, objectContainer.ToVector, getTime(objectContainer), ref objectContainer.CurrentVector);
        }
    }

    private float getTime(ObjectActionContainer objectContainer)
    {
        return MathExtensions.GetTime(objectContainer.FromVector, objectContainer.ToVector, objectContainer.TimeAction);
    }
    
    private void ChangeAction(int i, ref ObjectActionContainer objectContainer)
    {
        if (ObjectBehaviourList[i].Peek().IsEndedAction)
        {
            ObjectBehaviourList[i].Peek().IsEndedAction = false;
            var obj = ObjectBehaviourList[i].Dequeue();
            ObjectBehaviourList[i].Enqueue(obj);
                    
            objectContainer = ObjectBehaviourList[i].Peek();
            objectContainer.ObjectBehaviour.InitAction(gameObject, objectContainer.FromVector);
        }
    }
}
