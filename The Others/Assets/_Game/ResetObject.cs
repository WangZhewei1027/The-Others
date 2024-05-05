using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetObject : MonoBehaviour
{
    public float maxY = -20;
    private GameObject[] objects;
    private Transform playerTransform;

    private List<GameObject> taggedObjects = new List<GameObject>();

    void Start()
    {
        // Find all GameObjects tagged "object" and convert the array to a list
        taggedObjects.AddRange(GameObject.FindGameObjectsWithTag("object"));

        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        foreach (GameObject obj in taggedObjects)
        {
            if (obj.transform.position.y < maxY)
            {
                obj.transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y + 20, playerTransform.position.z);
            }
        }
    }
}
