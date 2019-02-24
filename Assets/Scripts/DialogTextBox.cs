using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

[JsonObject(MemberSerialization.OptIn)]

public class DialogTextBox
{
    [JsonProperty("text")]       public string Text;
    [JsonProperty("character")]  public string Character;
    
    [JsonProperty("posx")]       public int PosX;
    [JsonProperty("posy")]       public int PosY;
    [JsonProperty("width")]      public int Width;
    [JsonProperty("height")]     public int Height;
    [JsonProperty("shortdelay")] public float ShortDelay;
    [JsonProperty("longdelay")]  public float LongDelay;

    public Vector2 Size { get { return new Vector2(Width, Height); } }
    public Vector2 Pos { get { return new Vector2(PosX, PosY); } }

    public DialogTextBox(string text, string character)
    {
        this.Text      = text;
        this.Character = character;
    }
    /*
    public DialogTextBox(string text, string character, string face, int posx, int posy, int sizex, int sizey, float shortdelay, float longdelay)
    {
        this.Text       = text;
        this.Character  = character;
        this.Face       = face;
        this.PosX       = posx;
        this.PosY       = posy;
        this.SizeX      = sizex;
        this.SizeY      = sizey;
        this.ShortDelay = shortdelay;
        this.LongDelay  = longdelay;
    }
    */
}
