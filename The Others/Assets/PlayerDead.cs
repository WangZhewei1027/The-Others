using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDead : MonoBehaviour
{
    private Transform playerTransform;
    public string thisSceneName;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerTransform.position.y<-20)
        {
            SceneManager.LoadScene(thisSceneName);
        }
    }
}
