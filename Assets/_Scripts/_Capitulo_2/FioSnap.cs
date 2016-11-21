using UnityEngine;
using System.Collections;
using TouchScript.Gestures;

public class FioSnap : MonoBehaviour {

	private TransformGesture Tc;
	public int Numero;
	public GameObject[] Entrada;

	public GameObject SelectVisualizer;

	private Vector3 PosInicial;

	public bool Select = false;

	bool BusySlot;


	// Use this for initialization
	void Start () {

		PosInicial = gameObject.transform.position;
		
		Tc = gameObject.GetComponent<TransformGesture>();
	}

	// Update is called once per frame
	void Update () {

		if (Select)
			SelectVisualizer.SetActive (true);
		else
			SelectVisualizer.SetActive (false);
	}

	int CheckEntrada(GameObject hit){
		for (int i = 0; i < Entrada.Length; i++) {
			if (Entrada [i] == hit) {
				return (i);
			}
		}
		return (-1);
	}

	void OnTriggerEnter2D(Collider2D hit){

		if (hit.gameObject.name == "nope") {
			gameObject.transform.position = PosInicial;
			Tc.Cancel();
		}
		if (hit.gameObject.tag == "snap") {
			GameManager Controller = GameObject.Find ("GameControl").GetComponent<GameManager> ();
			Tc.Cancel();
			if (Controller.CurrentButtons [CheckEntrada (hit.gameObject)] == "None") {
				gameObject.transform.position = hit.gameObject.transform.position;
							
			} else {
				gameObject.transform.position = PosInicial;
				BusySlot = true;
				return;
			}
				
			if (hit.gameObject == Entrada [Numero])
				Controller.AddCheck (CheckEntrada(hit.gameObject));
			else {
				Controller.AddWrong (CheckEntrada(hit.gameObject));
			}
				

		}
	}
	void OnTriggerExit2D(Collider2D hit){
		GameManager Controller = GameObject.Find ("GameControl").GetComponent<GameManager> ();
		if (BusySlot) {
			BusySlot = false;
			return;
		} 
		if (hit.gameObject.tag == "snap" && hit.gameObject == Entrada [Numero])
			Controller.RemoveCheck(CheckEntrada(hit.gameObject));
		else{
			Controller.RemoveWrong(CheckEntrada(hit.gameObject));			
		}
		}
}
