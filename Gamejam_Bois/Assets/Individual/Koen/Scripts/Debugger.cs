using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Debugger : MonoBehaviour {

    [Header("Dialogue Test:")]
    public string questName;
    public UnityEvent debugCall;
    public List<Dialogue> testDialogue;
    public int loadIndex = 0;

    private void Update() {
        if(Input.GetButtonDown("Fire1")) {
            if (debugCall != null)
                debugCall.Invoke();
            else
                Debug.LogWarning("Please insert a function to invoke in the Debugger script.");
        }
    }

    public void LoadDialogueExtern() {
        DialogueManager.diaManager.LoadDialogue(testDialogue[loadIndex]);
    }

    public void StartQuest() {
        QuestManager.questManager.StartQuest(QuestManager.questManager.FindQuest(questName));
    }
}
