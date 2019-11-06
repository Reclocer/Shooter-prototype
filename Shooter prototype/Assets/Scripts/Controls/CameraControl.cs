using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{    
    public float _rotateSpeed = 4;
    private float _rotate = 0;

    private Quaternion _originRotation;
    private float _angleVertical = 0;
    private float _mouseSense = 5;

    private void Start()
    {
        _originRotation = transform.rotation;
    }

    void Update()
    {
        
        //if (Input.GetAxis("Mouse Y") != 0 && transform.rotation.x > -0.435 && transform.rotation.x < 0.435)
        if (Input.GetAxis("Mouse Y") != 0)
        {
            _rotate = -_rotateSpeed * Input.GetAxis("Mouse Y");
            transform.Rotate(_rotate, 0, 0);
        }

        /* if (Input.GetAxis("Mouse Y") != 0)
         {
             _rotate = -_rotateSpeed * Input.GetAxis("Mouse Y");
             //_rotate = Mathf.Clamp(_rotate, -5, 5);
             transform.Rotate(_rotate, 0, 0);           
         }*/


        /* if (Input.GetAxis("Mouse Y") != 0)
         {
             _angleVertical += Input.GetAxis("Mouse Y") * _mouseSense;
             _angleVertical = Mathf.Clamp(_angleVertical, -60, 60);

             Quaternion rotationY = Quaternion.AngleAxis(_angleVertical, Vector3.up);

             _originRotation = Quaternion.Euler(_originRotation.x + _angleVertical,  _originRotation.y, _originRotation.z);

             transform.rotation = _originRotation;
         }*/





    }
}
