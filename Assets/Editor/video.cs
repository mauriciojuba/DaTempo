using UnityEngine;
using System.Collections;

public class video : MonoBehaviour {

	// Use this for initialization
	void OnEnable ()
    {
        ((MovieTexture)GetComponent<Renderer>().material.mainTexture).Play();
    }
    void OnDisable()
    {
        ((MovieTexture)GetComponent<Renderer>().material.mainTexture).Stop();
    }
    // Update is called once per frame
    void Update () {
	
	}
}
