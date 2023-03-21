using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductionManager : MonoBehaviour
{
    public List<GameObject> _detailList = new List<GameObject>();
    public GameObject _detailPrefab;
    public Transform _exitPoint;
    private bool _isWorking;
    private int _stackCount = 10;

   
    void Start()
    {
        StartCoroutine(ProductionDetail());
    }

    public void RemoveLast()
    {
        if (_detailList.Count > 0)
        {
            Destroy(_detailList[_detailList.Count -1]);
            _detailList.RemoveAt(_detailList.Count -1);
        }
    }

    IEnumerator ProductionDetail()
    {
        while (true)
        {
            float _detailCount = _detailList.Count;
            int _rowCount = (int)_detailCount / _stackCount;
            if (_isWorking == true) 
            {
                GameObject _temp = Instantiate(_detailPrefab);
                _temp.transform.position = new Vector3
                    (_exitPoint.position.x + ((float)_rowCount / 3), 
                    (_detailCount % _stackCount) / 20, _exitPoint.position.z);
                    _detailList.Add(_temp);

                if (_detailList.Count >=30)
                {
                    _isWorking = false;
                } 
            }
             else if (_detailList.Count < 50)
            {
                _isWorking = true;
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
}
