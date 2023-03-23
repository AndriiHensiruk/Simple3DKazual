using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerManager : MonoBehaviour
{
    public delegate void OnCollectArea();
    public static event OnCollectArea OnDetailCollect;
    public static Factory1Manager factory1Manager;

    public delegate void OnFabricArea();
    public static event OnFabricArea OnDetailGive;
    public static Factory2Manager factory2Manager;

    public delegate void OnFinishArea();
    public static Factory3Manager factory3Manager;

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
        if (other.gameObject.CompareTag("Factory1"))
        {
            isCollecting = true;
            factory1Manager = other.gameObject.GetComponent<Factory1Manager>();
        }

        if (other.gameObject.CompareTag("Factory2"))
        {
            isGiving = true;
            factory2Manager = other.gameObject.GetComponent<Factory2Manager>();
        }

         if (other.gameObject.CompareTag("Factory3"))
        {
            isGiving = true;
            factory3Manager = other.gameObject.GetComponent<Factory3Manager>();
        }
        
    }
    private void OnTriggerExit(Collider other) 
    {
         if (other.gameObject.CompareTag("Factory1"))
        {
            isCollecting = false;
            factory1Manager = null;
        }
        if (other.gameObject.CompareTag("Factory2"))
        {
            isGiving = false;
            factory2Manager = null;
        }
        if (other.gameObject.CompareTag("Factory3"))
        {
            isGiving = false;
            factory3Manager = null;
        }
    }
}
