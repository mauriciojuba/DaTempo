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

    public GameObject[] Particula;
    private Vector3 GemasOfset;


    private bool tuto = true;

    public TutorialFase1_2 tutorial2;

    void Start () {
        LimpaGemas();
        LimpaSelecao();
        randomizaEmblema();
        desativaGema();
    }
    void OnEnable() {

        lifeCount = puzzle1.lifecount;
        tutorial2.AtivaFalaA(0);
        
    }
    void OnDisable() {
        tutorial2.DesativaFalaA();
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
                GemasOfset = new Vector3(oneOne.gameObject.transform.position.x + 0.6f * oneOne.gameObject.transform.localScale.x, oneOne.gameObject.transform.position.y + 0.6f * oneOne.gameObject.transform.localScale.y, oneOne.gameObject.transform.position.z +10);
                LimpaSelecao();
                selecionaEspaco(oneOne,11);
                moveGema();
                break;
            case "12":
                GemasOfset = new Vector3(oneTwo.gameObject.transform.position.x + 0.6f * oneTwo.gameObject.transform.localScale.x, oneTwo.gameObject.transform.position.y + 0.6f * oneTwo.gameObject.transform.localScale.y, oneTwo.gameObject.transform.position.z+10);
                LimpaSelecao();
                selecionaEspaco(oneTwo,12);
                moveGema();
                break;
            case "21":
                GemasOfset = new Vector3(twoOne.gameObject.transform.position.x + 0.6f * twoOne.gameObject.transform.localScale.x, twoOne.gameObject.transform.position.y + 0.6f * twoOne.gameObject.transform.localScale.y, twoOne.gameObject.transform.position.z+10);
                LimpaSelecao();
                selecionaEspaco(twoOne,21);
                moveGema();
                break;
            case "22":
                GemasOfset = new Vector3(twoTwo.gameObject.transform.position.x + 0.6f * twoTwo.gameObject.transform.localScale.x, twoTwo.gameObject.transform.position.y + 0.6f * twoTwo.gameObject.transform.localScale.y, twoTwo.gameObject.transform.position.z+10);
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
                GemasOfset = new Vector3(hR.transform.position.x + 0.6f * hR.transform.localScale.x, hR.transform.position.y + 0.6f * hR.transform.localScale.y, hR.transform.position.z);
                desativaGema();
                ativaGema(hR,R);
                Instantiate(Particula[2], GemasOfset, hR.transform.rotation);
                break;
            case "G":
                GemasOfset = new Vector3(hG.transform.position.x + 0.6f * hG.transform.localScale.x, hG.transform.position.y + 0.6f * hG.transform.localScale.y, hG.transform.position.z);
                desativaGema();
                ativaGema(hG, G);
                Instantiate(Particula[1], GemasOfset, hG.transform.rotation);
                break;
            case "B":
                GemasOfset = new Vector3(hB.transform.position.x + 0.6f * hB.transform.localScale.x, hB.transform.position.y + 0.6f * hB.transform.localScale.y, hB.transform.position.z);
                desativaGema();
                ativaGema(hB, B);
                Instantiate(Particula[3], GemasOfset, hB.transform.rotation);
                break;
            case "P":
                GemasOfset = new Vector3(hP.transform.position.x + 0.6f * hP.transform.localScale.x, hP.transform.position.y + 0.6f * hP.transform.localScale.y, hP.transform.position.z);
                desativaGema();
                ativaGema(hP, P);
                Instantiate(Particula[0],GemasOfset,hP.transform.rotation);
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
                    if(_A == P.name) Instantiate(Particula[0], GemasOfset, hP.transform.rotation);
                    else if (_A == G.name) Instantiate(Particula[1], GemasOfset, hG.transform.rotation);
                    else if(_A == R.name) Instantiate(Particula[2], GemasOfset, hR.transform.rotation);
                    else if (_A == B.name) Instantiate(Particula[3], GemasOfset, hG.transform.rotation);
                    LimpaSelecao();
                    break;
                case 12:
                    oneTwo.sprite = selectedGem;
                    _B = selectedGem.name;
                    _b = true;
                    if (_B == P.name) Instantiate(Particula[0], GemasOfset, hP.transform.rotation);
                    else if (_B == G.name) Instantiate(Particula[1], GemasOfset, hG.transform.rotation);
                    else if (_B == R.name) Instantiate(Particula[2], GemasOfset, hR.transform.rotation);
                    else if (_B == B.name) Instantiate(Particula[3], GemasOfset, hG.transform.rotation);
                    LimpaSelecao();
                    break;
                case 21:
                    twoOne.sprite = selectedGem;
                    _C = selectedGem.name;
                    _c = true;
                    LimpaSelecao();
                    if (_C == P.name) Instantiate(Particula[0], GemasOfset, hP.transform.rotation);
                    else if (_C == G.name) Instantiate(Particula[1], GemasOfset, hG.transform.rotation);
                    else if (_C == R.name) Instantiate(Particula[2], GemasOfset, hR.transform.rotation);
                    else if (_C == B.name) Instantiate(Particula[3], GemasOfset, hG.transform.rotation);
                    break;
                case 22:
                    twoTwo.sprite = selectedGem;
                    _D = selectedGem.name;
                    _d = true;
                    LimpaSelecao();
                    if (_D == P.name) Instantiate(Particula[0], GemasOfset, hP.transform.rotation);
                    else if (_D == G.name) Instantiate(Particula[1], GemasOfset, hG.transform.rotation);
                    else if (_D == R.name) Instantiate(Particula[2], GemasOfset, hR.transform.rotation);
                    else if (_D == B.name) Instantiate(Particula[3], GemasOfset, hG.transform.rotation);
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
