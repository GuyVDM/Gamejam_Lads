using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour {

    public static DialogueManager diaManager;

    [Header("UI Settings:")]
    [SerializeField] private GameObject sign;
    [SerializeField] private Animator textbox;
    [SerializeField] private TextMeshProUGUI chatbox_Text;

    #region Private Variables
    private Dialogue currentDialogue = null; //The current dialogue loaded;

    private float timeBase = 0;
    private float timer = 0;

    private int dialoguePageIndex = 0; //The current page you are at of your current dialogue;
    private int characterIndex = 0; //The current letter that you are at with your current dialogue page;

    private bool loadNextChar = false;
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
        LoadDialogueText();
        SetTimer();
        TestInputs();
    }

    private void TestInputs() {
        if (Input.GetButtonDown("Fire2") && currentDialogue != null) {
            NextChatbox();
        }
    }

    private void SetTimer() {
        if (timer > 0) {
            timer -= Time.deltaTime;
            loadNextChar = false;
            return;
        }

        loadNextChar = true;
    }
    #endregion

    /// <summary>
    /// This is the main function of the manager, makes it so that a new dialogue can be loaded up;
    /// </summary>
    internal void LoadDialogue(Dialogue _NewDialogue) {
        if(currentDialogue == null) {
            sign.SetActive(false);
            textbox.SetBool("State", true);
            GameManager.gameManager.gameIsBusy = true;
            currentDialogue = _NewDialogue; //Sets up new dialogue to read;
            SetupCurrentBox();
        }
    }

    //Sets up the settings for the current page;
    private void SetupCurrentBox() {
        characterIndex = 0;
        timeBase = currentDialogue.texts[dialoguePageIndex].settings.dialogueSpeed; //Sets up the speed to load the dialogue at;
        chatbox_Text.text = "";
    }

    private void NextChatbox() {
        if(dialoguePageIndex >= currentDialogue.texts.Count - 1) { //If there are more chatboxes to be loaded;
                EndDialogue(); //If there is no more dialogue to be loaded;
                return;
            }

        dialoguePageIndex++; //Highers the page index by one; 
        SetupCurrentBox();
    }

    private void LoadDialogueText() {
        if(currentDialogue != null) { //If there is dialogue to be loaded;
            if (dialoguePageIndex <= currentDialogue.texts.Count - 1) {
                if (currentDialogue.texts[dialoguePageIndex]._Text.Length > chatbox_Text.text.Length && loadNextChar == true) { //If not all text has appeared on the screen yet;
                    chatbox_Text.text += currentDialogue.texts[dialoguePageIndex]._Text[characterIndex];
                    timer = timeBase;
                    characterIndex++;
                    return;
                }
            }
                sign.SetActive(true);
        }
    }

    private void EndDialogue() {
        if (currentDialogue != null) { //If there is dialogue to end;
            if (currentDialogue.functionToCallAfterDialogue != null) //If there is a function to call;
                sign.SetActive(false);
            currentDialogue.functionToCallAfterDialogue.ActivateFunction(); //Activate function;
            currentDialogue = null; //Reset the dialogue;
            chatbox_Text.text = "";
            characterIndex = 0;
            dialoguePageIndex = 0;
            textbox.SetBool("State", false);
        }

    }
}
