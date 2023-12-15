using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSelect : Interactable
{
    public string sceneName;
    public FadeControll FadeControll;

    public override void Interact()
    {
        StartCoroutine(TransitionRoutine());
    }

    private IEnumerator TransitionRoutine()
    {
        // Inicia a animação de fade-out
        FadeControll.FadeOut();

        // Espere até que a animação de fade-out termine
        while (!FadeControll.IsFadingComplete)
        {
            yield return null; // Aguarde um quadro
        }

        // A animação de fade-out terminou, então carregue a cena
        LoadScene(sceneName);
    }

    private void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}





