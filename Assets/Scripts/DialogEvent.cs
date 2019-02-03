using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogEvent
{
    public DialogTextBox[] TextBoxes;

    public DialogEvent(DialogTextBox[] textboxes)
    {
        this.TextBoxes = textboxes;
    }
}
