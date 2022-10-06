using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{

    public Vector3 destination ;
    public ParticleSystem ParticleSystem;
    void OnTriggerEnter(Collider other)
    {   
        other.transform.parent.position = destination;
        Debug.Log(destination);
        Instantiate(ParticleSystem, destination, transform.rotation );
    }   

}
