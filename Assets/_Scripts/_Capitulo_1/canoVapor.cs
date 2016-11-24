using UnityEngine;

public class canoVapor : MonoBehaviour {

    public SpriteRenderer Vapor, pipe;
    public Sprite arrumado, quebrado;
    float vaporLevel,countVapor;
    bool vaporOn, consertando;

    public AudioManager Effect;
    



    void Start()
    {
        pipe.sprite = arrumado;
        vaporLevel = 0;
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
    }
}
