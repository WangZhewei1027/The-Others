using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject mainMenu;
    private bool showCursor = false;

    // Start is called before the first frame update
    void Start()
    {
        mainMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            showCursor = !showCursor;

            if (showCursor)
            {
                mainMenu.SetActive(true);
                Cursor.lockState = CursorLockMode.Confined;
            }
            else
            {
                mainMenu.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void BackToGame()
    {
        showCursor = false;
        mainMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }
    
}
