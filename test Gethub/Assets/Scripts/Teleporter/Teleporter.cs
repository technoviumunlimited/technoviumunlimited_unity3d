using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{

    public Vector3 destination ;
    public ParticleSystem ParticleSystem;
    void OnTriggerEnter(Collider other)
    {   
        

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
