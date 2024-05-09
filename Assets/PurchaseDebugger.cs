using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchaseDebugger : MonoBehaviour
{
    public void ProductsFetchedDebugMsg()
    {
        Debug.Log("IAP Products Fetched");
    }
    public void PurchaseCompleteDebugMsg()
    {
        Debug.Log("Purchase Completed");
    }
    public void PurchaseFailedDebugMsg()
    {
        Debug.Log("Purchase Failed");
    }
    public void PurchaseDetailedFailedEventDebugMsg()
    {
        Debug.Log("Purchase Failed (with details)");
    }
}
