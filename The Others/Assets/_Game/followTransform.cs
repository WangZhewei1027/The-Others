using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followTransform : MonoBehaviour
{
    public GameObject posX;
    public GameObject posY;
    public GameObject posZ;
    public GameObject rotX;
    public GameObject rotY;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(posX.transform.position.x, posY.transform.position.y, posZ.transform.position.z);
        this.transform.rotation = Quaternion.Euler(rotX.transform.rotation.eulerAngles.x,rotX.transform.rotation.eulerAngles.y, 0);
    }
}
