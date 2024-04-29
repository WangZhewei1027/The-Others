using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class dimensionChange : MonoBehaviour
{
    public float interactionDistance = 5f;

    private GameObject obj;
    private objectState flag;

    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactionDistance))
        {

            if (hit.collider.gameObject.tag == "object")
            {
                if (Input.GetMouseButtonDown(1))
                {
                    obj = hit.collider.gameObject;
                    flag = obj.GetComponent<objectState>();

                    flag.try2invoke();
                }
            }
        }
    }
}
