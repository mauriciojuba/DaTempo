using UnityEngine;
using UnityEngine.UI;

public class canoVapor : MonoBehaviour {

    public SpriteRenderer Vapor, pipe;
    public Sprite arrumado, quebrado;
    float vaporLevel,countVapor;
    bool vaporOn, consertando;
    public GameObject vida1, vida2, vida3;
    public int lifecount;
    public AudioManager Effect;
    

    public void diminuiVida()
    {
        lifecount--;
        if(lifecount == 2) vida3.SetActive(false);
        if(lifecount == 1) vida2.SetActive(false);
        if(lifecount == 0) vida1.SetActive(false);
        if (lifecount == -1) lifecount = 3;
    }

    void Start()
    {
        pipe.sprite = arrumado;
        vaporLevel = 0;
        Vapor.color = new Color(1,1,1,0);
        lifecount = 3;
        vida1.SetActive(true);
        vida2.SetActive(true);
        vida3.SetActive(true);
    }

    void Update()
    {
        controlaVapor();
    }
    

    public void click(string name)
    {
        switch (name)
        {
            case "ConsertaPipe":
                consertaPipe();
                break;
        }
    }
    
    
    void consertaPipe()
    {
        Effect.playSound("ConsertaCano");
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
                vaporLevel -= Time.deltaTime/4;
                if (vaporLevel <= 0)
                {
                    vaporOn = false;
                    consertando = false;
                    countVapor = 0;
                    pipe.sprite = arrumado;
                    Destroy(GameObject.Find("VaporSaindo"));

                }
                countVapor += Time.deltaTime;
            }
            Vapor.color = new Color(1, 1, 1, vaporLevel);

        }
        else if (vaporOn && vaporLevel<=1)
        {
            vaporLevel += Time.deltaTime / 2;
            Vapor.color = new Color(1, 1, 1, vaporLevel);
        }
    }
    public void soltaVapor()
    {
        Effect.playSound("QuebraCano");
        Effect.playSound("VaporSaindo");
        vaporOn = true;
        pipe.sprite = quebrado;
        diminuiVida();
    }
}
