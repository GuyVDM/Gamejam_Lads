using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{

    public Animator myAnim { get { return GetComponent<Animator>(); } }

    private void FixedUpdate()
    {
        if (GameManager.gameManager.gameIsBusy == true)
        {
            myAnim.SetFloat("Horizontal", 0);
            myAnim.SetFloat("Vertical", 0);
            myAnim.SetFloat("Magnitude", 0);
            return;
        }

        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);

        myAnim.SetFloat("Horizontal", movement.x);
        myAnim.SetFloat("Vertical", movement.y);
        myAnim.SetFloat("Magnitude", movement.magnitude);

        if (Input.GetKey(KeyCode.A))
        {
            myAnim.SetBool("Left", true);
            myAnim.SetBool("Right", false);
            myAnim.SetBool("Up", false);
            myAnim.SetBool("Down", false);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            myAnim.SetBool("Left", false);
            myAnim.SetBool("Right", true);
            myAnim.SetBool("Up", false);
            myAnim.SetBool("Down", false);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            myAnim.SetBool("Left", false);
            myAnim.SetBool("Right", false);
            myAnim.SetBool("Up", true);
            myAnim.SetBool("Down", false);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            myAnim.SetBool("Left", false);
            myAnim.SetBool("Right", false);
            myAnim.SetBool("Up", false);
            myAnim.SetBool("Down", true);
        }
            transform.position += movement * Time.deltaTime;
    }
}
