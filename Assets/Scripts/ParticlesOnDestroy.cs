using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesOnDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    public ParticleSystem parsys;
    
    void OnDestroy()
    {
        ParticleSystem particles = Instantiate(parsys, transform.position, transform.rotation);
    }
}
