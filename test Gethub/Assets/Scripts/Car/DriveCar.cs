using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriveCar : MonoBehaviour
{

    public float Speed = 10;
    public float steeringSpeed = 1;

    float MySpeed;
    float Vertical;
    float Horizontal;
    bool Break;


    Rigidbody rb;
    Vector3 lastPosition;
    public KeyCode BreakKey = KeyCode.Space;
     
    void Start()
    {
        rb = GetComponent<Rigidbody>();       
    }

    void FixedUpdate ()
    {
        
        

        
        if (Break == true && MySpeed > 15) { rb.AddForce( this.transform.forward *10   * (Speed /3) * -1,ForceMode.Force);}
        else 
        {
            if(Vertical > 0)
        {
            rb.AddForce( this.transform.forward *10  *Vertical  * Speed,ForceMode.Force);

            this.transform.Rotate(new Vector3(0,Horizontal/ 100* MySpeed * steeringSpeed,0));
        }
        else if (Vertical < 0 )
        {
            rb.AddForce( this.transform.forward *10  *Vertical  * (Speed /3),ForceMode.Force);

            this.transform.Rotate(new Vector3(0, (Horizontal * -1)/ 100* MySpeed * steeringSpeed,0));
        }
        else  this.transform.Rotate(new Vector3(0,Horizontal/ 100* MySpeed * steeringSpeed,0));
        }
    }
    void Update()
    {
        SpeedCalculator();
        MyInput ();
    }

    void MyInput ()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");
        Vertical = Input.GetAxisRaw("Vertical");
        if( Input.GetKey(BreakKey)){ Break =true;} else {Break = false;}
    }

    void SpeedCalculator() 
    {    
        MySpeed = (transform.position - lastPosition).magnitude / Time.deltaTime;
        lastPosition = transform. position;
    }
}
