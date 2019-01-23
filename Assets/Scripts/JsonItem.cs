using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class JsonItem
{
    // Fait le lien JSON uniquement pour les attributs avec [JsonProperty("")]
    // J'utilise exclusivement du JSON comme ça
    [JsonObject(MemberSerialization.OptIn)]
    class Item
    {
        // [JsonProperty("string")] définit le nom de propriété correspondant en JSON
        [JsonProperty("string")] public string     String = "hello";
        [JsonProperty("int")]    public int        Integer = 5;
        [JsonProperty("double")] public double     Double = 12.4;
        [JsonProperty("bool")]   public bool       Boolean = false;
        [JsonProperty("array")]  public string[]   Array = new string[] { "item1", "item2" };
        [JsonProperty("object")] public TestObject Object = new TestObject();
    }

    [JsonObject(MemberSerialization.OptIn)]
    class TestObject
    {
        [JsonProperty("value")] public string Value = "oof";
        [JsonProperty("oof")]   public int    Oof = 666;
    }
}
