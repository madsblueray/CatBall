using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDisabledHandler : MonoBehaviour
{
    [SerializeField]
    public ParticleSystem parsys;
    public event System.Action<GameObject> OnObjectDisabled;
    void OnDisable()
    {
        if( OnObjectDisabled != null ) 
        {
            OnObjectDisabled(gameObject);
        }
    }

    public void CreateParticles()
    {
        ParticleSystem particles = Instantiate(parsys, transform.position, transform.rotation);
    }
}
