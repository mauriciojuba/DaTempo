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

        AtivaFalaB(0);

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

        BloqueiaB.SetActive(true);

        TutorialB.SetActive(true);

        FalasJogadorB[fala].SetActive(true);

        if (fala == 0)
        {
            MaozinhaB.SetActive(true);
            MaoB("Livro");
        }

        if (fala == 1)
        {
            MaozinhaB.SetActive(false);
        }

        if (fala == 2)
        {
            MaozinhaB.SetActive(true);
            MaoB("Cano");
        }

        if (fala == 3)
        {
            MaozinhaB.SetActive(true);
            MaoB("Xtela");
        }

    }

    public void DesativaFalaB(){

        BloqueiaB.SetActive(false);

        MaozinhaB.SetActive(false);

        for (int i = 0; i < FalasJogadorB.Length; i++){
            FalasJogadorB[i].SetActive(false);
        }
    }

    public void MaoB(string Animacao)
    {
        Mao_B.SetTrigger(Animacao);
    }

    // Update is called once per frame
    void Update () {
	
	}
}
