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

    private objectState flag;

    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);

        RaycastHit hit;


        if (Physics.Raycast(ray, out hit, interactionDistance))
        {

            if (hit.collider.gameObject.tag == "object")
            {

                obj = hit.collider.gameObject;


                try
                {
                    flag = obj.GetComponent<objectState>();
                }

                catch
                {
                    Debug.LogWarning(obj.name + "doesn't include a objectState script.");
                    obj.AddComponent<objectState>();
                }
       

                tf = obj.transform;

                //col = obj.GetComponent<Collider>().bounds.size.z;
                //print(col);

                AudioSource Sound = hit.collider.gameObject.GetComponent<AudioSource>();

                if (Input.GetMouseButtonDown(1) && canChange)
                {
                    col = obj.GetComponent<Collider>().bounds.size.z;
                    print(col);
                    canChange = false;
                    if (!flag.stateIsLarge)
                    {
                        StartCoroutine(Enlarge());
                        
                        Sound.clip = enlarge;
                        Sound.Play();
                    }
                    else
                    {
                        StartCoroutine(Shrink());
                        
                        Sound.clip = shrink;
                        Sound.Play();
                    }
                }
            }
        }
    }

    IEnumerator Shrink()
    {
       // canChange = false;
        col = obj.GetComponent<Collider>().bounds.size.z;
        var cnt = 0;
        while (col > 0.05 && cnt <= 300)
        {
            cnt++;
            col = obj.GetComponent<Collider>().bounds.size.z;
            //print("shrinck: " + col + " in " + gameObject.name);
            tf.localScale = new Vector3(tf.localScale.x, tf.localScale.y, tf.localScale.z * 0.99f);
            yield return null;
        }
        var bounds = obj.GetComponent<Collider>().bounds;
        bounds.size = new Vector3(bounds.size.x, bounds.size.y, 0.05f);
        canChange = true;
        flag.stateIsLarge = false;
        print("Shrink Finished");
    }

    IEnumerator Enlarge()
    {
        //canChange = false;
        var cnt = 0;
        while (tf.localScale.z < 1 && cnt <= 300)
        {
            cnt++;
            col = obj.GetComponent<Collider>().bounds.size.z;
            //print("enlarge: " + col);
            tf = obj.transform;
            tf.localScale = new Vector3(tf.localScale.x, tf.localScale.y, tf.localScale.z * 1.05f);
            yield return null;
        }
        canChange = true;
        flag.stateIsLarge = true;
        print("Enlarge Finished");
    }

}
