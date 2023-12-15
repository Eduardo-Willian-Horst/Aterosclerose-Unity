using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeControll : MonoBehaviour
{
    public Image fadeImage;
    public float fadeSpeed = 1.5f;

    private bool isFading = false;
    public bool IsFadingComplete { get { return !isFading; } }

    private void Start()
    {
        StartCoroutine(FadeIn());
    }

    public IEnumerator FadeIn()
    {
        isFading = true;
        fadeImage.gameObject.SetActive(true);

        float alpha = 1f;

        while (alpha > 0)
        {
            alpha -= Time.deltaTime * fadeSpeed;
            fadeImage.color = new Color(0f, 0f, 0f, alpha);
            yield return null;
        }

        fadeImage.gameObject.SetActive(false);
        isFading = false;
    }

    public void FadeOut()
    {
        if (!isFading)
        {
            StartCoroutine(FadeOutCoroutine());
        }
    }

    private IEnumerator FadeOutCoroutine()
    {
        isFading = true;
        fadeImage.gameObject.SetActive(true);

        float alpha = 0f;

        while (alpha < 1)
        {
            alpha += Time.deltaTime * fadeSpeed;
            fadeImage.color = new Color(0f, 0f, 0f, alpha);
            yield return null;
        }

        isFading = false;
    }
}
