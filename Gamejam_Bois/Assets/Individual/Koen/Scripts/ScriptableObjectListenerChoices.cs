using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScriptableObjectListenerChoices : MonoBehaviour {

    [SerializeField] private string indentifier; //Used for sorting purposes;

    public Dialogue _FunctionReference;

    [Tooltip("This dialogue is optional, the corrosponding one will be loaded after a choice has been made, and if it is not a null.")]
    [Header("Optional Extra Dialogue:")]
    public Dialogue followupDialogueAccepted;
    public Dialogue followupDialogueDenied;

    [Header("Choices:")]
    public List<UnityEvent> functionsAccepted = new List<UnityEvent>();
    public List<UnityEvent> functionsDenied = new List<UnityEvent>();

    private void Start() {
        if (_FunctionReference == null)
            Debug.LogWarning("You have not added a object to add a function to - sincerely " + gameObject.name);
        else
            foreach (Dialogue.DialogueContainer _Container in _FunctionReference.texts) {
            if (_Container.settings.hasChoices == true) {
                _Container.settings.choices = this;
            }
        }
    }

    internal void ActivateFunction(bool _Choice) {
        switch(_Choice) {
            case true:
                DialogueManager.diaManager.EndDialogue();
                if (followupDialogueAccepted != null)
                    DialogueManager.diaManager.LoadDialogue(followupDialogueAccepted);

                if(functionsAccepted != null)
                foreach (UnityEvent _Function in functionsAccepted)
                    _Function.Invoke();
                break;

            case false:
                DialogueManager.diaManager.EndDialogue();
                if (followupDialogueDenied != null)
                    DialogueManager.diaManager.LoadDialogue(followupDialogueDenied);
                if (functionsDenied != null)
                foreach (UnityEvent _Function in functionsDenied)
                    _Function.Invoke();
                break;
        }
    }
}
