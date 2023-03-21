using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerManager : MonoBehaviour
{
    public delegate void OnCollectArea();
    public static event OnCollectArea OnDetailCollect;

    private bool isCollecting;

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
            yield return new WaitForSeconds(0.5f);
        }

    }

    private void OnTriggerStay(Collider other) 
    {
        if (other.gameObject.CompareTag("CollectArea"))
        {
            isCollecting = true;
        }
    }
    private void OnTriggerExit(Collider other) 
    {
         if (other.gameObject.CompareTag("CollectArea"))
        {
            isCollecting = false;
        }
    }
}
