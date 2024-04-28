using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelTrigger : MonoBehaviour
{
    public string nextSceneName;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }

}
