using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigSleepCutscene : MonoBehaviour {


    public Transform doorPosition;
    public Transform player;
    public Dialogue endDialogue;

    public void StartCutscene()
    {
        StartCoroutine(Cutscene());
    }

    public IEnumerator Cutscene()
    {
        yield return new WaitForSeconds(5);

        player.transform.position = doorPosition.transform.position;

        FadeToBlack.instance.StartFadeFrom();

        DialogueManager.diaManager.LoadDialogue(endDialogue);
    }

}
