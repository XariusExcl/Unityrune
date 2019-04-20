using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;
public class MenuCharaInfo : MonoBehaviour
{
    public string partyMember; // Temporary, need to find a solution (assign character to display by nth of child)
    // Also I need a "party members" thing somewhere"
    [Space]
    public Character character;
    public Text nameText;
    public SpriteRenderer playerImg;
    public Text hpText;
    public GameObject hpBar;
    private Dictionary<string, Character> characterLibrary = new Dictionary<string, Character>();


    void Start()
    {
        string json = Resources.Load<TextAsset>("Json/chara").text;

        characterLibrary = JsonConvert.DeserializeObject<Dictionary<string, Character>>(json);
    }

    // Update is called once per frame
    void Update()
    {
        if (characterLibrary.ContainsKey(partyMember))
        {
            character = characterLibrary[partyMember];

            StringBuilder nameTextSB = new StringBuilder();

            // Adds automatic spaces to names
            foreach (char letter in character.Name) 
            {
            if (character.Name.Length <= 4)
                nameTextSB.Append("  ");
                
            else if (character.Name.Length == 5)
                nameTextSB.Append(" ");

            if (character.Name[]);
            nameTextSB.Append(letter);
            }

            nameText.text = nameTextSB.ToString();

            playerImg.sprite = Resources.Load<Sprite>("Sprites/Ui/" + character.Name + "_Img");
            
            StringBuilder hpTextSB = new StringBuilder();

            // Adds automatic spaces to HP display
            hpTextSB.Append(character.Hp);

            if (character.Maxhp < 10)
                hpTextSB.Append("/        ");
            else if (character.Maxhp < 100)
                hpTextSB.Append("/     ");
            else
                hpTextSB.Append("/  ");
            
            hpTextSB.Append(character.Maxhp);

            hpText.text = hpTextSB.ToString();

            hpBar.transform.localScale = new Vector3 (((float)character.Hp/character.Maxhp)*2, 2f, 0f);

            hpBar.GetComponent<SpriteRenderer>().color = new Color (character.Color[0], character.Color[1], character.Color[2]);
        } else {
            nameText.text = "MISSING";
            // Maybe more code ?
        }
    }
}
