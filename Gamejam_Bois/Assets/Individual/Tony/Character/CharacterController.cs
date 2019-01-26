using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {

	public Animator myAnim { get { return GetComponent<Animator>(); } }

    private void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"), 0);
    
        myAnim.SetFloat("Horizontal", movement.x);
        myAnim.SetFloat("Vertical", movement.y);
        myAnim.SetFloat("Magnitude", movement.magnitude);


        transform.position += movement *3* Time.deltaTime;
    }
}
