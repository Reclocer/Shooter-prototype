using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [HideInInspector]public bool NeedObject = false;
    [HideInInspector]public bool HaveObject = false;
    private GameObject _spawner;
    private GameObject _prefabSpawnObject;
    private GameObject _objectAtPoint;    

    void Start()
    {
        _spawner = GetComponentInParent<Spawner>().gameObject;
        _prefabSpawnObject = _spawner.GetComponent<Spawner>().PrefabSpawnObject;
    }
    
    void Update()
    {
        if(NeedObject == true)
        {
            _objectAtPoint = Instantiate(_prefabSpawnObject, transform.position, Quaternion.identity, transform);           
            NeedObject = false;
            HaveObject = true;
        }

        if (!_objectAtPoint && HaveObject)
        {
            _spawner.GetComponent<Spawner>().AmountObjectsAtScene--;
            HaveObject = false;
        }
    }
}
