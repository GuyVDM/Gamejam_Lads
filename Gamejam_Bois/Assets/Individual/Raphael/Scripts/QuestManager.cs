using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public static QuestManager questManager;

    [System.Serializable]
    public class Quest
    {
        public string questName;
        public string questDisplayName;
        public string questDiscription;
        [SerializeField]
        private bool isActive;
        [SerializeField]
        private bool isFinished;

        public void Begin()
        {
            isActive = true;
            isFinished = false;
        }

        public void Finish()
        {
            isFinished = true;
            isActive = false;
        }
    }

    //Array of all available quests in the whole game.
    public Quest[] allQuests;

    //Indexes of all active quests.
    public List<Quest> activeQuests = new List<Quest>();

    public void Awake()
    {
        if (questManager == null)
        {
            questManager = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Finds and returns a Quest by the questName. Use as an overload in the StartQuest and FinishQuest Functions.
    /// </summary>
    /// <param name="questName"></param>
    /// <returns></returns>
    public Quest FindQuest(string questName)
    {
        for (int i = 0; i < allQuests.Length; i++)
        {
            if (allQuests[i].questName == questName)
            {
                return allQuests[i];
            }
        }

        Debug.LogError("There is no quest with the name " + questName);
        return null;
    }

    /// <summary>
    /// Checks if a Quest by Questname is in activeQuests and thus is active.
    /// </summary>
    /// <param name="questName"></param>
    /// <returns></returns>
    public bool IsQuestActive(string questName)
    {
        for (int i = 0; i < activeQuests.Count; i++)
        {
            if (activeQuests[i].questName == questName)
            {
                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// Adds a Quest to the activeQuests list. Also sends the Quest message to UI Manager
    /// </summary>
    /// <param name="questToStart"></param>
    public void StartQuest(Quest questToStart)
    {
        if (!activeQuests.Contains(questToStart)) {
            questToStart.Begin();
            activeQuests.Add(questToStart);
            UIManager.instance.SendQuestMessage(questToStart.questDisplayName, questToStart.questDiscription);
        }
    }

    /// <summary>
    /// Removes a Quest from the active Quest list.
    /// </summary>
    /// <param name="questToFinish"></param>
    public void FinishQuest(Quest questToFinish)
    {
        questToFinish.Finish();
        activeQuests.Remove(questToFinish);
        UIManager.instance.SendQuestMessage("", "Completed!");
    }
}
