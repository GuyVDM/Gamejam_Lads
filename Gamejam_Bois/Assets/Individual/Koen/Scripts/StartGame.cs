using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour {

    private static float loadTime = 3;

    [SerializeField] private GameObject[] _buttons;

    public void LoadMain() {
        StartCoroutine(StartGameTimer());
    }

    public void DestroyButtons() {
        foreach (GameObject _Obj in _buttons)
            Destroy(_Obj);
    }

    private IEnumerator StartGameTimer() {
        yield return new WaitForSeconds(loadTime);
        SceneManager.LoadScene(1);
    }
}
