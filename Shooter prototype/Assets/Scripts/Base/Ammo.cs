using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    private int _amountAmmo = 30;
    protected int AmountAmmo 
    {
        get
        {
           return _amountAmmo;
        }            
    }
}
