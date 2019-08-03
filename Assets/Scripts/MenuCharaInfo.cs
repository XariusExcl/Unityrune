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
    public Image playerImg;
    public Text hpText;
    public Text maxHpText;
    public GameObject hpBar;
    RectTransform rt;
     
    public void Start()
    {
        rt = playerImg.GetComponent<RectTransform>();
    }
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

            playerImg.sprite = Resources.Load<Sprite>("Sprites/Ui/head" + character.Name + "0");
            rt.sizeDelta = new Vector2 (playerImg.sprite.rect.width, playerImg.sprite.rect.height);

            maxHpText.text = character.Maxhp.ToString();
            hpText.text = character.Hp.ToString();
            hpBar.transform.localScale = new Vector3 (Mathf.Clamp((float)character.Hp/character.Maxhp, 0f, 1f), 1f, 1f);

            hpBar.GetComponent<Image>().color = new Color (character.Color[0], character.Color[1], character.Color[2]);
        }
    }
}
