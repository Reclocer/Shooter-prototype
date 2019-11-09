using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bot1 : Bot
{
    public GameObject GunN1;
    private Ray _ray;
    public RaycastHit Hit;
    NavMeshAgent nav;
    public Transform targer;
    public float RangeOfVisibility = 100;

    private GameObject _player;

    


    //public NavMeshBuilder = new NavMeshBuilder();

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        this.GetComponent<Rigidbody>().mass = _mass;

        Hit = new RaycastHit();
        //StartCoroutine(waitForTime(4));
        //nav = this.GetComponent<NavMeshAgent>();

        //nav.SetDestination(targer.position);


    }

    void Update()
    {        
        if (Vector3.Distance(transform.position, _player.transform.position) < RangeOfVisibility)
        {
            transform.LookAt(_player.transform.position);
            _ray.origin = transform.position;
            _ray.direction = transform.forward;
            Debug.DrawRay(_ray.origin, _player.transform.position, Color.green, 1);
            if (Physics.Raycast(_ray, out Hit))
            {
                Debug.Log(Hit.transform.name);
            }

            if (Hit.transform.name == "Player")
            {
                GunN1.GetComponent<Gun1>().PressFire = true;
                if (GunN1.GetComponent<Gun1>().BulletHit)
                {                    
                    _player.GetComponent<Character>().EnterDamage += GunN1.GetComponent<Gun1>().PrefabBullet.GetComponent<Bullet1>().Damage;
                    _player.GetComponent<Character>().EnterDamageBool = GunN1.GetComponent<Gun1>().BulletHit;
                    this.ExitDamage += GunN1.GetComponent<Gun1>().PrefabBullet.GetComponent<Bullet1>().Damage;
                }
            }
            else
            {
                GunN1.GetComponent<Gun1>().PressFire = false;
            }
        }

        #region Decrement
        if (EnterDamageBool)
        {
            Health -= EnterDamage;
            if (Health < 1)
            {
                //SceneManager.LoadScene("Main");
            }

            EnterDamageBool = false;
        }

        // Change model scale and values
        if (EnterDamage != 0 && transform.localScale.x > 0.05f)
        {           
            transform.localScale -= new Vector3(0.001f, 0.001f, 0.001f);
            _speed -= 0.002f;
            _coefficientPower -= 0.0006f;

            //change mass
            if (_mass > 1)
            {
                _mass -= 0.08f;
                GetComponent<Rigidbody>().mass = _mass;
            }

            if (_highMassDamage > 0)
            {
                _highMassDamage -= 0.0005f;
            }
            else
            {
                _highMassDamage = 0;
            }

            RangeOfVisibility -= 0.03f; // change render range

            // change GunN1 values
            GunN1.GetComponent<Gun1>().RateOfFire -= 0.0001f;

            //decrement EnterDamage
            if (EnterDamage >= _rateOfChangeScale)
            {
                EnterDamage -= _rateOfChangeScale;
            }
            else
            {
                EnterDamage = 0;
            }
        }
        #endregion

        #region Increment
        
        // Change model scale and values
        if (ExitDamage != 0)
        {
            transform.localScale += new Vector3(0.001f, 0.001f, 0.001f);
            _speed += 0.002f;
            _coefficientPower += 0.0006f;

            //change mass            
            _mass += 0.08f;
            GetComponent<Rigidbody>().mass = _mass;
            _highMassDamage += 0.0005f;

            RangeOfVisibility += 0.03f; // change render range

            // change GunN1 values
            GunN1.GetComponent<Gun1>().RateOfFire += 0.0001f;

            //decrement ExitDamage
            if (ExitDamage >= _rateOfChangeScale)
            {
                ExitDamage -= _rateOfChangeScale;
            }
            else
            {
                ExitDamage = 0;
            }
        }
        #endregion
    }

    // Pick up amunition
    private void OnTriggerStay(Collider other)
    {
        Debug.Log(other);
        if (other.gameObject.tag == "ammo1")
        {
            if (GunN1 && GunN1.GetComponent<Gun1>().AmountAmmo < 30)
            {
                GunN1.GetComponent<Gun1>().AmountAmmo += other.gameObject.GetComponent<Ammo1>().AmountAmmo;
                Destroy(other.gameObject);
            }
        }
    }

    //IEnumerator waitForTime (float time)
    //{
    //    yield return new WaitForSeconds(time);
    //    ChangeBehaviour();
    //}

    void ChangeBehaviour()
    {

    }
}
