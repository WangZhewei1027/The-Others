using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class dimensionChange : MonoBehaviour
{
    public float interactionDistance = 5f;

    public AudioClip enlarge, shrink;

    [SerializeField]
    private bool canChange = true;

    private GameObject obj;

    private Transform tf;

    private float col;

    private objectState flag;

    void Update()
    {
        if (canChange)
        {
            Ray ray = new Ray(transform.position, transform.forward);

            RaycastHit hit;


            if (Physics.Raycast(ray, out hit, interactionDistance))
            {

                if (hit.collider.gameObject.tag == "object")
                {

                    obj = hit.collider.gameObject;

                    flag = obj.GetComponent<objectState>();

                    tf = obj.transform;

                    AudioSource Sound = hit.collider.gameObject.GetComponent<AudioSource>();

                    if (Input.GetMouseButtonDown(1) && canChange)
                    {
                        if (flag.ChangeDimensionX)
                        {
                            col = obj.GetComponent<Collider>().bounds.size.x;
                        }
                        else if (flag.ChangeDimensionY)
                        {
                            col = obj.GetComponent<Collider>().bounds.size.y;
                        }
                        else if (flag.ChangeDimensionZ)
                        {
                            col = obj.GetComponent<Collider>().bounds.size.z;
                        }

                        print(col);

                        if (!flag.stateIsLarge)
                        {
                            canChange = false;
                            StartCoroutine(Enlarge());

                            Sound.clip = enlarge;
                            Sound.Play();
                        }
                        else
                        {
                            canChange = false;
                            StartCoroutine(Shrink());

                            Sound.clip = shrink;
                            Sound.Play();
                        }


                    }
                }
            }
        }
    }

    IEnumerator Shrink()
    {
        Debug.LogWarning("启动了一个shrink协程");
        var cnt = 0;
        
        while (col > 0.1 && cnt <= 1000)
        {
            cnt++;
            col = obj.GetComponent<Collider>().bounds.size.z;
            print(col + obj.name);
            tf.localScale = new Vector3(tf.localScale.x, tf.localScale.y, tf.localScale.z * 0.99f);
            yield return new WaitForSeconds(0.008f);
        }
        flag.stateIsLarge = false;
        canChange = true; 
        print("Shrink Finished");
    }

    IEnumerator Enlarge()
    {
        var cnt = 0;
        
        while (tf.localScale.z < 1 && cnt <= 1000)
        {
            cnt++;
            tf = obj.transform;
            tf.localScale = new Vector3(tf.localScale.x, tf.localScale.y, tf.localScale.z * 1.05f);
            yield return new WaitForSeconds(0.008f);
        }
        flag.stateIsLarge = true;
        canChange = true;
        print("Enlarge Finished");
    }

}
