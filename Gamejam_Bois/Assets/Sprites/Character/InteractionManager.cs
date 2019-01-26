using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour {

	public Animator myAnim {  get { return GetComponent<Animator>(); } }
    public Vector3 toReturn;
    private RaycastHit2D hit;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            Interact();

        GetRayDirection();
    }

    private void Interact()
    {
        hit = Physics2D.Raycast(transform.position, toReturn);

        if (hit.transform != null)
        {
            if (hit.transform.GetComponent<InteractableObject>() != null)
            {
                hit.transform.GetComponent<InteractableObject>().OnInteraction();
            }
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
