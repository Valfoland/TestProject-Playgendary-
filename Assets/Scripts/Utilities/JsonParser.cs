using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using Newtonsoft.Json;
using UnityEngine.Networking;
using UnityEngine.UI;

public class JsonParser<T>
{
    private T data;

    public T GetData(string path, string fileName)
    {
        var file = Resources.Load<TextAsset>(Path.Combine(path, fileName));
        data = JsonConvert.DeserializeObject<T>(file.text);
        return data;
    }
}