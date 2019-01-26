using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScriptableObjectListener : MonoBehaviour {

    [SerializeField] private string indentifier; //Used for sorting purposes;

    public Dialogue _FunctionReference;
    public List<UnityEvent> functions = new List<UnityEvent>();

    private void Start() {
        if (_FunctionReference == null)
            Debug.LogWarning("You have not added a object to add a function to - sincerely " + gameObject.name);
        else
            _FunctionReference.functionToCallAfterDialogue = this;
    }

    internal void ActivateFunction() {
        foreach(UnityEvent _Function in functions)
        _Function.Invoke();
    }
}
