using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum ObjectTypes
{
    sphere,
    cube
}

public class ObjectBuilder : MonoBehaviour
{
    [SerializeField] private List<ObjectSample> objectSample;
    [NonSerialized] public readonly List<ObjectSample> ObjectSampleList = new List<ObjectSample>();
    
    private ObjectsDataSample objectsDataSample;
    private List<ObjectBehaviourBuilder> behaviourBuilderList = new List<ObjectBehaviourBuilder>();

    public void InitData(ObjectsDataSample objectsDataSample)
    {
        this.objectsDataSample = objectsDataSample;
    }

    public void BuildObjects()
    {
        behaviourBuilderList = new List<ObjectBehaviourBuilder>();

        foreach (var obj in objectsDataSample.ObjectDataList)
        {
            ObjectSampleList.Add(Instantiate(objectSample.First(x => x.TypeObject.ToString() == obj.Type)));
            behaviourBuilderList.Add(
                new ObjectBehaviourBuilder(ObjectSampleList[ObjectSampleList.Count - 1], obj.ObjectDataBehaviourList));
        }
    }

    public void BuildBehaviour(bool isInitial)
    {
        if(isInitial) AttachBehaviour();

        foreach (var obj in ObjectSampleList)
        {
            obj.InitState(isInitial);
        }
    }

    private void AttachBehaviour()
    {
        try
        {
            behaviourBuilderList[0]
                .AttachQueueBehaviour(0, 1)
                .AttachQueueBehaviour(2, 4)
                .AttachCombinedBehaviour(1, 2);
            
            behaviourBuilderList[1]
                .AttachCombinedBehaviour(0, 2);
            
            behaviourBuilderList[2]
                .AttachCombinedBehaviour(0, 2);
        }
        catch (ArgumentOutOfRangeException)
        {
        }
    }
}