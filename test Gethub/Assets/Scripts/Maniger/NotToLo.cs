using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotToLo : MonoBehaviour
{
    public Transform player;
    Vector3 StartPosition;
    void Start()
    {
        StartPosition = player.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(player.position.y < -1){
            player.position = StartPosition;
            
        }
    }
}
