using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

[JsonObject(MemberSerialization.OptIn)]
public class PlayerEquipment
{
    [JsonProperty("weapon")] public string Weapon;
    [JsonProperty("armor1")] public string Armor1;
    [JsonProperty("armor2")] public string Armor2;

    /*
    public Equipment(string weapon, string armor1, string armor2)
    {
        this.Weapon = weapon;
        this.Armor1 = armor1;
        this.Armor2 = armor2;
    }

    public override string ToString()
    {

    }
    */
}
