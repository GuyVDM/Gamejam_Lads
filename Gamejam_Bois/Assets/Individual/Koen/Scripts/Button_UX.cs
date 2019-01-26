using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(AudioSource))]
public class Button_UX : MonoBehaviour, IPointerEnterHandler {

        public void OnPointerEnter(PointerEventData eventData) {
            GetComponent<AudioSource>().PlayOneShot((AudioClip)Resources.Load("Button_Over"));
        }
}
