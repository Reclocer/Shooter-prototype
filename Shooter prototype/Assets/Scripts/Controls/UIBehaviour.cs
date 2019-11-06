using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class UIBehaviour : MonoBehaviour
{
    private GameObject _player;
    public GameObject HealthUI;
    public GameObject PowerUI;
    public GameObject GunNameUI;
    public GameObject AmountAmmoUI;

    
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player"); 
    }

    
    void Update()
    {
        // set UI text
        HealthUI.GetComponent<Text>().text = Convert.ToString(_player.GetComponent<Character>().Health);
        PowerUI.GetComponent<Text>().text = Convert.ToString(_player.GetComponent<Character>().Power);
        GunNameUI.GetComponent<Text>().text = _player.GetComponent<Character>().GunN1.name;
        AmountAmmoUI.GetComponent<Text>().text = Convert.ToString(_player.GetComponent<Character>().GunN1.GetComponent<Gun1>().AmountAmmo);

    }
}
