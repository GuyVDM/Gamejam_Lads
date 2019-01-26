using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(AudioSource))]
public class Button_UX : MonoBehaviour, IPointerEnterHandler {

    public static List<Button_UX> objects;

    private void Start() {
        if(objects == null)
        objects = new List<Button_UX>();

        objects.Add(this);
    }

    public void OnPointerEnter(PointerEventData eventData) {
            GetComponent<AudioSource>().PlayOneShot((AudioClip)Resources.Load("Button_Over"));
        }

    public void Press() {
        GetComponent<AudioSource>().PlayOneShot((AudioClip)Resources.Load("Button_Press"));
        }
}
