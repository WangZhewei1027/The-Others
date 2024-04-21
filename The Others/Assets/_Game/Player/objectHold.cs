using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectHold : MonoBehaviour
{
    public float interactionDistance = 5f;
    public GameObject tempObject;

    private GameObject obj;
    private Rigidbody rb; 

    private bool isHold = false;

    private state flag;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);

        RaycastHit hit;

        if (isHold)
        {
            if (Input.GetMouseButton(0))
            {
                tempObject.transform.DetachChildren();
                isHold = false;
                rb.useGravity = true;
                //rb.isKinematic = false;
                print(isHold);
            }
        }

        if (Physics.Raycast(ray, out hit, interactionDistance))
        {

            if (hit.collider.gameObject.tag == "object")
            {

                obj = hit.collider.transform.root.gameObject;

                flag = obj.GetComponent<state>();


                if (Input.GetMouseButton(0) && !isHold && flag.AllowToHold)
                {
                    tempObject.transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y, obj.transform.position.z);
                    obj.transform.SetParent(tempObject.transform);
                    isHold = true;
                    rb = obj.GetComponent<Rigidbody>();
                    rb.useGravity = false;
                    //rb.isKinematic = true;
                    print(isHold);
                }

            }
        }

        
    }
}