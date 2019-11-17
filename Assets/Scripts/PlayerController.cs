/*
(Attached to the player-controlled character)
Moves the character, and freezes their movement when inside of a menu/textbox.
*/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    Rigidbody2D rb;
    Animator anim;
    BoxCollider2D bc;
    Transform tr;
    Coroutine co;

    public GameObject talk;
    BoxCollider2D talkbc;
    Vector2 direction;

    [HideInInspector] public string lastRoom;
    [HideInInspector] public string lastDoor;

    float inputHorizontal = 0f;
    float inputVertical = 0f;
    float speedSquared = 0f;
    public bool walking;
    GameObject[] doors;
    Door doorScript;

    public static bool inMenu = false;
    private static PlayerController playerInstance;
    void Awake()
    {
        if (playerInstance == null)
        {
            DontDestroyOnLoad(this);
            playerInstance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        tr = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        bc = GetComponent<BoxCollider2D>();
        talkbc = talk.GetComponent<BoxCollider2D>();
    }

    void Update()
    {

        if (MenuTop.isOpen || inMenu) // If inside of a menu/textbox
        {
            inputHorizontal = 0f;
            inputVertical = 0f;
            anim.SetFloat("Speed", 0f);
        }
        else if (!walking)
        {
            inputHorizontal = Input.GetAxisRaw("Horizontal");
            inputVertical = Input.GetAxisRaw("Vertical");

            speedSquared = inputHorizontal * inputHorizontal + inputVertical * inputVertical;
            anim.SetFloat("Speed", speedSquared);

            if (speedSquared != 0f)
            {
                anim.SetFloat("Horizontal", inputHorizontal);
                anim.SetFloat("Vertical", inputVertical);
                direction = new Vector2(inputHorizontal / 6, -.15f + inputVertical / 6);
            }

            if (Input.GetButton("Sprint"))
            {
                anim.speed = 1.5f;
                inputHorizontal *= 1.5f;
                inputVertical *= 1.5f;
            }
            else { anim.speed = 1f; }

            if (Input.GetButtonDown("Confirm")) // Enter or Z key
            {
                talkbc.isTrigger = true;
                talk.SetActive(true);
                talk.transform.localPosition = direction;
            }
            if (Input.GetButtonUp("Confirm"))
            {
                talkbc.isTrigger = false;
                talk.SetActive(false);
                talk.transform.localPosition = new Vector3(0, -.15f, 0);
            }
        }

        /*
		if (Input.GetButtonDown("Cancel")) // Backspace or X key
		{
			Debug.Log("Cancel key pressed!");
		}

		if (Input.GetButtonDown("Menu")) // Right Ctrl or C key
		{
			Debug.Log("Menu key pressed!");
		}
		*/
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(inputHorizontal, inputVertical);
        tr.position = new Vector3(Convert.ToSingle(Math.Round(tr.position.x, 2)),
                                  Convert.ToSingle(Math.Round(tr.position.y, 2)),
                                  tr.position.z);
    }

    public void TeleportToDoor()
    {
        Debug.Log("Player : " + lastRoom + lastDoor);
        doors = GameObject.FindGameObjectsWithTag("Door");
        foreach (GameObject door in doors)
        {
            doorScript = door.GetComponent<Door>();
            if (doorScript.level == lastRoom && doorScript.doorLetter == lastDoor)
            {
                transform.position = door.transform.position + new Vector3(0f, .1f, 0f);
                co = StartCoroutine(Walk(doorScript.direction.ToString()));
                break;
            }
        }
    }

    IEnumerator Walk(string direction)
    {
        bc.enabled = false;
        walking = true;

        switch (direction)
        {
            case "up":
                inputHorizontal = 0f;
                inputVertical = 1f;
                break;
            case "right":
                inputHorizontal = 1f;
                inputVertical = 0f;
                break;
            case "down":
                inputHorizontal = 0f;
                inputVertical = -1f;
                break;
            case "left":
                inputHorizontal = -1f;
                inputVertical = 0f;
                break;
        }
        anim.SetFloat("Horizontal", inputHorizontal);
        anim.SetFloat("Vertical", inputVertical);
        anim.SetFloat("Speed", 1f);

        yield return new WaitForSeconds(.5f);
        bc.enabled = true;
        walking = false;
    }
}
