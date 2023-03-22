using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory3Manager : MonoBehaviour
{
   public List<GameObject> _firstDetailList = new List<GameObject>();
   public List<GameObject> _secondDetailList = new List<GameObject>();

   public Transform _firstDetialPoint, _secondDetailPoint;
   public GameObject _firstDetailPrefab, _secondDetailPrefab;

    void Start()
    {
        StartCoroutine(Work());
    }

    IEnumerator Work()
    {
        while (true)
        {
            if (_firstDetailList.Count > 0 && _secondDetailList.Count > 0) 
            {
                RemoveLast(_firstDetailList);
                RemoveLast(_secondDetailList);
            }
            yield return new WaitForSeconds(0.5f);
        }
       
    }

    public void GetDetail(List<GameObject> _detailList, GameObject _detailPrefab,  Transform _detialPoint)
    {
        GameObject _temp = Instantiate(_detailPrefab);
        _temp.transform.position = new Vector3(
            _detialPoint.position.x, 0.8f+((float)_detailList.Count / 20), _detialPoint.position.z); 
        _detailList.Add(_temp);
    }

    public void RemoveLast(List<GameObject> _detailList)
    {
        if (_detailList.Count > 0)
        {
            Destroy(_detailList[_detailList.Count -1]);
            _detailList.RemoveAt(_detailList.Count -1);
        }
    }
}
