using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportationField : MonoBehaviour {

    public Transform teleportTo;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(Teleport(collision.transform));
    }

    public IEnumerator Teleport(Transform player)
    {
        GameManager.gameManager.gameIsBusy = true;
        StartCoroutine(FadeToBlack.instance.FadeTo());
        yield return new WaitForSeconds(0.5f);

        player.position = teleportTo.transform.position;
        player.rotation = teleportTo.transform.rotation;

        StartCoroutine(FadeToBlack.instance.FadeFrom());
        GameManager.gameManager.gameIsBusy = false;
    }
}
