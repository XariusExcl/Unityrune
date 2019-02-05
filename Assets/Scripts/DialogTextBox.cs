using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

[JsonObject(MemberSerialization.OptIn)]
public class DialogTextBox
{
    [JsonProperty("text")]      public string Text;
    [JsonProperty("character")] public string Character;
    [JsonProperty("face")]      public string Face;

    public DialogTextBox(string text, string character, string face)
    {
        this.Text      = text;
        this.Character = character;
        this.Face      = face;
    }
}
