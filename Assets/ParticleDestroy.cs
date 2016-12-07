using UnityEngine;
using System.Collections;

public class ParticleDestroy : MonoBehaviour
{

    public float Time = 1f;
    public bool autoDestruir;

    // Use this for initialization
    void Start()
    {
        if(autoDestruir)
        Destroy(gameObject, Time);
    }

    public void Destruir()
    {
        Destroy(gameObject, Time);
    }
}
