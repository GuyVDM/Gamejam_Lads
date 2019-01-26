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
        float seconds = FadeToBlack.instance.fadeSpeed;

        StartCoroutine(FadeToBlack.instance.FadeTo());
        yield return new WaitForSeconds(seconds);

        player.position = teleportTo.transform.position;
        player.rotation = teleportTo.transform.rotation;

        StartCoroutine(FadeToBlack.instance.FadeFrom());
    }
}
