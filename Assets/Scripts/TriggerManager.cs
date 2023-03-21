using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerManager : MonoBehaviour
{
    public delegate void OnCollectArea();
    public static event OnCollectArea OnDetailCollect;
    public static ProductionManager productionManager;

    public delegate void OnFabricArea();
    public static event OnFabricArea OnDetailGive;

    private bool isCollecting, isGiving;

    private void Start() 
    {
        StartCoroutine(CollectEnum());
    }
       
    IEnumerator CollectEnum()
    {
        while (true)
        {
            if (isCollecting == true)
            {
                OnDetailCollect();
            }

            if (isGiving == true)
            {
                OnDetailGive();
            }

            yield return new WaitForSeconds(0.5f);
        }

    }

    private void OnTriggerStay(Collider other) 
    {
        if (other.gameObject.CompareTag("CollectArea"))
        {
            isCollecting = true;
            productionManager = other.gameObject.GetComponent<ProductionManager>();
        }

        if (other.gameObject.CompareTag("WorkArea"))
        {
            isGiving = true;
        }
        
    }
    private void OnTriggerExit(Collider other) 
    {
         if (other.gameObject.CompareTag("CollectArea"))
        {
            isCollecting = false;
            productionManager = null;
        }
        if (other.gameObject.CompareTag("WorkArea"))
        {
            isGiving = false;
        }
    }
}
