using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterCer : MonoBehaviour
{
    bool InCar = false;
    public GameObject Player;
    public DriveCar DriveCar;
    public GameObject  Camera;
    public Animator Animator;
    void OnTriggerStay(Collider other)
    {
        if (other.name == "PlayerOBJ")
        {
            if(Input.GetKeyDown(KeyCode.E))
            {   
                
                if (InCar == false)
                {   
                    Player.SetActive (false);
                    Camera.SetActive (true  );
                    Animator.SetTrigger("Enter");
                }
                
            }
        }
    }
   void enterCar()
    {  
        DriveCar.enabled  =true;
        InCar = true;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
           
            if (InCar == true)
            {
                Animator.SetTrigger("Exsit");
            }
        }
    }
   void exsitCar()
    {
        Player.SetActive (true);
        Camera.SetActive (false  );
        DriveCar.enabled  =false;
        InCar = false;
        Player.transform.position = transform.position;
    }
}
