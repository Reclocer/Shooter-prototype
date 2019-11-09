using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot : MonoBehaviour
{
    [Header("Values")]
    public float Health = 100;
    public float Power = 100;
    public int EnterDamage = 0;
    public bool EnterDamageBool = false;
    public int ExitDamage = 0;

    public float _speed = 3;
    protected float _rotateSpeed = 7;
    protected float _rotate = 0;
    protected float _minPower = 5;
    protected float _mass = 80;


    // damage values 
    protected Vector3 _vector;
    protected int _rateOfChangeScale = 1;
    protected bool _regenPower = false;
    protected float _scale = 0;
    protected float _coefficientScale = 0.02f;
    protected float _coefficientPower = 1;
    protected float _highMassDamage = 0;

    
    public void GetDamage(float damage)
    {

    }
}
