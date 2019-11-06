using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet1 : Bullet
{    
    void Start()
    {
        _startPosition = transform.position;
        _range = 50;
    }
    
    void FixedUpdate()
    {
        transform.Translate(Vector3.forward * 2);


        if (Vector3.Distance(_startPosition, transform.position) > _range)
        {
            Destroy(gameObject);
        }          
    }
}
