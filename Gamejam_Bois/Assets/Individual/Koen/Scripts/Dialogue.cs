using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

[CreateAssetMenu(menuName = "Dialogue_Settings/New_Dialogue")]
public class Dialogue : ScriptableObject {

    [System.Serializable]
    public class DialogueSettings {
        [Header("Dialogue Settings:")]
        public float dialogueSpeed = 0.05f;

        [Header("White Space:")]
        public bool useWhitespaceDelay;
        public float whiteSpaceTime;

        [Header("Others:")]
        public bool useSoundWhenAllCaps;
    }

    [System.Serializable]
    public class DialogueContainer {
        [SerializeField] private string name;

        [TextArea(5, 10)]
        public string _Text;
        public DialogueSettings settings;
    }

    public List<DialogueContainer> texts = new List<DialogueContainer>();

    [Tooltip("Invokes function after dialogue, if assigned.")]
    [Header("Function Settings:")]
    public ScriptableObjectListener functionToCallAfterDialogue;
}
