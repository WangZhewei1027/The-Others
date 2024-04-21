using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class dimensionChange : MonoBehaviour
{
    public float interactionDistance = 5f;

    public AudioClip enlarge, shrink;

    private bool canChange = true;

    private GameObject obj;

    private Transform tf;

    private float col;

    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);

        RaycastHit hit;


        if (Physics.Raycast(ray, out hit, interactionDistance))
        {

            if (hit.collider.gameObject.tag == "object")
            {

                obj = hit.collider.transform.root.gameObject;

                tf = obj.transform;

                col = obj.GetComponent<Collider>().bounds.size.z;

                //AudioSource Sound = hit.collider.gameObject.GetComponent<AudioSource>();

                if (Input.GetKeyDown(KeyCode.F) && canChange)
                {
                    if (col < 0.1)
                    {
                        StartCoroutine(Enlarge());
                        canChange = false;
                    }
                    else
                    {
                        StartCoroutine(Shrink());
                        canChange = false;
                    }
                }
            }
        }
    }

    IEnumerator Shrink()
    {
        while(col > 0.05)
        {
            col = obj.GetComponent<Collider>().bounds.size.z;
            print(col);
            tf.localScale = new Vector3(tf.localScale.x, tf.localScale.y, tf.localScale.z * 0.99f);
            yield return null;
        }
        canChange = true;
    }

    IEnumerator Enlarge()
    {
        while(tf.localScale.z < 1)
        {
            tf.localScale = new Vector3(tf.localScale.x, tf.localScale.y, tf.localScale.z * 1.05f);
            yield return null;
        }
        canChange = true;
    }

}
