using UnityEngine;
using System.Collections;
using TouchScript;

public class TutorialFase1 : MonoBehaviour {

    public GameObject TutorialA , TutorialB;

    public GameObject[] FalasJogadorA;
    public GameObject[] FalasJogadorB;

    public GameObject BloqueiaA , BloqueiaB;

    public GameObject MaozinhaA , MaozinhaB;

    private Animator Mao_A, Mao_B;

    // Use this for initialization
    void Start()
    {
        Mao_A = MaozinhaA.GetComponent<Animator>();
        Mao_B = MaozinhaB.GetComponent<Animator>();

        TutorialA.SetActive(false);
        
        for (int i = 0; i < FalasJogadorB.Length; i++)
            FalasJogadorB[i].SetActive(false);

        for (int i = 0; i < FalasJogadorA.Length; i++)
            FalasJogadorA[i].SetActive(false);
    }


    //------------- Falas Jogador A -------------

    public void AtivaFalaA(int fala)
    {

        BloqueiaA.SetActive(true);

        TutorialA.SetActive(true);
        FalasJogadorA[fala].SetActive(true);

        if (fala == 0) { 
        MaozinhaA.SetActive(false);
    }

        if (fala == 1)
        {
            MaozinhaA.SetActive(true);
            MaoA("Peca");
        }

        if (fala == 2)
        {
            MaozinhaA.SetActive(true);
            MaoA("Limpar");
        }

        if (fala == 3)
        {
            MaozinhaA.SetActive(true);
            MaoA("Xtela");
        }

    }

    public void DesativaFalaA(){

        BloqueiaA.SetActive(false);

        MaozinhaA.SetActive(false);

        for(int i = 0; i <FalasJogadorA.Length; i++){
            FalasJogadorA[i].SetActive(false);
        }
    }

    public void MaoA(string Animacao)
    {
        Mao_A.SetTrigger(Animacao);
    }

    //------------- Falas Jogador B -------------

    public void AtivaFalaB(int fala){
        TutorialB.SetActive(true);
        FalasJogadorB[fala].SetActive(true);
    }

    public void DesativaFalaB(){
        for (int i = 0; i < FalasJogadorB.Length; i++){
            FalasJogadorB[i].SetActive(false);
        }
    }

	// Update is called once per frame
	void Update () {
	
	}
}
