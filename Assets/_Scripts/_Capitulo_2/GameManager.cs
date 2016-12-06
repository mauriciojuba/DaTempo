using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public InteractionPuzzleB _unet;

	int[] Checklist = new int[3];
	public string[] CurrentButtons = new string[] {"None","None","None"};
	public string[] RightButtons = new string[] {"Check","Check","Check"};
    bool a, b, c;
	public GameObject[] Fusiveis;

    public AudioManager Effect;

	public void AddCheck(int Number){
        Effect.playSound("ColocaFusivel");
		CurrentButtons[Number] = "Check";
        if (Number == 0) a = true;
        if (Number == 1) b = true;
        if (Number == 2) c = true;
        isComplete();
    }

    void isComplete()
    {
        if (a&&b&&c){
            Check();
        }
    }

	public void AddWrong(int Number){
        Effect.playSound("ColocaFusivel");
		CurrentButtons [Number] = "Wrong";
        if (Number == 0) a = true;
        if (Number == 1) b = true;
        if (Number == 2) c = true;
        isComplete();
    }

	public void Remove(int Number){
        Effect.playSound("TiraFusivel");
		CurrentButtons [Number] = "None";
        if (Number == 0) a = false;
        if (Number == 1) b = false;
        if (Number == 2) c = false;
    }
    
	void Check(){
        if(CurrentButtons == RightButtons)
        {
            Effect.playSound("PainelAcerto");
            _unet.received_closeDoor();
            _unet.lightON();
        }
        else
        {
            Effect.playSound("PainelErro");
            Reset();
            _unet._graxa();
        }
        //for (int i = 0; i < CurrentButtons.Length; i++)
        //{
        //    if (CurrentButtons[i].Equals("None"))
        //    {
        //        //nao acontece nada
        //    }
        //}
        //for (int i = 0; i < CurrentButtons.Length; i++)
        //{
        //    if (CurrentButtons[i].Equals("Wrong"))
        //    {
        //        //ta errado
        //        Effect.playSound("PainelErro");
        //        Reset();
        //        _unet._graxa();
        //        return false;
        //    }
        //    else
        //    {
        //        return true;
        //    }
        //}
        //Effect.playSound("PainelAcerto");
        //_unet.received_closeDoor();
        //_unet.lightON();
        //return ("Correct");
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
