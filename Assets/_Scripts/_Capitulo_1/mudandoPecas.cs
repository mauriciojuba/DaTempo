using UnityEngine;

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
    public GameObject vida1,vida2,vida3;
    public int lifecount;
    bool pecaAtivada;
    public GameObject highlighted;

    public AudioManager Effect;

    public TutorialFase1 tutorial_1;
    public TutorialFase1_2 tutorial_2;

    private bool tuto = true;
    private bool tuto2 = true;
    private bool tuto3 = true;


    void Start()
    {
        tutorial_1.AtivaFalaA(0);

        highlighted.SetActive(false);
        generatePuzzle(Random.Range(0, 11));
        rolagemSprites(0);
        PainelAviso.SetActive(false);
        PainelFimDeJogo.SetActive(false);
        vida1.SetActive(true);
        vida2.SetActive(true);
        vida3.SetActive(true);
        lifecount = 3;


    }

	public void click(string name)
    {
        switch (name)
        {
            case "11":
                //if(pecaselecionada)posiciona a peça
                selectSpace(11);
                break;
            case "12":
                //if(pecaselecionada)posiciona a peça
                selectSpace(12);
                break;
            case "21":
                //if(pecaselecionada)posiciona a peça
                selectSpace(21);
                break;
            case "22":
                //if(pecaselecionada)posiciona a peça
                selectSpace(22);
                break;
            case "ProximaPeca":
                //limpa ativação da peça e rola as peças da mão
                desativaSelecaoPeca();
                rolagemSprites(1);
                break;
            case "AnteriorPeca":
                //limpa ativação da peça e rola as peças da mão
                desativaSelecaoPeca();
                rolagemSprites(-1);
                break;
            case "PecaDaVez":
                //peça ativada escolha a posição
                ativaSelecaoPeca();
                break;
            case "Limpar":
                //limpa ativação da peça e resseta todas posicionadas
                Limpar();
                break;
        }
    }
    void ativaSelecaoPeca()
    {
        Effect.playSound("EspacoPlaca");
        pecaAtivada = true;
        highlighted.SetActive(true);
    }
    void desativaSelecaoPeca()
    {
        pecaAtivada = false;
        highlighted.SetActive(false);
    }
    void selectSpace (int space)
    {
        if (pecaAtivada)
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
            posicionarPeca();
            desativaSelecaoPeca();
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
        Effect.playSound("BotaoMenu");
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
        Effect.playSound("PedraPlaca");
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

        if (tuto)
        {
        //    tutorial_1.AtivaFalaA(1);
            tuto = false;
        }
        else if(tuto == false && tuto2)
        {
            tutorial_1.AtivaFalaA(2);
            tuto2 = false;
        }
        else if(tuto == false && tuto2 == false && tuto3)
        {
            tutorial_1.AtivaFalaA(3);
            tuto3 = false;
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
    public void diminuiVida()
    {
        lifecount--;
        if (lifecount == 2) vida3.SetActive(false);
        if (lifecount == 1) vida2.SetActive(false);
        if (lifecount == 0) vida1.SetActive(false);
        if (lifecount == -1) lifecount = 3;
    }
    public void checkCombination()
    {
        if(my_combination == combination || my_combination == ot_combination)
        {
            Effect.playSound("PainelAcerto");
            tutorial_2.AtivaFalaA(0);
            _netCom.StartPuzzle2();
        }
        else
        {
            desativaSelecaoPeca();
            diminuiVida();
            _netCom.vapor();
            Limpar();
            //RETIRA UMA DAS 3 CHANCES.
        }
    }
    public void LevelSelect()
    {
        _netCom.levelStage();
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

        Effect.playSound("TiraPlaca");
        desativaSelecaoPeca();
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
