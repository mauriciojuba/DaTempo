using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	int[] Checklist = new int[3];
	public string[] CurrentButtons = new string[] {"None","None","None"};
	public string[] RightButtons = new string[] {"Check","Check","Check"};
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void AddCheck(int Number){
		print("Funfa vem " + Number);
		CurrentButtons[Number] = "Check";
		print (Check ());
	}

	public void RemoveCheck(int Number){
		print ("Saiu " + Number);
		CurrentButtons[Number] = "None";
		print (Check ());
	}

	public void AddWrong(int Number){
		print ("Ta errado "+ Number);
		CurrentButtons [Number] = "Wrong";
		print (Check ());
	}

	public void RemoveWrong(int Number){
		print("saiu do errado " + Number);
		CurrentButtons [Number] = "None";
		print (Check ());
	}


	string Check(){
		for (int i = 0; i < CurrentButtons.Length; i++) {
			if(CurrentButtons[i].Equals("None")){
				return("Meh");
			}
		}
		for (int i = 0; i < CurrentButtons.Length; i++) {
			if(CurrentButtons[i].Equals("Wrong")){
				return("Wrong");
			}
		}
		//Colocar função de concluir o puzzle aqui.
		return("Correct");



	}
}
