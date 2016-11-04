using UnityEngine;
using System.Collections;

public class Capitulo2 : MonoBehaviour {

    public SpriteRenderer sujeiraSprite;


    float levelSujeira, countSujeira;
    bool limpando, onSujeira;

    public bool testeSujeira;

	void Start () {
        levelSujeira = 0;
        sujeiraSprite.color = new Color(1, 1, 1, 0);

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
        }
    }
    // Update is called once per frame
    void limpaSujeira () {
        limpando = true;
	}
    void sujarTela()
    {
        onSujeira = true;
        levelSujeira = 1;
    }
    void controlaSujeira()
    {
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
