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
    public mudandoPecas puzzle1;
    public AudioManager Effect;
    public GameObject vida1, vida2, vida3;
    public GameObject hR, hG, hB, hP;
    int lifeCount;
    bool gemaAtivada;
    Sprite selectedGem;


    void Start () {
        LimpaGemas();
        LimpaSelecao();
        randomizaEmblema();
        desativaGema();
    }
    void OnEnable() {

        lifeCount = puzzle1.lifecount;
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
            combination = "BGRP";
        }
        else {
            emblem.sprite = estrela;
            combination = "RGPB";
        }
    }
    public void click(string obj)
    {
        switch (obj)
        {
            case "11":
                LimpaSelecao();
                selecionaEspaco(oneOne,11);
                moveGema();
                break;
            case "12":
                LimpaSelecao();
                selecionaEspaco(oneTwo,12);
                moveGema();
                break;
            case "21":
                LimpaSelecao();
                selecionaEspaco(twoOne,21);
                moveGema();
                break;
            case "22":
                LimpaSelecao();
                selecionaEspaco(twoTwo,22);
                moveGema();
                break;
            case "Limpar":
                desativaGema();
                LimpaGemas();
                LimpaSelecao();
                break;
            case "R":
                desativaGema();
                ativaGema(hR,R);
                break;
            case "G":
                desativaGema();
                ativaGema(hG, G);
                break;
            case "B":
                desativaGema();
                ativaGema(hB, B);
                break;
            case "P":
                desativaGema();
                ativaGema(hP, P);
                break;
        }
    }
    void ativaGema(GameObject highlight, Sprite gemaEscolhida)
    {
        gemaAtivada = true;
        highlight.SetActive(true);
        selectedGem = gemaEscolhida;
    }
    void desativaGema()
    {
        gemaAtivada = false;
        hR.SetActive(false);
        hB.SetActive(false);
        hG.SetActive(false);
        hP.SetActive(false);
        selectedGem = null;
    }

    void moveGema()
    {
        if (gemaAtivada)
        {
            Effect.playSound("PedraPlaca");

            switch (espacoSelected)
            {
                case 0:
                    PainelAviso.SetActive(true);
                    LimpaSelecao();
                    break;
                case 11:
                    oneOne.sprite = selectedGem;
                    _A = selectedGem.name;
                    _a = true;
                    LimpaSelecao();
                    break;
                case 12:
                    oneTwo.sprite = selectedGem;
                    _B = selectedGem.name;
                    _b = true;
                    LimpaSelecao();
                    break;
                case 21:
                    twoOne.sprite = selectedGem;
                    _C = selectedGem.name;
                    _c = true;
                    LimpaSelecao();
                    break;
                case 22:
                    twoTwo.sprite = selectedGem;
                    _D = selectedGem.name;
                    _d = true;
                    LimpaSelecao();
                    break;
            }
            desativaGema();
        }
        
    }
    void checkCompleted()
    {
        if (_a && _b && _c && _d)
        {
            
            my_combination = "" + _A + _B + _C + _D;
            if (my_combination == combination)
            {
                Effect.playSound("PainelAcerto");
                Invoke("Completed", 1f);
            }
            else
            {
                desativaGema();
                LimpaGemas();
                //som de erro
                _netCom.vapor();
                lifeCount--;
                switch (lifeCount)
                {
                    case -1:
                        Invoke("LevelSelect", 0.5f);
                        break;
                    case 0:
                        vida3.SetActive(false);
                        vida2.SetActive(false);
                        vida1.SetActive(false);
                        break;
                    case 1:
                        vida3.SetActive(false);
                        vida2.SetActive(false);
                        break;
                    case 2:
                        vida3.SetActive(false);
                        break;
                }
            }
        }
    }
    void LevelSelect()
    {
        _netCom.levelStage();
    }
    void Completed()
    {
        finalInteraction.SetActive(true);
        tapTabuleiro.puzzleAtivo = 2;
        this.gameObject.SetActive(false);
    }
    void LimpaGemas()
    {

        Effect.playSound("TiraPlaca");
        desativaGema();
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
        Effect.playSound("EspacoPlaca");

        _espaco.color = selected;
        espacoSelected = _pos;
    }
}
