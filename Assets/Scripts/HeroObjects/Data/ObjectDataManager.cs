using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDataManager
{
    public ObjectsDataSample ObjectsDataSample;
    private static readonly List<List<Queue<ObjectActionContainer>>> objectsActionList = 
        new List<List<Queue<ObjectActionContainer>>>();

    public void DownloadObjectData()
    {
        JsonParser<ObjectsDataSample> jsonParser = new JsonParser<ObjectsDataSample>();
        ObjectsDataSample = jsonParser.GetData("", "JsonDataObjects");
    }

    public void SaveObjectData(List<ObjectSample> objectSampleList)
    {
        objectsActionList.Clear();
        
        foreach (var obj in objectSampleList)
        {
            objectsActionList.Add(obj.ObjectBehaviourList);
        }
    }

    public bool GetObjectData(List<ObjectSample> objectSampleList)
    {
        for(int i = 0; i < objectsActionList.Count; i++)
        {
            objectSampleList[i].ObjectBehaviourList = objectsActionList[i];
        }

        return objectsActionList.Count == 0;
    }
}
