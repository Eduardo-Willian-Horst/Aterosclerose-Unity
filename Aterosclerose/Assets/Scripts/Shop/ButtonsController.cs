using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsController : MonoBehaviour
{

    [SerializeField] private Button Kit;
    [SerializeField] private Button XRay;
    [SerializeField] private Button B3;
    [SerializeField] private Button B4;
    [SerializeField] private TMP_Text Texto_Descricao;
    [SerializeField] private TakeJson Lista;
    [SerializeField] private List<Button> AllButtons;


    private void Awake()
    {
        Kit.onClick.AddListener( delegate {ButtonSelected(Kit, 1); });
        XRay.onClick.AddListener( delegate {ButtonSelected(XRay, 2); });
        B3.onClick.AddListener( delegate {ButtonSelected(B3, 3); });
        B4.onClick.AddListener( delegate {ButtonSelected(B4, 4); });
    }




    private void ButtonSelected(Button button, int ident){
        Texto_Descricao.text = Lista.ItensDaLoja[Lista.ItensDaLoja.FindIndex( item => item.id == ident)].descricao;
        DescelectButtons();
        Debug.Log("Clicou");
        button.interactable = false;
    }

    private void DescelectButtons()
    {
        foreach(Button Button in AllButtons)
        {
            Button.interactable = true;
        }
    }


}
