using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterCar : MonoBehaviour
{
   public GameObject Player;
    public GameObject CarCamera;
    public Animator animator;
    public DriveCar driveCar;
    public Transform exsitPosition;

    bool inCar = false;

    void Start()
    {
        //Player = GameObject.FindWithTag("Player");
    }

    void OnTriggerStay(Collider other)
    {     
        if (other.name =="PlayerOBJ" && Input.GetKeyDown(KeyCode.E) && inCar == false)
        {
           StartCoroutine(enterCar());
        }
    }

    void Update(){
        if (inCar == true && driveCar.SpeedCalculator() <= 15 && Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(exsitCar());
        }
    }

    IEnumerator  exsitCar()
    {
        
        animator.SetTrigger("Exsit");
        yield return new WaitForSeconds(1f);
        CarCamera.SetActive(false);
        Player.SetActive(true);
        driveCar.enabled = false;
        Player.transform.position = exsitPosition.position; 
        Player.transform.rotation = Quaternion.LookRotation (transform.position - Player.transform.position);
        inCar = false;
        
    }

      IEnumerator enterCar ()
      {
        animator.SetTrigger("Enter");
        Player.SetActive(false);
        CarCamera.SetActive(true);
        yield return new WaitForSeconds(1f);
        inCar = true;        
        driveCar.enabled = true;
      }
}
