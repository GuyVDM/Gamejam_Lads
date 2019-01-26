using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScriptableObjectListenerChoices : MonoBehaviour {

    [SerializeField] private string indentifier; //Used for sorting purposes;

    public Dialogue _FunctionReference;

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
                if(functionsAccepted != null)
                foreach (UnityEvent _Function in functionsAccepted)
                    _Function.Invoke();
                break;

            case false:
                DialogueManager.diaManager.EndDialogue();
                if(functionsDenied != null)
                foreach (UnityEvent _Function in functionsDenied)
                    _Function.Invoke();
                break;
        }
    }
}
