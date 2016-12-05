using UnityEngine;
using System.Collections;

public class ParticleDestroy : MonoBehaviour {

    public float Time = 1f;

	// Use this for initialization
	void Start () {
        Destroy(gameObject, Time);
	}
}
