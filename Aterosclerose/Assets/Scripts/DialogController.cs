using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro; 

public class DialogController : MonoBehaviour
{
    [SerializeField] GameObject dialogBox;
    [SerializeField] TMP_Text dialogText;
    [SerializeField] int lettersPerSecond;
    public PlayerMove playerMoveScript;
    
    private int line = 0;
    private bool isTyping = false; // Variável de controle para verificar se a digitação está em andamento.

    public static DialogController Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        playerMoveScript = GameObject.FindObjectOfType<PlayerMove>();
    }

    private void SetCanMove(bool newValue)
    {
        playerMoveScript.canMove = newValue;
    }



    public void ShowDialog(Dialog dialog)
    {   

        if (isTyping) // Se já estiver digitando, não faça nada.
            return;

        dialogBox.SetActive(true);
        
        if (line == dialog.Lines.Count)
        {
            SetCanMove(true);
            dialogBox.SetActive(false);
            line = 0;
        }
        else
        {   
            SetCanMove(false);
            StartCoroutine(TypeDialog(dialog.Lines[line]));
            line++;
        }
    }

    public IEnumerator TypeDialog(string line)
    {
        isTyping = true; // Defina a flag como verdadeira enquanto estiver digitando.
        dialogText.text = "";
        foreach (var letter in line.ToCharArray())
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(1f / lettersPerSecond);
        }
        yield return new WaitForSeconds(1f);
        isTyping = false; // Defina a flag como falsa quando a digitação estiver concluída.
    }
}
