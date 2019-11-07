using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    
    //public GameObject ObjectPoint;
    public GameObject[] SpawnPoints;
    private int _maxAmountObjectsAtScene = 0;
    public int AmountObjectsAtScene;
    private int _indexPoint = 0;
    private GameObject _point;
   
    public GameObject PrefabSpawnObject;
    
    //private List<GameObject> _listPoints;
    //public int Length;

    void Awake()
    {
        //_listPoints = new List<GameObject>();
        //_listPoints.Add(Get <SpawnPoint>().gameObject);
        //Debug.Log(_listPoints[2]);

        //if (SpawnPoints.Length > 1)
        //{
        //    Length = SpawnPoints.Length;
        //}


    }

    private void Start()
    {
        _maxAmountObjectsAtScene = AmountObjectsAtScene;
        AmountObjectsAtScene = -1;

        
    }

    void Update()
    {
        if (AmountObjectsAtScene < _maxAmountObjectsAtScene)
        {
            _indexPoint = SpawnPoints.Length;
            _indexPoint = Random.Range(0, _indexPoint);
            _point = SpawnPoints[_indexPoint];
            if (_point.GetComponent<SpawnPoint>().HaveObject == false)
            {
                _point.GetComponent<SpawnPoint>().NeedObject = true;
                AmountObjectsAtScene++;
            }
        }
    }
}
