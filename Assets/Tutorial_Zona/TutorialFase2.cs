using UnityEngine;
using System.Collections;
using TouchScript;

public class TutorialFase2: MonoBehaviour {

    public GameObject[] FalasJogadorA;
    public GameObject[] FalasJogadorB;

    public GameObject MaozinhaA, MaozinhaB;

    public GameObject BloqueiaA, BloqueiaB;

    private Animator MaoA, MaoB;


    // Use this for initialization
    void Start()
    {
        MaoA = MaozinhaA.GetComponent<Animator>();
        MaoB = MaozinhaB.GetComponent<Animator>();

    }


    //------------- Falas Jogador A -------------

    public void AtivaFalaA(int fala)
    {
        if (fala == 2)
        {
            MaozinhaA.SetActive(true);

            MaoA.SetTrigger("Fusivel");
        }
        BloqueiaA.SetActive(true);
        FalasJogadorA[fala].SetActive(true);
    }

    public void DesativaFalaA(){

        MaozinhaA.SetActive(false);

        BloqueiaA.SetActive(false);

        for (int i = 0; i <FalasJogadorA.Length; i++){
            FalasJogadorA[i].SetActive(false);
        }
    }

    //------------- Falas Jogador B -------------

    public void AtivaFalaB(int fala){

        if(fala == 0)
        {
            MaozinhaB.SetActive(true);
            MaoB.SetTrigger("Botao");
        }

        if (fala == 1)
        {
            MaozinhaB.SetActive(true);
            MaoB.SetTrigger("Graxa");
        }

        if (fala == 3)
        {
            MaozinhaB.SetActive(true);
            MaoB.SetTrigger("Chave");
        }

        BloqueiaB.SetActive(true);
        FalasJogadorB[fala].SetActive(true);


    }

    public void DesativaFalaB(){

        MaozinhaB.SetActive(false);

        BloqueiaB.SetActive(false);

        for (int i = 0; i < FalasJogadorB.Length; i++){
            FalasJogadorB[i].SetActive(false);
        }
    }
}
