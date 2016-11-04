using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Pistas : MonoBehaviour {

    public SpriteRenderer Pista;
    public Sprite[] pistas;
    public SpriteRenderer Vapor;

    int pistaNum;
    float vaporLevel,countVapor;
    bool vaporOn, consertando;


    public int chanceDoVapor;



    void Start()
    {
        pistaNum = 0;
        vaporLevel = 0;
        Pista.sprite = pistas[pistaNum];
        Vapor.color = new Color(1,1,1,0);
    }

    void Update()
    {
        controlaVapor();
    }
    

    public void click(string name)
    {
        switch (name)
        {
            case "VoltarMainMenu":
                voltarMainMenu();
                break;
            case "Proximo":
                proximaPista();
                break;
            case "Anterior":
                anteriorPista();
                break;
            case "ConsertaPipe":
                consertaPipe();
                break;
        }
    }
    
    void proximaPista()
    {
        if (Random.Range(0, 10) > chanceDoVapor)
        {
            soltaVapor();
        }
        if (pistaNum < pistas.Length -1)
        {
            pistaNum += 1;
        }
        else
        {
            pistaNum = 0;
        }
        Pista.sprite = pistas[pistaNum];
    }
    void anteriorPista()
    {
        if (Random.Range(0, 10) > chanceDoVapor)
        {
            soltaVapor();
        }
        if (pistaNum > 0)
        {
            pistaNum -= 1;
        }
        else
        {
            pistaNum = pistas.Length -1;
        }
        Pista.sprite = pistas[pistaNum];

    }
    void consertaPipe()
    {
        consertando = true;
    }

    void controlaVapor()
    {
        if (consertando)
        {
            if (countVapor >= 2)
            {
                consertando = false;
                countVapor = 0;
            }
            else
            {
                vaporLevel -= Time.deltaTime / 6;
                if (vaporLevel <= 0)
                {
                    vaporOn = false;
                    consertando = false;
                    countVapor = 0;
                }
                countVapor += Time.deltaTime;
            }
            Vapor.color = new Color(1, 1, 1, vaporLevel);

        }
        else if (vaporOn && vaporLevel<=1)
        {
            vaporLevel += Time.deltaTime / 8;
            Vapor.color = new Color(1, 1, 1, vaporLevel);
        }
    }
    void soltaVapor()
    {
        vaporOn = true;
    }
    void voltarMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
