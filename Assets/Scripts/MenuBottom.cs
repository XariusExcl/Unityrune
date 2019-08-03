/*
(Attached to MenuBottom)
Displays the characters on the bottom menu by reading the json, putting them in a list and checking if they are "inParty"
For now, it desializes the Json each frame the menu is up, which takes a bit of performance.
*/
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;

public class MenuBottom : MonoBehaviour
{
    Animator anim;
    private List<Character> characterList;
    public GameObject characterMenu;
    List<Transform> childrensTransforms;
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        // I need to get rid of animators and make my own probably
        childrensTransforms = new List<Transform>();

        // Read the json and put Characters in a list
        string json = Resources.Load<TextAsset>("Json/chara").text;
        characterList = JsonConvert.DeserializeObject<List<Character>>(json);
    }

    void Update()
    {
        anim.SetBool("IsOpen", MenuTop.isOpen);
        
        if (MenuTop.isOpen)
        {
            foreach(Character chara in characterList)
            {
                string menuName = chara.Name + "_menu";
                Transform menuTransform = gameObject.transform.Find(menuName);

                if (chara.InParty) // If the character is in party
                {
                    if (menuTransform == null) // And is not being currently displayed, Instantiate a new characterMenu
                    {
                        GameObject newMenu = Instantiate(characterMenu, gameObject.transform);
                        newMenu.name = menuName;
                        MenuCharaInfo menuCharaInfo = newMenu.gameObject.GetComponent<MenuCharaInfo>();
                        menuCharaInfo.character = chara;
                    } else { // Else, just update the infos.
                        MenuCharaInfo menuCharaInfo = menuTransform.gameObject.GetComponent<MenuCharaInfo>();
                        menuCharaInfo.character = chara;
                    }

                } else if (menuTransform != null) { // If not in party, and the characterMenu exists
                    Destroy(menuTransform.gameObject);
                }
            }
        }
    }
    public void OnTransformChildrenChanged() // Update the characterMenu's positions when their number has changed.
    {
        childrensTransforms.Clear();
        foreach (Transform child in transform)
        {
            childrensTransforms.Add(child);
        }

        switch (gameObject.transform.childCount)
        {
            case 1:
                childrensTransforms[0].transform.localPosition = new Vector3 (0, 32, 0);
                break;

            case 2:
                childrensTransforms[0].transform.localPosition = new Vector3 (-107, 32, 0);
                childrensTransforms[1].transform.localPosition = new Vector3 (107, 32, 0);
                break;

            case 3:
                childrensTransforms[0].transform.localPosition = new Vector3 (-214, 32, 0);
                childrensTransforms[1].transform.localPosition = new Vector3 (0, 32, 0);
                childrensTransforms[2].transform.localPosition = new Vector3 (214, 32, 0);
                break;
        }
    }

    public void SaveCharacters()
    {
        File.WriteAllText(@"..\Resources\Json\chara.json", JsonConvert.SerializeObject(characterList));
    }
}
