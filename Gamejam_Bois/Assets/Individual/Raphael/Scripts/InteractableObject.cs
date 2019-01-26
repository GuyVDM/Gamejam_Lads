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
        for (int i = 0; i < interactionOptions.Length; i++)
        {
            if (QuestManager.instance.IsQuestActive(interactionOptions[i].onActiveQuest))
            {
                //Send dialogue to dialogue system
                return;
            }
        }

        //Send default to dialogue system;
        return;
    }
}
