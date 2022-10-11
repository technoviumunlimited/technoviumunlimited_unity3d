using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{

    public Vector3 vecDestination ;
    public ParticleSystem ParticleSystem;
    public Transform transDestination;
    public Vector3 destination;
    void OnTriggerEnter(Collider other)
    {   
        

        
        if(!transform == null);
        {
            destination = transDestination.position;
                
        }
        else  
        {
            destination = vecDestination;
        }
        StartCoroutine(Wait(other));
        
    }   
    IEnumerator Wait(Collider other)
    {   other.transform.parent.position = destination;
        
        var par = Instantiate(ParticleSystem, other.transform.parent.position+  other.transform.parent.forward, transform.rotation );
        par.transform.parent = other.transform.parent;
        yield return new WaitForSeconds(1);
        Destroy(par);
    }
}
