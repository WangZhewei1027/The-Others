using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectState : MonoBehaviour
{
    public bool stateIsLarge = true;
    public bool AllowToHold = true;
    public bool AllowToChangeDimension = true;

    private Transform tf;
    private Collider col;
    private bool canChange = true;

    public void try2invoke()
    {
        col = GetComponent<Collider>();
        if (canChange)
        {
            if (stateIsLarge)
            {
                StartCoroutine(Shrink());
            }
            else
            {
                StartCoroutine(Enlarge());
            }
            canChange = false;
        }
    }

    IEnumerator Shrink()
    {
        var cnt = 0;
        while (col.bounds.size.z > 0.1 && cnt <= 1000)
        {
            print(col.bounds.size.z);
            cnt++;
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z * 0.99f);
            yield return new WaitForSeconds(0.008f);
        }
        stateIsLarge = false;
        canChange = true;
        print("Shrink Finished");
    }

    IEnumerator Enlarge()
    {
        var cnt = 0;
        while (transform.localScale.z < 1 && cnt <= 1000)
        {
            cnt++;
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z * 1.05f);
            yield return new WaitForSeconds(0.008f);
        }
        stateIsLarge = true;
        canChange = true;
        print("Enlarge Finished");
    }
}
