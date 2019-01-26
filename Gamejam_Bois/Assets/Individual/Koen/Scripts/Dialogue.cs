using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

[CreateAssetMenu(menuName = "Dialogue_Settings/New_Dialogue")]
public class Dialogue : ScriptableObject {

    [System.Serializable]
    public struct DialogueSettings {
        [Header("Dialogue Settings:")]
        public float dialogueSpeed;
        public bool useWhitespaceDelay;
        public bool useSoundWhenAllCaps;
    }

    [System.Serializable]
    public struct DialogueContainer {
        [SerializeField] private string name;

        [TextArea(5, 10)]
        public string _Text;
        public DialogueSettings settings;
    }

    public List<DialogueContainer> texts = new List<DialogueContainer>();

    [Tooltip("Invokes function after dialogue, if assigned.")]
    [Header("Function Settings:")]
    public UnityEvent functionToCallAfterDialogue;
}
