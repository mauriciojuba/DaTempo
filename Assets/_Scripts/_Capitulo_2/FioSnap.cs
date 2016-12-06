using UnityEngine;
using System.Collections;
using TouchScript.Gestures;

public class FioSnap : MonoBehaviour {

	private TransformGesture Tc;
	public int Numero;
	public GameObject[] Entrada;
	public GameObject SelectVisualizer;
	public Vector3 PosInicial;
	public bool Select = false;
	bool BusySlot;
    GameManager Controller;


    // Use this for initialization
    void Start () {
        Controller = GameObject.Find("GameControl").GetComponent<GameManager>();
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
			Tc.Cancel();
			if (Controller.CurrentButtons [CheckEntrada (hit.gameObject)] == "None") {
				gameObject.transform.position = hit.gameObject.transform.position;
                if (hit.gameObject == Entrada[Numero])
                    Controller.AddCheck(CheckEntrada(hit.gameObject));
                else
                {
                    Controller.AddWrong(CheckEntrada(hit.gameObject));
                }

            }
            else {
				gameObject.transform.position = PosInicial;
			}
		}
    }
	void OnTriggerExit2D(Collider2D hit){
		if (hit.gameObject.tag == "snap")
			Controller.Remove(CheckEntrada(hit.gameObject));
    }
}
