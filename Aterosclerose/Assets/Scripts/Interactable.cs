using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public virtual void Interact()
    {
        // Lógica de interação com o objeto
        Debug.Log("Interagiu com " + gameObject.name);

    }
}
