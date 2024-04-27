using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public GameObject door;

    public AudioClip doorOpen, doorClose;

    public string doorOpenAnimName, doorCloseAnimName;

    public AudioSource doorAudioSource;

    private void OnCollisionEnter(Collision collision)
    {
        Animator doorAnim = door.GetComponent<Animator>();

        //The doorSound's audio clip will change to the door open sound
        doorAudioSource.clip = doorOpen;

        //The door open sound will play
        doorAudioSource.Play();

        //The door's close animation trigger is reset
        doorAnim.ResetTrigger("close");

        //The door's open animation trigger is set (it plays)
        doorAnim.SetTrigger("open");

        
    }

    private void OnCollisionExit(Collision collision)
    {
        Animator doorAnim = door.GetComponent<Animator>();

        doorAudioSource.clip = doorClose;

        doorAudioSource.Play();

        //The door's open animation trigger is reset
        doorAnim.ResetTrigger("open");

        //The door's close animation trigger is set (it plays)
        doorAnim.SetTrigger("close");

    }


}
