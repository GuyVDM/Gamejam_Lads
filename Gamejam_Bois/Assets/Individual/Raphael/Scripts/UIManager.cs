using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour {

    public static float questUIScreenTime = 4;

    public static UIManager instance;

    [Header("Quest Message System")]
    public Animator questMessageAnimator;
    public TextMeshProUGUI questNameText;
    public TextMeshProUGUI questDiscriptionText;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SendQuestMessage(string questName, string questDiscription)
    {
        questNameText.text = questName;
        questDiscriptionText.text = questDiscription;
        SetQuestUI(questName, questDiscription, true);
    }

    private void SetQuestUI(string _Name, string _Description, bool _State) {
        questNameText.text = _Name;
        questDiscriptionText.text = _Description;
        questMessageAnimator.SetBool("State", _State);
    }
}
