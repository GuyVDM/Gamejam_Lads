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
    }

    private void Interact()
    {
        hit = Physics2D.Raycast(transform.position, getRayDirection());
        if (hit.transform.GetComponent<InteractableObject>())
            print("plassertje");
    }

    private Vector3 getRayDirection()
    {
        if (myAnim.GetFloat("Horizontal") < 0)
            toReturn = Vector3.left;
        else if (myAnim.GetFloat("Horizontal") > 0)
            toReturn = Vector3.right;
        else if (myAnim.GetFloat("Vertical") > 0)
            toReturn = Vector3.up;
        else if (myAnim.GetFloat("Vertical") < 0)
            toReturn = Vector3.down;
        return toReturn;
    }
}
