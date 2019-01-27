using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeToBlack : MonoBehaviour {

    public static FadeToBlack instance;

    public Image screen;
    public float fadeSpeed;

    private int sceneToLoad;

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

    public void StartFadeTo()
    {
        StartCoroutine(FadeTo());
    }

    public void StartFadeFrom()
    {
        StartCoroutine(FadeFrom());
    }

    public void StartFadeFromSceneLoad(int sceneIndex)
    {
        sceneToLoad = sceneIndex;
        StartCoroutine(FadeTo(true));
    }

    private IEnumerator FadeTo(bool loadScene = false)
    {
        while (screen.color.a < 1)
        {
            screen.color = new Color(screen.color.r, screen.color.g, screen.color.b, screen.color.a + Time.deltaTime * fadeSpeed);
            yield return null;
        }

        if (loadScene)
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }

    private IEnumerator FadeFrom()
    {
        while (screen.color.a > 0)
        {
            screen.color = new Color(screen.color.r, screen.color.g, screen.color.b, screen.color.a - Time.deltaTime * fadeSpeed);
            yield return null;
        }
    }
    
}
