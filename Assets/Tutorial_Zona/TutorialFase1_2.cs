﻿using UnityEngine;
using System.Collections;
using TouchScript;

public class TutorialFase1_2 : MonoBehaviour {

    public GameObject[] FalasJogadorA;
    public GameObject[] FalasJogadorB;

    public GameObject BloqueiaB;


    // Use this for initialization
    void Start()
    {


    }


    //------------- Falas Jogador A -------------

    public void AtivaFalaA(int fala)
    {



        FalasJogadorA[fala].SetActive(true);

    }

    public void DesativaFalaA(){



        for(int i = 0; i <FalasJogadorA.Length; i++){
            FalasJogadorA[i].SetActive(false);
        }
    }

    //------------- Falas Jogador B -------------

    public void AtivaFalaB(int fala){

        BloqueiaB.SetActive(true);


        FalasJogadorB[fala].SetActive(true);


    }

    public void DesativaFalaB(){

        BloqueiaB.SetActive(false);

        for (int i = 0; i < FalasJogadorB.Length; i++){
            FalasJogadorB[i].SetActive(false);
        }
    }
}
