using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

[JsonObject(MemberSerialization.OptIn)]
public class Character
{
    [JsonProperty("inParty")]     public bool InParty;
    [JsonProperty("name")]        public string Name;
    [JsonProperty("color")]       public float[] Color;
    [JsonProperty("description")] public string Description;
    [JsonProperty("hp")]          public int Hp;
    [JsonProperty("maxhp")]       public int Maxhp;
    [JsonProperty("equipment")]   public PlayerEquipment Equipment;
    [JsonProperty("inventory")]   public string[] Inventory;
    [JsonProperty("stats")]       public PlayerStats Stats;

    /*
    public Character(string name, string description, int hp, int maxhp, Equipment equipment, string[] inventory, Stats stats)
    {
        this.Name        = name;
        this.Description = description;
        this.Hp          = hp;
        this.Maxhp       = maxhp;
        this.Equipment   = equipment;
        this.Inventory   = inventory;
        this.Stats       = stats;
    }

    public override string ToString()
    {

    }
    */
}
