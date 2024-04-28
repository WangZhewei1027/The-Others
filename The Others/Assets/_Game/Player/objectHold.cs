using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectHold : MonoBehaviour
{
    public float interactionDistance = 5f;
    public GameObject tempObject;
    public AudioClip holdSound, releaseSound;

    private GameObject obj;
    private Rigidbody rb;
    private bool isHold = false;
    private objectState flag;
    private AudioSource objSound;

    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactionDistance) && hit.collider.gameObject.tag == "object")
        {
            obj = hit.collider.gameObject;
            flag = obj.GetComponent<objectState>();
            objSound = obj.GetComponent<AudioSource>();

            if (Input.GetMouseButton(0) && !isHold && flag.AllowToHold)
            {
                HoldObject();
                objSound.loop = true;
                objSound.clip = holdSound;
                objSound.Play();
            }
        }

        if (isHold)
        {
            if (!Input.GetMouseButton(0))
            {
                ReleaseObject();
                objSound = obj.GetComponent<AudioSource>();
                objSound.loop = false;
                objSound.clip = releaseSound;
                objSound.Play();
            }
        }
    }

    private void HoldObject()
    {
        tempObject.transform.position = obj.transform.position;
        obj.transform.SetParent(tempObject.transform);
        isHold = true;

        rb = obj.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.useGravity = false;
        }
    }

    private void ReleaseObject()
    {
        tempObject.transform.DetachChildren();
        isHold = false;

        if (rb != null)
        {
            rb.useGravity = true;
        }
    }
}
