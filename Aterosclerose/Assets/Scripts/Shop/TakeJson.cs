using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class TakeJson : MonoBehaviour
{
    public List<ShopDescriptions> ItensDaLoja;



    void Start()
    {

        string filePath = "Assets/Scripts/Shop/ShopDescriptions.json";

        // Verifica se o arquivo existe
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);

            ShopData shopData = JsonUtility.FromJson<ShopData>("{\"ItensDaLoja\":" + json + "}");

            foreach (ShopDescriptions Item in shopData.ItensDaLoja)
            {   
                ShopDescriptions ItemDaLoja = new ShopDescriptions( Item.id, Item.nome, Item.descricao);
                ItensDaLoja.Add(ItemDaLoja);
                
            }

        }else{
            Debug.Log("JSON não encontrado :(");
        }
        
    }

    
}
