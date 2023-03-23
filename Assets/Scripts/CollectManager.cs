using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectManager : MonoBehaviour
{
    public List<GameObject> _detailList = new List<GameObject>();
    public List<GameObject> _nextDetailList = new List<GameObject>();

    public Transform _collectPoint;
    public GameObject _detailPrefab, _nextDetailPrefab;

    private int _detailLimit = 10;

    private void OnEnable()
    {
        TriggerManager.OnDetailCollect += GetDetail;
        TriggerManager.OnDetailGive += GiveDetail;
    }

    private void OnDisable() 
    {
        TriggerManager.OnDetailCollect -= GetDetail;
        TriggerManager.OnDetailGive -= GiveDetail;
    }
     
    private void GetDetail()
    {
        if (_detailList.Count <= _detailLimit)
        {
            GameObject _temp = Instantiate(_detailPrefab, _collectPoint);
            _temp.transform.position = new Vector3(_collectPoint.position.x, 
            0.5f - ((float)_detailList.Count / 20), _collectPoint.position.z);
            _detailList.Add(_temp);

            if (TriggerManager.factory1Manager != null)
            {
                TriggerManager.factory1Manager.RemoveLast();
            }
        }
        
    }

   
    private void GiveDetail()
    {
        if (_detailList.Count > 0)
        {
            if (TriggerManager.factory2Manager != null)
            {
                TriggerManager.factory2Manager.GetDetail();
                RemoveLast(_detailList);
            }
            if (TriggerManager.factory3Manager != null)
            {
                TriggerManager.factory3Manager.GetDetail();
                RemoveLast(_detailList);
            } 
           
        }
        if (_nextDetailList.Count > 0 )
        {
            if (TriggerManager.factory3Manager != null)
            {
                TriggerManager.factory3Manager.GetNextDetail();
                RemoveLast(_nextDetailList);
            } 
        }
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
