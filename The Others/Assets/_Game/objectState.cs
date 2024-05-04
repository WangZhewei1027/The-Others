using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectState : MonoBehaviour
{
    public bool stateIsLarge = true;
    public bool AllowToHold = true;
    public bool AllowToChangeDimension = true;
    public AudioClip enlargeSound, shrinkSound;
    public bool changeX, changeY, changeZ;

    private Transform tf;
    private Collider col;
    private bool canChange = true;
    private float percent = 0f;
                        

    //[SerializeField] BoxCollider BoxCollider;

    //private void OnDrawGizmosSelected()
    //{
    //    Gizmos.color = new Color(0.1f, 0.2f, 0.8f, 0.5f);
    //    Gizmos.DrawCube(BoxCollider.bounds.center, BoxCollider.bounds.size);
    //}

    public void try2invoke()
    {
        if (changeX)
        {
            col = GetComponent<Collider>();
            percent = 0.1f / col.bounds.size.x;

            if (canChange)
            {
                if (stateIsLarge)
                {
                    StartCoroutine(ShrinkX());
                }
                else
                {
                    StartCoroutine(EnlargeX());
                }
                canChange = false;
            }
        }
        if (changeY)
        {
            col = GetComponent<Collider>();
            percent = 0.1f / col.bounds.size.y;

            if (canChange)
            {
                if (stateIsLarge)
                {
                    StartCoroutine(ShrinkY());
                }
                else
                {
                    StartCoroutine(EnlargeY());
                }
                canChange = false;
            }
        }
        if (changeZ)
        {
            col = GetComponent<Collider>();
            percent = 0.1f / col.bounds.size.z;

            if (canChange)
            {
                if (stateIsLarge)
                {
                    StartCoroutine(ShrinkZ());
                }
                else
                {
                    StartCoroutine(EnlargeZ());
                }
                canChange = false;
            }
        }
    }
    IEnumerator ShrinkX()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.clip = shrinkSound;
        audioSource.Play();

        var cnt = 0;
        while (transform.localScale.x / 1 > percent && cnt <= 1000)
        {
            cnt++;
            transform.localScale = new Vector3(transform.localScale.x * 0.99f, transform.localScale.y, transform.localScale.z);
            yield return new WaitForSeconds(0.008f);
        }
        stateIsLarge = false;
        canChange = true;
        print("Shrink Finished");
    }

    IEnumerator EnlargeX()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.clip = enlargeSound;
        audioSource.Play();

        var cnt = 0;
        while (transform.localScale.x < 1 && cnt <= 1000)
        {
            cnt++;
            transform.localScale = new Vector3(transform.localScale.x * 1.05f, transform.localScale.y, transform.localScale.z);
            yield return new WaitForSeconds(0.008f);
        }
        stateIsLarge = true;
        canChange = true;
        print("Enlarge Finished");
    }

    IEnumerator ShrinkY()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.clip = shrinkSound;
        audioSource.Play();

        var cnt = 0;
        while (transform.localScale.y / 1 > percent && cnt <= 1000)
        {
            cnt++;
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y * 0.99f, transform.localScale.z);
            yield return new WaitForSeconds(0.008f);
        }
        stateIsLarge = false;
        canChange = true;
        print("Shrink Finished");
    }

    IEnumerator EnlargeY()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.clip = enlargeSound;
        audioSource.Play();

        var cnt = 0;
        while (transform.localScale.y < 1 && cnt <= 1000)
        {
            cnt++;
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y * 1.05f, transform.localScale.z);
            yield return new WaitForSeconds(0.008f);
        }
        stateIsLarge = true;
        canChange = true;
        print("Enlarge Finished");
    }

    IEnumerator ShrinkZ()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.clip = shrinkSound;
        audioSource.Play();

        var cnt = 0;
        while (transform.localScale.z / 1 > percent && cnt <= 1000)
        {
            cnt++;
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z * 0.99f);
            yield return new WaitForSeconds(0.008f);
        }
        stateIsLarge = false;
        canChange = true;
        print("Shrink Finished");
    }

    IEnumerator EnlargeZ()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.clip = enlargeSound;
        audioSource.Play();

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
