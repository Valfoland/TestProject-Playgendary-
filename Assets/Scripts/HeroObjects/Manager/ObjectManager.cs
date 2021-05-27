using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    [SerializeField] private ObjectBuilder objectBuilder;
    private ObjectDataManager objectDataManager;

    private void Start()
    {
        InitData();
        
        SceneChanger.onChangeScene += SaveData;
    }

    private void OnDestroy()
    {
        SceneChanger.onChangeScene -= SaveData;
    }

    private void InitData()
    {
        objectDataManager = new ObjectDataManager();
        objectDataManager.DownloadObjectData();
        
        objectBuilder.InitData(objectDataManager.ObjectsDataSample);
        objectBuilder.BuildObjects();
        objectBuilder.BuildBehaviour(
            objectDataManager.GetObjectData(objectBuilder.ObjectSampleList));
    }

    private void SaveData()
    {
        objectDataManager.SaveObjectData(objectBuilder.ObjectSampleList);
    }
}
