﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Capitulo2 : MonoBehaviour {
    public InteractionPuzzleB _unet;
    public SpriteRenderer _luz;
    public Sprite luzAcesa, luzApagada;
    public SpriteRenderer _btn;
    public Sprite btnInativo, btnAtivo;
    bool _next;

    GameObject _sujeiraSprite;
    public SpriteRenderer sujeiraSprite;
    

    float levelSujeira, countSujeira;
    bool limpando, onSujeira;

    public bool testeSujeira;
    public bool abrindo;

    public TutorialFase2 tutorial2;


    void Start () {
        levelSujeira = 0;
        sujeiraSprite.color = new Color(1, 1, 1, 0);
        _sujeiraSprite = sujeiraSprite.gameObject;
        _sujeiraSprite.SetActive(false);
        _luz.sprite = luzApagada;
        _btn.sprite = btnInativo;

    }
    void Update()
    {
        controlaSujeira();   
    }

    public void click(string name)
    {
        switch (name)
        {
            case "LimpaSujeira":
                limpaSujeira();
                break;
            case "Sujeira":
                if(testeSujeira) sujarTela();
                break;
            case "AbrePorta":
                if (!_next)
                {
                    abrindo = true;
                    DoorHandler();
                }

                break;
            case "NextStage":
                if(_next) proxFase();
                break;
        }
    }
    void nextLevel()
    {
        
        _unet.nextLevel();
    }
    void proxFase()
    {
        _btn.sprite = btnAtivo;
        Invoke("nextLevel", 0.5f);
    }
    public void LightsON()
    {
        tutorial2.AtivaFalaB(2);
        _luz.sprite = luzAcesa;
        _next = true;
    }
    public void DoorHandler()
    {
        if (abrindo){
            _unet.openDoor();
        }
        else
        {
            _unet.closeDoor();
        }
    }
    public void soltou()
    {
        abrindo = false;
        DoorHandler();
    }
    // Update is called once per frame
    void limpaSujeira () {
        limpando = true;
	}
    void sujarTela()
    {
        tutorial2.AtivaFalaB(1);
        onSujeira = true;
        levelSujeira = 1;
    }
    void controlaSujeira()
    {
        if (onSujeira)
        {
            _sujeiraSprite.SetActive(true);
        }
        else
        {
            _sujeiraSprite.SetActive(false);
        }
        if (limpando)
        {
            if (countSujeira >= 2)
            {
                limpando = false;
                countSujeira = 0;
            }
            else
            {
                levelSujeira -= Time.deltaTime / 6;
                if (levelSujeira <= 0)
                {
                    onSujeira = false;
                    limpando = false;
                    countSujeira = 0;
                }
                countSujeira += Time.deltaTime;
            }
            sujeiraSprite.color = new Color(1, 1, 1, levelSujeira);

        }
        else if (onSujeira && levelSujeira <= 1)
        {
            levelSujeira += Time.deltaTime / 8;
            sujeiraSprite.color = new Color(1, 1, 1, levelSujeira);
        }
    }
}
