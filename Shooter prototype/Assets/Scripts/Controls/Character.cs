using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Character : MonoBehaviour

{
    //Animator _Animator;
    [Header("Prefabs")]
    public GameObject GunN1 = null;

    [Header("Values")]
    public RaycastHit Hit;
    private Ray _ray;
    public float Health = 100;
    public float Power = 100;
    public int EnterDamage = 0;
    public bool EnterDamageBool = false;
    public int ExitDamage = 0;

    public float _speed = 3;
    private float _rotateSpeed = 7;
    private float _rotate = 0;
    private float _minPower = 5;
    private float _mass = 80;

    
    

    // damage values 
    private Vector3 _vector;
    private int _rateOfChangeScale = 1;
    private bool _regenPower = false;
    private float _scale = 0;
    private float _coefficientScale = 0.02f;
    private float _coefficientPower = 1;
    private float _highMassDamage = 0;

    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Start()
    {
        this.GetComponent<Rigidbody>().mass = _mass;
        Hit = new RaycastHit();
    }

    void Update()
    {
        _ray.origin = transform.position;
        _ray.direction = transform.forward;
        if (Physics.Raycast(_ray, out Hit))
        {
            Debug.Log(Hit.transform.name);
        }

        #region Move commands       

        if (Input.GetKey(KeyCode.W) && Power > _minPower && _regenPower == false)
        {
            transform.Translate(Vector3.forward * _speed * Time.deltaTime);
            Power -= 0.5f * _coefficientPower;
            Health -= _highMassDamage * 1.3f;
        }

        if (Input.GetKey(KeyCode.S) && Power > _minPower && _regenPower == false)
        {
            transform.Translate(Vector3.back * (_speed * 0.7f) * Time.deltaTime);
            Power -= 0.5f * _coefficientPower;
            Health -= _highMassDamage * 1.2f;
        }

        if (Input.GetKey(KeyCode.D) && Power > _minPower && _regenPower == false)
        {
            transform.Translate(Vector3.right * (_speed * 0.4f) * Time.deltaTime);
            Power -= 0.4f * _coefficientPower;
            Health -= _highMassDamage * 1.1f;
        }

        if (Input.GetKey(KeyCode.A) && Power > _minPower && _regenPower == false)
        {
            transform.Translate(Vector3.left * (_speed * 0.4f) * Time.deltaTime);
            Power -= 0.4f * _coefficientPower;
            Health -= _highMassDamage * 1.1f;
        }

        if (Input.GetKeyDown(KeyCode.Space) && Power > _minPower && _regenPower == false)
        {
            transform.Translate(Vector3.up * (_speed * 3f) * Time.deltaTime);
            Power -= 0.9f * _coefficientPower;
            Health -= _highMassDamage * 1.6f;
        }

        if (Input.GetAxis("Mouse X") != 0)
        {
            _rotate = _rotateSpeed * Input.GetAxis("Mouse X");
            transform.Rotate(0, _rotate, 0);
        }

        if (Input.GetMouseButtonDown(0))
        {
            GunN1.GetComponent<Gun1>().PressFire = true;
            if (GunN1.GetComponent<Gun1>().BulletHit && Hit.transform.tag == "bot")            
            {   
                
                Hit.transform.GetComponent<Bot1>().EnterDamage += GunN1.GetComponent<Gun1>().PrefabBullet.GetComponent<Bullet1>().Damage;
                Hit.transform.GetComponent<Bot1>().EnterDamageBool = GunN1.GetComponent<Gun1>().BulletHit;
                this.ExitDamage += GunN1.GetComponent<Gun1>().PrefabBullet.GetComponent<Bullet1>().Damage;
            }
        }
        else
        {
            GunN1.GetComponent<Gun1>().PressFire = false;
        }
        #endregion
        
        #region Decrement
        // Enter damage
        if (Input.GetKeyDown(KeyCode.O))
        {
            EnterDamage += 50;
            
            if (Health > 10 )
            {
                Health -= 10;
            }
            else
            {
                //SceneManager.LoadScene("Main"); 
            }
        }

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
            transform.localScale -=  new Vector3(0.001f, 0.001f, 0.001f);
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

            GetComponentInChildren<Camera>().farClipPlane -= 0.03f; // change render range

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
        if (Input.GetKeyDown(KeyCode.P))
        {
            ExitDamage += 50;
        }

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

            GetComponentInChildren<Camera>().farClipPlane += 0.03f; // change render range

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

    private void FixedUpdate()
    {
        //Health regeneration
        if (Health < 100)
        {
            Health++;
        }
        else if (Health > 100)
        {
            Health = 100;
        }

        //Power regeneration
        if (Power < 100)
        {
            Power += 0.5f;
        }

        if (Power > 100)
        {
            Power = 100;
        }

        if (Power <= (_minPower + 5))
        {
            _regenPower = true;
        }
        else if (Power >= 30)
        {
            _regenPower = false;
        }
    }

    // Pick up amunition
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ammo1")
        {
            if (GunN1 && GunN1.GetComponent<Gun1>().AmountAmmo < 30)
            {
                GunN1.GetComponent<Gun1>().AmountAmmo += other.gameObject.GetComponent<Ammo1>().AmountAmmo;   
                Destroy(other.gameObject);
            }
        }
    }
}
