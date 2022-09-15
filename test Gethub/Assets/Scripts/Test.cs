using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{

    public Transform transform;
    public float speed = 1f;
    public Vector3 derection  = new Vector3(0,1,0);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += derection * speed * Time.deltaTime ;
        if(derection > niew Vector3(-1,-1,-1)){ derection -= niew Vector3(1,1,1)} else {derection += niew Vector3(1,1,1)}
        
    }
}
