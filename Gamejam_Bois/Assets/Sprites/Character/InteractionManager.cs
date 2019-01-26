using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour {

    public GameObject sign;
	public Animator myAnim {  get { return GetComponent<Animator>(); } }
    public Vector3 toReturn;
    private RaycastHit2D hit;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            Interact();

        GetRayDirection();
        GetInfo();
    }

    private void GetInfo()
    {
        Debug.DrawRay(transform.position, toReturn * 1, Color.blue);
        hit = Physics2D.Raycast(transform.position, toReturn, 0.15f);

        if (hit.transform != null)
        {
            if (hit.transform.GetComponent<InteractableObject>() != null)
            {
                sign.SetActive(true);
                return;
            }
        }

        sign.SetActive(false);
    }

    private void Interact()
    {
        Debug.DrawRay(transform.position, toReturn * 1, Color.blue);
        hit = Physics2D.Raycast(transform.position, toReturn, 0.15f);

        if (hit.transform != null)
        {
            if (hit.transform.GetComponent<InteractableObject>() != null)
            {
                hit.transform.GetComponent<InteractableObject>().OnInteraction();
            }
            return;
        }
    }

    private Vector3 GetRayDirection()
    {
        if (Input.GetAxis("Horizontal") < 0)
            toReturn = Vector3.left;
        else if (Input.GetAxis("Horizontal") > 0)
            toReturn = Vector3.right;
        else if (Input.GetAxis("Vertical") > 0)
            toReturn = Vector3.up;
        else if (Input.GetAxis("Vertical") < 0)
            toReturn = Vector3.down;
        return toReturn;
    }
}
