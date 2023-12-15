using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class ShopDescriptions
{
    public int id;
    public string nome;
    public string descricao;

    public ShopDescriptions(int id, string nome, string descricao)
    {
        this.id = id;
        this.nome = nome;
        this.descricao = descricao;

    }
}
