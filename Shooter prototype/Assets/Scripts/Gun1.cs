using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun1 : Gun
{
    private Vector3 _bulletStartPosition;
    public GameObject ParentObject; 
    public GameObject PrefabBullet;
    private GameObject _activeBullet;
    public float RateOfFire = 2.1f; //seconds for one bullet
    private float _timeForNextFire;
    
    void Start()
    {
        ParentObject = GameObject.FindGameObjectWithTag("Player");
    }

    
    void Update()
    {
        if (AmountAmmo > 30)
        {
            AmountAmmo = 30;
        }

        #region Gun functions        
        if (Input.GetMouseButtonDown(0))
        {            
            if (AmountAmmo >= 1 && Time.time > _timeForNextFire)
            {
                //_bulletStartPosition = transform.position.z + 4;
                _activeBullet = Instantiate(PrefabBullet, transform.position, Quaternion.identity);
                _activeBullet.transform.forward = gameObject.transform.forward;
                _activeBullet.transform.localScale = ParentObject.GetComponentInParent<Transform>().localScale/10;
                Debug.Log(ParentObject.GetComponentInParent<Transform>().localScale);
                AmountAmmo--;                
                _timeForNextFire = Time.time + RateOfFire;
            }
        }
        #endregion
    }

    
}
