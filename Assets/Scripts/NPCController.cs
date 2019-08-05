/*
(Attached to a player-following NPC)
Follows the main Player.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    Animator anim;
    GameObject playerGo;
    Vector3 playerPos;
    Vector3 playerLastPos;
    Vector3 npcPos;
    Vector3 npcLastPos;
    Queue<Vector3> playerPositions = new Queue<Vector3>();
    int size = 15; // the follow "distance" (more like the latency of follow)

    void Start()
    {
        playerGo = GameObject.FindWithTag("Player");
        playerPos = playerGo.transform.position;
        gameObject.GetComponent<Transform>().position = playerPos + new Vector3(-0.30f, 0, 0);

        anim = GetComponent<Animator>();

        float i;
        for (i = -(size-1)*2; i <= 0; i += 0.02f)
        {
            Enqueue(playerPos + new Vector3(i, 0, 0));
            // might be a great idea to check for walls before putting all of those positions
        }
    }

    void FixedUpdate()
    {
        playerPos = playerGo.transform.position;
        npcPos = transform.position;

        if (playerLastPos != playerPos) // If the player has moved since last frame
        {
            anim.enabled = true;
            Enqueue(playerPos);
            playerLastPos = playerPos;
        } else {
            if (anim.enabled == true)
            {
                anim.Play(anim.GetCurrentAnimatorClipInfo(0)[0].clip.name, 0, 0);
                Invoke("DisableAnimation", 0.016f);
            }
        }

        anim.SetFloat("Horizontal", npcPos.x - npcLastPos.x);
		anim.SetFloat("Vertical", npcPos.y - npcLastPos.y);

        npcLastPos = npcPos;
    }

    public void Enqueue(Vector3 position)
    {
        playerPositions.Enqueue(position);

        while (playerPositions.Count > size)
        {
            gameObject.GetComponent<Transform>().position = playerPositions.Dequeue(); // Teleport the NPC to the old player's position
        }
    }

    void DisableAnimation()
    {
        anim.enabled = false;
    }
}
