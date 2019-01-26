using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeToBlack : MonoBehaviour {

    public static FadeToBlack instance;

    public Image screen;
    public float fadeSpeed;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public IEnumerator FadeTo()
    {
        while (screen.color.a < 1)
        {
            screen.color = new Color(screen.color.r, screen.color.g, screen.color.b, screen.color.a + Time.deltaTime * fadeSpeed);
            yield return null;
        }
    }

    public IEnumerator FadeFrom()
    {
        while (screen.color.a > 0)
        {
            screen.color = new Color(screen.color.r, screen.color.g, screen.color.b, screen.color.a - Time.deltaTime * fadeSpeed);
            yield return null;
        }
    }
    
}
