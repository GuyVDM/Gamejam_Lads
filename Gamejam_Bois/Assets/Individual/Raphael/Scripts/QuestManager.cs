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
        public string nextQuestID;
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


        StartQuest(allQuests[0]);
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


    public void StartQuest(string _Indentifier)
    {
        StartQuest(FindQuest(_Indentifier));
    }

    public void FinishQuest(string _Indentifier)
    {
        FinishQuest(FindQuest(_Indentifier));
    }

    /// <summary>
    /// Adds a Quest to the activeQuests list. Also sends the Quest message to UI Manager
    /// </summary>
    /// <param name="questToStart"></param>
    private void StartQuest(Quest questToStart)
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
    private void FinishQuest(Quest questToFinish)
    {
        if (activeQuests.Contains(questToFinish)) {
            questToFinish.Finish();
            StartCoroutine(Unload(FindQuest(questToFinish.nextQuestID)));
            activeQuests.Remove(questToFinish);
            UIManager.instance.SetQuestUI(UIManager.instance.questNameText.text, "Completed!", true);
        }
    }

    private void FinishQuestFailed(Quest questToFinish) {
        if (activeQuests.Contains(questToFinish)) {
            questToFinish.Finish();
            StartCoroutine(Unload(FindQuest(questToFinish.nextQuestID)));
            activeQuests.Remove(questToFinish);
            UIManager.instance.SetQuestUI(UIManager.instance.questNameText.text, "Failed!", true);
        }
    }


    private IEnumerator Unload(Quest _NewQuest) {
        yield return new WaitForSeconds(UIManager.questUIScreenTime);
        UIManager.instance.SetQuestUI(UIManager.instance.questNameText.text, "Completed!", false);

        if (_NewQuest != null) {
            yield return new WaitForSeconds(UIManager.questUIScreenTime);
            StartQuest(_NewQuest);
        }
    }
}
