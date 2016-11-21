using UnityEngine;
using System.Collections;

public class ControladorDeFusil : MonoBehaviour {

	public GameObject[] fusil , plug;

	public void Click(string name){

		if (name == "null") {
			for (int i = 0; i < fusil.Length; i++)
				fusil [i].GetComponent<FioSnap> ().Select = false;
		}

		if (GameObject.Find (name).tag == "Fusil") {
			for (int i = 0; i < fusil.Length; i++) {
				fusil [i].GetComponent<FioSnap> ().Select = false;
				if (name == fusil [i].name) {
					fusil [i].GetComponent<FioSnap> ().Select = true;
				}
			}
		}


		for (int i = 0; i < plug.Length; i++) {
			
			if (name == plug [i].name) {
				
				for (int a = 0; a < fusil.Length; a++) {
					
					if (fusil [a].GetComponent<FioSnap> ().Select == true)
						fusil [a].transform.localPosition = plug [i].transform.localPosition;
					
			
				}
			}
		}
	}
}