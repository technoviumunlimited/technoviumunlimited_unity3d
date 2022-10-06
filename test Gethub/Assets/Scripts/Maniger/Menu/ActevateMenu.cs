using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActevateMenu : MonoBehaviour
{
    void Start()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public GameObject Menu;
    bool MenuActiv = false;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && MenuActiv == false)
        {
            Menu.SetActive(true);
            MenuActiv = true;
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
        }
        else if(Input.GetKeyDown(KeyCode.Escape )&& MenuActiv == true)
        {
            Menu.SetActive(false);
            MenuActiv = false;
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
        }
    } 
}
