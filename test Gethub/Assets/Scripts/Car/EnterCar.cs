using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterCar : MonoBehaviour
{

    bool InCar = false;
    GameObject Player;
    public GameObject CarCamera;
    public DriveCar driveCar;
    public Animator animator;
    
   
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
    }

    void OnTriggerStay(Collider other)
    {
        if(Input.GetKeyDown(KeyCode.E) && other.name =="PlayerOBJ" && InCar == false)
        {
            enterCar();
        }
    }

    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.E) &&  InCar == true)
        {
            exsitCar(); 
        }
    }

    void enterCar()
    {
        
        Player.SetActive(false);
        CarCamera.SetActive(true);
        driveCar.enabled = true;
    }

    void exsitCar()
    {   
        
        driveCar.enabled = false;
        CarCamera.SetActive(false);
        Player.SetActive(true);
    }
}

