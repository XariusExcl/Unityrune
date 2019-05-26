/*
(Attached to characterMenu prefab)
Takes care of displaying the Character's infos correctly in a characterMenu.
*/
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
public class MenuCharaInfo : MonoBehaviour
{
    public Character character;
    public Text nameText;
    public SpriteRenderer playerImg;
    public Text hpText;
    public GameObject hpBar;

    // Update is called once per frame
    void Update()
    {
        if (character != null)
        {
            StringBuilder nameTextSB = new StringBuilder(6);

            // Adds automatic spaces to names
            int i = 0;
            foreach (char letter in character.Name) 
            {
                i++;

                if (character.Name.Length <= 4)
                    nameTextSB.Append("  ");
                
                else if (character.Name.Length == 5)
                    nameTextSB.Append(" ");

            
                if (character.Name.Length > 6 && i == 6)
                {
                    nameTextSB.Append(".");
                    break;
                }
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

            float barScale = ((float)character.Hp/character.Maxhp)*2;
            if (barScale < 0)
                barScale = 0;
            if (barScale > 2)
                barScale = 2;

            hpBar.transform.localScale = new Vector3 (barScale, 2f, 0f);

            hpBar.GetComponent<SpriteRenderer>().color = new Color (character.Color[0], character.Color[1], character.Color[2]);
        }
    }
}
