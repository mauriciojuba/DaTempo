using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public InteractionPuzzleB _unet;

	int[] Checklist = new int[3];
	public string[] CurrentButtons = new string[] {"None","None","None"};
	public string[] RightButtons = new string[] {"Check","Check","Check"};

	public GameObject[] Fusiveis;

    public AudioManager Effect;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void AddCheck(int Number){
        Effect.playSound("ColocaFusivel");
		print("Funfa vem " + Number);
		CurrentButtons[Number] = "Check";
		print (Check ());
	}

	public void RemoveCheck(int Number){
        Effect.playSound("TiraFusivel");
        print ("Saiu " + Number);
		CurrentButtons[Number] = "None";
		print (Check ());
	}

	public void AddWrong(int Number){
        Effect.playSound("ColocaFusivel");
        print ("Ta errado "+ Number);
		CurrentButtons [Number] = "Wrong";
		print (Check ());
	}

	public void RemoveWrong(int Number){
        Effect.playSound("TiraFusivel");
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
                Effect.playSound("PainelErro");
				Reset ();
                _unet._graxa();
                return ("Wrong");
			}
		}
        Effect.playSound("PainelAcerto");
        _unet.received_closeDoor();
        _unet.lightON();
		return("Correct");



	}

	public void Reset(){
        //tira vida
		for (int i = 0; i < CurrentButtons.Length; i++) { 
			CurrentButtons[i] = "None";
		}

		for (int i = 0; i < Fusiveis.Length; i++) { 
			Fusiveis [i].GetComponent<FioSnap> ().transform.position = Fusiveis [i].GetComponent<FioSnap> ().PosInicial;

		}
	}
}
