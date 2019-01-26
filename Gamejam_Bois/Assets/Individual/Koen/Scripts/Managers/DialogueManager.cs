using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour {

    public static DialogueManager diaManager;

    [Header("UI Settings:")]
    [SerializeField] private Animator textbox;
    [SerializeField] private TextMeshProUGUI chatbox_Text;

    #region Private Variables
    private Dialogue currentDialogue = null; //The current dialogue loaded;

    private float timeBase = 0;
    private float timer = 0;

    private int dialoguePageIndex = 0; //The current page you are at of your current dialogue;
    private int characterIndex = 0; //The current letter that you are at with your current dialogue page;
    #endregion

    #region Manager Initialization
    private void Start() {
        InitializeManager(); //Sets up the manager;
    }

    private void InitializeManager() {
        if (diaManager != null) return;
        diaManager = this;
    }
    #endregion

    #region Checks
    private void Update() {
        LoadNewTextCharacter();
    }
    #endregion

    /// <summary>
    /// This is the main function of the manager, makes it so that a new dialogue can be loaded up;
    /// </summary>
    internal void LoadDialogue(Dialogue _NewDialogue) {
        if(currentDialogue == null) {
            GameManager.gameManager.gameIsBusy = true;
            currentDialogue = _NewDialogue; //Sets up new dialogue to read;
            SetupCurrentBox(0);
        }
    }

    //Sets up the settings for the current page;
    private void SetupCurrentBox(int _I) {
        dialoguePageIndex = 0; //Resets the dialogue index from start;
        characterIndex = 0;
        timeBase = currentDialogue.texts[_I].settings.dialogueSpeed; //Sets up the speed to load the dialogue at;
        chatbox_Text.text = "";
    }

    private void LoadDialogueText() {

    }

    private void LoadNewTextCharacter() {

    }
}
