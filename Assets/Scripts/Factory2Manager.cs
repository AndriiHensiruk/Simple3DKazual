using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Factory2Manager : MonoBehaviour
{
    public List<GameObject> _detailList = new List<GameObject>();
    public List<GameObject> _nextDetailList = new List<GameObject>();
    private bool _isWorking;
    public Transform _detialPoint, _nextDetailPoint;
    public GameObject _detailPrefab, _nextDetailPrefab;
    public TMP_Text _infoText;

    private void Start()
    {
        StartCoroutine(GenerateDetail());
    }

    IEnumerator GenerateDetail()
    {
        while (true)
        {
            if (_isWorking == true) 
            {
                if (_detailList.Count > 0) 
                {
                    _infoText.text = "WORK!!!";
                GameObject _temp = Instantiate(_nextDetailPrefab);
                _temp.transform.position = new Vector3(
                    _nextDetailPoint.position.x, ((float)_nextDetailList.Count / 10), _nextDetailPoint.position.z); 
                _nextDetailList.Add(_temp);
                RemoveLast(_detailList);
                if (_nextDetailList.Count >= 20 )
                {
                    _isWorking = false;
                    Debug.Log("Scklad2 FOOL!!!");
                    _infoText.text = "FOOL!!!";
                } 
                } else  _infoText.text = "Not Material!!!";
            }
            else if (_nextDetailList.Count < 10)
                    {
                        _isWorking = true;
                       
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

    public void RemoveLast(List<GameObject> _detail)
    {
        if (_detail.Count > 0)
        {
            Destroy(_detail[_detail.Count -1]);
            _detailList.RemoveAt(_detail.Count -1);
        }
    }
}
