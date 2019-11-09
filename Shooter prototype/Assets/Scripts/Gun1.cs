using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun1 : Gun
{    
    public GameObject ParentObject;    
    public GameObject PrefabBullet;
    public bool PressFire = false;
    public bool BulletHit = false;

    private GameObject _activeBullet;
    public float RateOfFire = 2.1f; //seconds for one bullet
    private float _timeForNextFire;
    
    void Start()
    {        
        ParentObject = this.transform.root.gameObject;
    }

    
    void Update()
    {
        if (AmountAmmo > 30)
        {
            AmountAmmo = 30;
        }

        #region Gun functions        
        if (PressFire)
        {            
            if (AmountAmmo >= 1 && Time.time > _timeForNextFire)
            {                
                _activeBullet = Instantiate(PrefabBullet, transform.position, Quaternion.identity);
                _activeBullet.transform.forward = gameObject.transform.forward;
                _activeBullet.transform.localScale = ParentObject.GetComponentInParent<Transform>().localScale/10;                
                _timeForNextFire = Time.time + RateOfFire;
                BulletHit = true;
                AmountAmmo--;
            }
            else
            {
                BulletHit = false;
            }
        }
        #endregion
    }
    
}
