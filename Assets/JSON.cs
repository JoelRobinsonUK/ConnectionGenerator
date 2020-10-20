using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

[Serializable]
public class JsonHelper
{
    public static T[] FromJson<T>(string json)
    {
        string newJson = "{\"array\": " + json + "}";
        JToken jToken = JToken.Parse(newJson);
        Wrapper<T> wrapper = jToken.ToObject<Wrapper<T>>();
        return wrapper.array;
    }
    [System.Serializable]
    private class Wrapper<T>
    {
        public T[] array;
    }
    public string id;
    public string firstname;
}
