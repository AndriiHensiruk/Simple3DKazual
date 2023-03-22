using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory2Manager : MonoBehaviour
{
    public List<GameObject> _detailList = new List<GameObject>();
    public List<GameObject> _nextDetailList = new List<GameObject>();

    public Transform _detialPoint, _nextDetailPoint;
    public GameObject _detailPrefab, _nextDetailPrefab;

    private void Start()
    {
        StartCoroutine(GenerateDetail());
    }

    IEnumerator GenerateDetail()
    {
        while (true)
        {
            if (_detailList.Count > 0) 
            {
                GameObject _temp = Instantiate(_nextDetailPrefab);
                _temp.transform.position = new Vector3(
                    _nextDetailPoint.position.x, ((float)_nextDetailList.Count / 10), _nextDetailPoint.position.z); 
                _nextDetailList.Add(_temp);
                RemoveLast();
            }
            yield return new WaitForSeconds(0.5f);
        }
       
    }

    public void GetDetail()
    {
        GameObject _temp = Instantiate(_detailPrefab);
        _temp.transform.position = new Vector3(
            _detialPoint.position.x, 0.8f+((float)_detailList.Count / 20), _detialPoint.position.z); 
        _detailList.Add(_temp);
    }

    public void RemoveLast()
    {
        if (_detailList.Count > 0)
        {
            Destroy(_detailList[_detailList.Count -1]);
            _detailList.RemoveAt(_detailList.Count -1);
        }
    }
}
