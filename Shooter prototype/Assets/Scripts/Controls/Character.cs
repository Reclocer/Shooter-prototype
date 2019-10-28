using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour

{
    //Animator _Animator;
    [Header("Prefabs")]
    public GameObject Weapon;

    [Header("Values")]
    public int Health = 100;
    public int EnterDamage = 0;

    public float _speed = 3;
    private float _rotateSpeed = 10;
    private float _rotate = 0;

    // damage values 
    private Vector3 _vector;
    private int _rateOfChangeScale = 1;
    private float _scale = 0;
    private float _coefficientScale = 0.02f;
    
   

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * _speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * (_speed-1) * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * _speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * _speed * Time.deltaTime);
        }

        if (Input.GetAxis("Mouse X") != 0)
        {
            _rotate = _rotateSpeed * Input.GetAxis("Mouse X");
            transform.Rotate(0, _rotate, 0);
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            EnterDamage = 50;
        }

        if (EnterDamage != 0)
        {
            _scale = EnterDamage * _coefficientScale;
            transform.localScale -=  new Vector3(0.001f, 0.001f, 0.001f);

            if (EnterDamage >= _rateOfChangeScale)
            {
                EnterDamage -= _rateOfChangeScale;
            }
            else
            {
                EnterDamage = 0;
            }
            
            
        }

        
    }
}
