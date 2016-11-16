using UnityEngine;
using System.Collections;
using TouchScript.Gestures;

public class MudaPag : MonoBehaviour {

	private Vector3 PosInicial;
	private TransformGesture Tc;


	// Use this for initialization
	void Start () {

		PosInicial = gameObject.transform.position;
		Tc = gameObject.GetComponent<TransformGesture>();

	
	}
	
	// Update is called once per frame
	void Update () {

	
	}

	void OnTriggerEnter2D(Collider2D hit){
		Livro Virapag = GameObject.Find ("Livro").GetComponent<Livro> ();

		if (hit.gameObject.name == "next") {
			Tc.Cancel ();
			Virapag.ProcimaPagina ();
			gameObject.transform.position = PosInicial;
		}

		if (hit.gameObject.name == "prev") {
			Tc.Cancel ();
			Virapag.PaginaAnterior ();
			gameObject.transform.position = PosInicial;
		}
	}
}
