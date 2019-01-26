using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportationField : MonoBehaviour {

    public Transform teleportTo;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.transform.position = teleportTo.transform.position;
        collision.transform.rotation = teleportTo.transform.rotation;
    }
}
