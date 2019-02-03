using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTextBox
{
    public string Text;
    public string Character;
    public string Face;

    public DialogTextBox(string text, string character, string face)
    {
        this.Text      = text;
        this.Character = character;
        this.Face      = face;
    }
}
