using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;

public class MenuBottom : MonoBehaviour
{
    Animator anim;
    private Dictionary<string, Character> characterLibrary = new Dictionary<string, Character>();
    public GameObject characterMenu;
    List<Transform> childrensTransforms;
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        // I need to get rid of animators and make my own probably
        childrensTransforms = new List<Transform>();
    }

    void Update()
    {
        anim.SetBool("IsOpen", MenuTop.isOpen);
        
        if (MenuTop.isOpen)
        {
            // Read the json
            string json = Resources.Load<TextAsset>("Json/chara").text;
            characterLibrary = JsonConvert.DeserializeObject<Dictionary<string, Character>>(json);
            string[] keys = characterLibrary.Keys.ToArray();
            
            // For each character inside the json
            foreach(string key in keys)
            {
                Character chara = characterLibrary[key];
                string menuName = chara.Name + "_menu";
                Transform menuTransform = gameObject.transform.Find(menuName);

                if (chara.InParty)
                {
                    if (menuTransform == null)
                    {
                        GameObject newMenu = Instantiate(characterMenu, gameObject.transform);
                        newMenu.name = menuName;
                        MenuCharaInfo menuCharaInfo = newMenu.gameObject.GetComponent<MenuCharaInfo>();
                        menuCharaInfo.character = chara;
                    } else {
                        MenuCharaInfo menuCharaInfo = menuTransform.gameObject.GetComponent<MenuCharaInfo>();
                        menuCharaInfo.character = chara;
                    }

                } else if (menuTransform != null) { // Not in party, and the menu exists
                    Destroy(menuTransform.gameObject);
                }
            }
        }
    }
    public void OnTransformChildrenChanged()
    {
        childrensTransforms.Clear();
        foreach (Transform child in transform)
        {
            childrensTransforms.Add(child);
        }

        switch (gameObject.transform.childCount)
        {
            case 1:
                childrensTransforms[0].transform.localPosition = new Vector3 (0, 80, 0);
                break;

            case 2:
                childrensTransforms[0].transform.localPosition = new Vector3 (-213, 80, 0);
                childrensTransforms[1].transform.localPosition = new Vector3 (213, 80, 0);
                break;

            case 3:
                childrensTransforms[0].transform.localPosition = new Vector3 (-436, 80, 0);
                childrensTransforms[1].transform.localPosition = new Vector3 (0, 80, 0);
                childrensTransforms[2].transform.localPosition = new Vector3 (436, 80, 0);
                break;
        }
    }
}
