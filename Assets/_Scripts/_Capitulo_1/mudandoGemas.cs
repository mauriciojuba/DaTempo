using UnityEngine;
using System.Collections;

public class mudandoGemas : MonoBehaviour {

    public SpriteRenderer emblem;
    public SpriteRenderer oneOne, oneTwo, twoOne, twoTwo;
    public Sprite R, G, B, P, blank;
    public Color standard, selected;
    public Sprite sol, estrela, lua;
    int espacoSelected;
    string my_combination, combination;
    public GameObject PainelAviso;
    string _A, _B, _C, _D;
    bool _a, _b, _c, _d;
    public InteractionPuzzleA _netCom;
    public GameObject finalInteraction;


    void Start () {
        LimpaGemas();
        LimpaSelecao();
        randomizaEmblema();
	}
    void randomizaEmblema()
    {
        float random = Random.Range(0, 3);
        if (random < 1)
        {
            emblem.sprite = sol;
            combination = "PBGR";
        }
        else if(random < 2) {
            emblem.sprite = lua;
            combination = "RGPB";
        }
        else {
            emblem.sprite = estrela;
            combination = "BGRP";
        }
    }
    public void click(string obj)
    {
        switch (obj)
        {
            case "11":
                LimpaSelecao();
                selecionaEspaco(oneOne,11);
                break;
            case "12":
                LimpaSelecao();
                selecionaEspaco(oneTwo,12);
                break;
            case "21":
                LimpaSelecao();
                selecionaEspaco(twoOne,21);
                break;
            case "22":
                LimpaSelecao();
                selecionaEspaco(twoTwo,22);
                break;
            case "Limpar":
                LimpaGemas();
                LimpaSelecao();
                break;
            case "R":
                moveGema(R);
                break;
            case "G":
                moveGema(G);
                break;
            case "B":
                moveGema(B);
                break;
            case "P":
                moveGema(P);
                break;
        }
    }
    void moveGema(Sprite _sprite)
    {
        switch (espacoSelected)
        {
            case 0:
                PainelAviso.SetActive(true);
                LimpaSelecao();
                break;
            case 11:
                oneOne.sprite = _sprite;
                _A = _sprite.name;
                _a = true;
                LimpaSelecao();
                break;
            case 12:
                oneTwo.sprite = _sprite;
                _B = _sprite.name;
                _b = true;
                LimpaSelecao();
                break;
            case 21:
                twoOne.sprite = _sprite;
                _C = _sprite.name;
                _c = true;
                LimpaSelecao();
                break;
            case 22:
                twoTwo.sprite = _sprite;
                _D = _sprite.name;
                _d = true;
                LimpaSelecao();
                break;
        }
        
    }
    void checkCompleted()
    {
        if (_a && _b && _c && _d)
        {
            
            my_combination = "" + _A + _B + _C + _D;
            if (my_combination == combination)
            {
                Completed();
            }
            else
            {
                LimpaGemas();
                //som de erro
                _netCom.vapor();
                //perde vida
            }
        }
    }
    void Completed()
    {
        finalInteraction.SetActive(true);
        tapTabuleiro.puzzleAtivo = 2;
        this.gameObject.SetActive(false);
    }
    void LimpaGemas()
    {
        oneOne.sprite = blank;
        oneTwo.sprite = blank;
        twoOne.sprite = blank;
        twoTwo.sprite = blank;
        _a = false;
        _b = false;
        _c = false;
        _d = false;
    }
    void LimpaSelecao()
    {
        oneOne.color = standard;
        oneTwo.color = standard;
        twoOne.color = standard;
        twoTwo.color = standard;
        PainelAviso.SetActive(false);
        espacoSelected = 0;
        checkCompleted();
    }
    void selecionaEspaco(SpriteRenderer _espaco, int _pos)
    {
        _espaco.color = selected;
        espacoSelected = _pos;
    }
}
