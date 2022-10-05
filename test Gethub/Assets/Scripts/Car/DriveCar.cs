using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriveCar : MonoBehaviour
{
    Rigidbody rb;
    public float Speed;
    public float SpeedBackwards;
    public float SteeringSpeed;
    float Vertical;
    float Horizontal;
    float YRotation;
    Vector3 lastPosition = Vector3.zero;
   public float speedCar;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        YRotation = 90;
    }
    void Update()
    {
        input();
    }

    void input()
    {
        Vertical=  Input.GetAxis("Vertical");
        Horizontal= Input.GetAxis("Horizontal");
    }

    void FixedUpdate()
    {   
        
        this.transform.rotation = Quaternion.Euler(new Vector3( this.transform.rotation.x,YRotation ,this.transform.rotation.z ));
        
        if(Vertical >= 0) // voor uit
        {
            rb.AddForce(this.transform.forward * Speed * Vertical);
            
            YRotation = YRotation +  (Horizontal * SteeringSpeed * speedCar);
        }
        else if(Vertical < 0) // achter uit
        {
            rb.AddForce(this.transform.forward * SpeedBackwards * Vertical);
 
            YRotation = YRotation - (Horizontal * SteeringSpeed * speedCar * 2f);
        }
        
        SpeedCar();
    }

         
    void SpeedCar()
    {
        
        speedCar = (transform.position - lastPosition).magnitude;
        lastPosition = transform.position;
    }



     
}










