using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

public class ObjectDataBehaviour
{
    [JsonProperty("type")]
    public string Type { get; set; }
    [JsonProperty("from")]
    public float[] From { get; set; }
    [JsonProperty("to")]
    public float[] To { get; set; }
    [JsonProperty("time")]
    public float Time { get; set; }
}

public class ObjectDataSample
{
    [JsonProperty("type")]
    public string Type { get; set; }
    [JsonProperty("behaviours")]
    public List<ObjectDataBehaviour> ObjectDataBehaviourList { get; set; }
}

public class ObjectsDataSample
{
    [JsonProperty("objects")]
    public List<ObjectDataSample> ObjectDataList { get; set; }
}