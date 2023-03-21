using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectManager : MonoBehaviour
{
    public List<GameObject> _detailList = new List<GameObject>();
    public GameObject _detailPrefab;
    public Transform _collectPoint;

    private int _detailLimit = 10;

    private void OnEnable()
    {
        TriggerManager.OnDetailCollect += GetDetail;
    }

    private void OnDisable() 
    {
        TriggerManager.OnDetailCollect -= GetDetail;
    }
     
    private void GetDetail()
    {
        if (_detailList.Count <= _detailLimit)
        {
            GameObject _temp = Instantiate(_detailPrefab, _collectPoint);
            _temp.transform.position = new Vector3(_collectPoint.position.x, 
            0.5f - ((float)_detailList.Count / 20), _collectPoint.position.z);
            _detailList.Add(_temp);

        }
    }
}
