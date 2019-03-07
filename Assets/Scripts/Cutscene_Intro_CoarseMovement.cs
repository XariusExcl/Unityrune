using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscene_Intro_CoarseMovement : MonoBehaviour
{
    // Rounds the gameobject's transform to imitate what's in-game.
    // I'm rounding to nearest 0.02, by dividing the number by 2, rounding it by 0.01, then multiplying it by 2
    // "If it's stupid and it works, it ain't stupid"
    public Transform tr;
    void LateUpdate()
    {
        
        tr.position = new Vector3(Convert.ToSingle(Math.Round((tr.position.x)/2, 2))*2,
                                  Convert.ToSingle(Math.Round((tr.position.y)/2, 2))*2,
                                  tr.position.z);
    }
}
