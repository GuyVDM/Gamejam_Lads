using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public static UIManager instance;

    [Header("Quest Message System")]
    public Animator questMessageAnimator;
    public Text questNameText;
    public Text questDiscriptionText;

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

        //Start Quest message animation;
    }

}
