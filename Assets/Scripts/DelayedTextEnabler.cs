using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DelayedTextEnabler : MonoBehaviour
{
    // Start is called before the first frame update
    public void DelayedEnable()
    {
        StartCoroutine(DECR());
    }

    IEnumerator DECR()
    {
        yield return new WaitForSeconds(2.66f);
        GetComponent<TMP_Text>().enabled=true; 
    }
}
