using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

[JsonObject(MemberSerialization.OptIn)]

public class DialogEvent
{
    [JsonProperty("textboxes")] public DialogTextBox[] TextBoxes;

    public DialogEvent(DialogTextBox[] textboxes)
    {
        this.TextBoxes = textboxes;
    }

    public override string ToString()
    {
        string output = "";

        foreach(var textbox in TextBoxes)
        {
            output += textbox.Character + " says \"" + textbox.Text + "\".\n";
        }

        return output;
    }
}
