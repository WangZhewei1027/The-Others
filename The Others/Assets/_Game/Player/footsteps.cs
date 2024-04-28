using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class footsteps : MonoBehaviour
{
    public AudioSource footstepsSound, sprintSound;

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                footstepsSound.enabled = false;
                sprintSound.enabled = true;
            }
            else
            {
                footstepsSound.enabled = true;
                sprintSound.enabled = false;
            }
        }
        else
        {
            footstepsSound.enabled = false;
            sprintSound.enabled = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        footstepsSound.enabled = false;
        sprintSound.enabled = false;
    }
}