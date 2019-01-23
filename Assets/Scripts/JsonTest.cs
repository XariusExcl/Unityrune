using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class JsonTest : MonoBehaviour
{
    // Start is called before the first frame update
    public void ReadJson()
    {
            JsonItem item = new JsonItem();

            //                JsonConvert.SerializeObject(item) convertit l'objet item au format JSON
            //                l'option Formatting.Indented fournit un affichage propre
            Debug.Log("SerializeObject : " + JsonConvert.SerializeObject(item));

            // Lire tout le contenu d'un fichier texte
            string json_text = System.IO.File.ReadAllText("Assets/json/item.json");

            Debug.Log("ReadAllText : " + json_text);

            // Crée un Item à partir d'un texte JSON. Le type Item est nécessaire pour la conversion
            JsonItem another_item = JsonConvert.DeserializeObject<JsonItem>(json_text);
    }
}
