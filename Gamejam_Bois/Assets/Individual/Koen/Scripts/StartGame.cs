using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour {

    private static float loadTime = 3;

    public void LoadMain() {
        StartCoroutine(StartGameTimer());
    }

    private IEnumerator StartGameTimer() {
        yield return new WaitForSeconds(loadTime);
        SceneManager.LoadScene(1);
    }
}
