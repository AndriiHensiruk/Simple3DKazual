using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory3Manager : MonoBehaviour
{
    public List<GameObject> _detailList = new List<GameObject>();
    public List<GameObject> _nextDetailList = new List<GameObject>();
    public List<GameObject> _finishDetailList = new List<GameObject>();

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
                    _nextDetailPoint.position.x, ((float)_finishDetailList.Count / 10), _nextDetailPoint.position.z); 
                _finishDetailList.Add(_temp);
                RemoveLast(_detailList);
                RemoveLast(_nextDetailList);
            }
            yield return new WaitForSeconds(1f);
        }
       
    }

    public void GetDetail()
    {
        GameObject _temp = Instantiate(_detailPrefab);
        _temp.transform.position = new Vector3(
            _detialPoint.position.x, 0.8f+((float)_detailList.Count / 20), _detialPoint.position.z); 
        _detailList.Add(_temp);
    }
    
    public void GetNextDetail()
    {
        GameObject _temp = Instantiate(_nextDetailPrefab);
        _temp.transform.position = new Vector3(
            _nextDetailPoint.position.x, 0.8f+((float)_nextDetailList.Count / 20), _nextDetailPoint.position.z); 
        _nextDetailList.Add(_temp);
    }

   public void RemoveLast(List<GameObject> _detail)
    {
        if (_detail.Count > 0)
        {
            Destroy(_detail[_detail.Count -1]);
            _detailList.RemoveAt(_detail.Count -1);
        }
    }
}
