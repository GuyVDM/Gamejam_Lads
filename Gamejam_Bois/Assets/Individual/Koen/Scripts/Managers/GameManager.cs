using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager gameManager;

    [Tooltip("Checks if the player may perform actions.")]
    [Header("Game Checks:")]
    public bool gameIsBusy = false;

    #region Manager Initialization
    private void Start () {
        InitializeManager();
	}

    private void InitializeManager() {
        if (gameManager != null)
        Destroy(this);

        gameManager = this;
    }
    #endregion
}
