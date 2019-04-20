using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

[JsonObject(MemberSerialization.OptIn)]
public class PlayerStats
{
    [JsonProperty("attack")] public int Attack;
    [JsonProperty("defense")] public int Defense;
    [JsonProperty("magic")] public int Magic;

    /*
    public Stats(int attack, int defense, int magic)
    {
        this.Attack  = attack;
        this.Defense = defense;
        this.Magic   = magic;
    }

    public override string ToString()
    {

    }
    */
}
