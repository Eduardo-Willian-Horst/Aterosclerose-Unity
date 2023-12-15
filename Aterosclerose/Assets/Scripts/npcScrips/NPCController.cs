using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class NPCController : Interactable
{
    [SerializeField] Dialog dialog;
    
    
    public override void Interact(){


        DialogController.Instance.ShowDialog(dialog);

    }
    
}
