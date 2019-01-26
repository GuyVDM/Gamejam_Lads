using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour {

    [System.Serializable]
    public struct InteractionOption
    {
        public string onActiveQuest;
        public Dialogue dialogue;
    }

    public InteractionOption[] interactionOptions;

    public void OnInteraction()
    {
        print("meme");

        for (int i = 1; i < interactionOptions.Length; i++)
        {
            if (QuestManager.questManager.IsQuestActive(interactionOptions[i].onActiveQuest))
            {
                DialogueManager.diaManager.LoadDialogue(interactionOptions[i].dialogue);
                return;
            }
        }

        DialogueManager.diaManager.LoadDialogue(interactionOptions[0].dialogue);
        return;
    }
}
