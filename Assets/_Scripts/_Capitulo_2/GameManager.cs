using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public InteractionPuzzleB _unet;

    public FioSnap FusA, FusB, FusC;
    public bool a, b, c;
    bool isCorrect;

    public AudioManager Effect;
    
    void isComplete()
    {
        if (a&&b&&c){
            Check();
        }
    }

	public void Add(string _name){
        Effect.playSound("ColocaFusivel");
        if (_name == "A") a = true;
        if (_name == "B") b = true;
        if (_name == "C") c = true;
        isComplete();
    }

	public void Remove(string _name)
    {
        Effect.playSound("TiraFusivel");
        if (_name == "A") a = false;
        if (_name == "B") b = false;
        if (_name == "C") c = false;
    }
    void Check()
    {
        if (FusA.atrelado == 1 && FusB.atrelado == 2 && FusC.atrelado == 3) isCorrect = true;
        else isCorrect = false;
        Handler();
    }
	void Handler(){
        if(isCorrect)
        {
            Debug.Log("Correto");
            Effect.playSound("PainelAcerto");
            _unet.received_closeDoor();
            _unet.lightON();
        }
        else
        {
            Debug.Log("Incorreto");
            Reset();
            Effect.playSound("PainelErro");
            Reset();
            _unet._graxa();
        }
    }

	public void Reset(){
        //tiraVida
        FusA.ResetPos();
        FusB.ResetPos();
        FusC.ResetPos();
        a = false;
        b = false;
        c = false;
    }
}
