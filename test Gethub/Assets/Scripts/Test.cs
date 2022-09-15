using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{

    public Transform transform;
    public float speed = 1f;
    public Vector3 derection  = new Vector3(1,1,1);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += derection * speed * Time.deltaTime ;
        if(transform.position.x > 5) { derection = new Vector3(-1,-1,-1); } 
        else if(transform.position.x < -5) {derection = new Vector3(1,1,1); }
        
    }
}
