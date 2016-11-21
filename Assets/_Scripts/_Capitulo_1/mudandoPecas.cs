using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mudandoPecas : MonoBehaviour {

    public SpriteRenderer oneOne, oneTwo, twoOne, twoTwo;
    public Color ok, red, green, blank;
    public Sprite emBranco;
    public Sprite[] pecas;
    public SpriteRenderer pecaEsquerda, pecaSelecionada, pecaDireita;
    public GameObject PainelAviso, PainelFimDeJogo;
    public Sprite[] pistas;
    public SpriteRenderer Pista;
    int a, b, c, d;
    bool _a, _b, _c, _d;
    int spaceSelected = 0, indiceSprite;
    int combinationNum;
    string combination, my_combination, ot_combination;
    public InteractionPuzzleA _netCom;

    void Start()
    {
        generatePuzzle(Random.Range(0, 11));
        rolagemSprites(0);
        PainelAviso.SetActive(false);
        PainelFimDeJogo.SetActive(false);
        
    }

	public void click(string name)
    {
        switch (name)
        {
            case "11":
                selectSpace(11);
                break;
            case "12":
                selectSpace(12);
                break;
            case "21":
                selectSpace(21);
                break;
            case "22":
                selectSpace(22);
                break;
            case "ProximaPeca":
                rolagemSprites(1);
                break;
            case "AnteriorPeca":
                rolagemSprites(-1);
                break;
            case "PecaDaVez":
                posicionarPeca();
                break;
            case "Limpar":
                Limpar();
                break;
        }
    }
    void selectSpace (int space)
    {
        spaceSelected = space;
        switch (spaceSelected)
        {
            case 11:
                clearSelection();
                oneOne.color = green;
                break;
            case 12:
                clearSelection();
                oneTwo.color = green;
                break;
            case 21:
                clearSelection();
                twoOne.color = green;
                break;
            case 22:
                clearSelection();
                twoTwo.color = green;
                break;
        }
    }

    void clearSelection()
    {
        PainelAviso.SetActive(false);
        if (!_a) oneOne.color = red;
        else oneOne.color = ok;
        if (!_b) oneTwo.color = red;
        else oneTwo.color = ok;
        if (!_c) twoOne.color = red;
        else twoOne.color = ok;
        if (!_d) twoTwo.color = red;
        else twoTwo.color = ok;
    }

    void rolagemSprites(int valor)
    {
        indiceSprite += valor;

        if (indiceSprite == 0)
        {
            pecaEsquerda.sprite = pecas[16];
            pecaSelecionada.sprite = pecas[0];
            pecaDireita.sprite = pecas[1];
        }
        else if(indiceSprite == -1)
        {
            pecaEsquerda.sprite = pecas[15];
            pecaSelecionada.sprite = pecas[16];
            pecaDireita.sprite = pecas[0];
        }
        else if(indiceSprite == -2)
        {
            pecaSelecionada.sprite = pecas[15];
            pecaEsquerda.sprite = pecas[14];
            pecaDireita.sprite = pecas[16];
            indiceSprite = 15;
        }
        else if(indiceSprite == 16)
        {
            pecaEsquerda.sprite = pecas[15];
            pecaSelecionada.sprite = pecas[16];
            pecaDireita.sprite = pecas[0];
        }
        else if (indiceSprite == 17)
        {
            pecaEsquerda.sprite = pecas[16];
            pecaSelecionada.sprite = pecas[0];
            pecaDireita.sprite = pecas[1];
        }
        else if (indiceSprite == 18)
        {
            pecaEsquerda.sprite = pecas[0];
            pecaSelecionada.sprite = pecas[1];
            pecaDireita.sprite = pecas[2];
            indiceSprite = 1;
        }

        else
        {
            pecaEsquerda.sprite = pecas[indiceSprite -1];
            pecaSelecionada.sprite = pecas[indiceSprite];
            pecaDireita.sprite = pecas[indiceSprite +1];
        }


    }

    void posicionarPeca()
    {
        switch (spaceSelected)
        {
            case 11:
                clearSelection();
                oneOne.sprite = pecaSelecionada.sprite;
                oneOne.color = ok;
                _a = true;
                a = indiceSprite;
                spaceSelected = 0;
                checkCompleted();
                break;
            case 12:
                clearSelection();
                oneTwo.sprite = pecaSelecionada.sprite;
                oneTwo.color = ok;
                _b = true;
                b = indiceSprite;
                spaceSelected = 0;
                checkCompleted();
                break;
            case 21:
                clearSelection();
                twoOne.sprite = pecaSelecionada.sprite;
                twoOne.color = ok;
                _c = true;
                c = indiceSprite;
                spaceSelected = 0;
                checkCompleted();
                break;
            case 22:
                clearSelection();
                twoTwo.sprite = pecaSelecionada.sprite;
                twoTwo.color = ok;
                _d = true;
                d = indiceSprite;
                spaceSelected = 0;
                checkCompleted();
                break;
            case 0:
                PainelAviso.SetActive(true);
                break;
        }
    }
    void checkCompleted()
    {
        if (_a && _b && _c && _d)
        {
            my_combination = "" + a + b + c + d;
            checkCombination();
            
        }
    }
    public void checkCombination()
    {
        if(my_combination == combination || my_combination == ot_combination)
        {
            _netCom.StartPuzzle2();
        }
        else
        {
            _netCom.vapor();
            Limpar();
            //RETIRA UMA DAS 3 CHANCES.
        }
    }
    public void Test()
    {
        _netCom.StartPuzzle2();
    }
    void generatePuzzle(int numPuzzle)
    {
        
        Pista.sprite = pistas[numPuzzle];
        switch (numPuzzle)
        {
            case 0:
                combination = "1572";
                ot_combination = "nao";
                break;
            case 1:
                combination = "2801";
                ot_combination = "nao";
                break;
            case 2:
                combination = "3145";
                ot_combination = "nao";
                break;
            case 3:
                combination = "4375";
                ot_combination = "nao";
                break;
            case 4:
                combination = "4627";
                ot_combination = "nao";
                break;
            case 5:
                combination = "7234";
                ot_combination = "nao";
                break;
            case 6:
                combination = "1514-113";
                ot_combination = "15141613";
                break;
            case 7:
                combination = "11910-1";
                ot_combination = "1191016";
                break;
            case 8:
                combination = "131445";
                ot_combination = "nao";
                break;
            case 9:
                combination = "9101112";
                ot_combination = "nao";
                break;
            case 10:
                combination = "13101214";
                ot_combination = "nao";
                break;
            case 11:
                combination = "15161112";
                ot_combination = "15-11112";
                break;
        }
    }
    public void Limpar()
    {
        oneOne.sprite = emBranco;
        oneTwo.sprite = emBranco;
        twoOne.sprite = emBranco;
        twoTwo.sprite = emBranco;
        oneOne.color = blank;
        oneTwo.color = blank;
        twoOne.color = blank;
        twoTwo.color = blank;
        _a = false;
        _b = false;
        _c = false;
        _d = false;
    }
    public void restartPuzzle()
    {
        
    }
    public void quitPuzzle()
    {
        
        
    }
}
