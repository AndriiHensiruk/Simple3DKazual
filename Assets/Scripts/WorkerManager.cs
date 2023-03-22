using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkerManager : MonoBehaviour
{
    public List<GameObject> _detailList = new List<GameObject>();

    public Transform _detialPoint;
    public GameObject _detailPrefab;

    public void GetDetail()
    {
        GameObject _temp = Instantiate(_detailPrefab);
        _temp.transform.position = new Vector3(
            _detialPoint.position.x, 0.8f+((float)_detailList.Count / 20), _detialPoint.position.z); 
        _detailList.Add(_temp);
    }
}
