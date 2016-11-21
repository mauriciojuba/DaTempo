using UnityEngine;
using System.Collections;

public class energyCollect : MonoBehaviour {

    public GameObject mockUp, energy, font, bigfont;
    public InteractionPuzzleA _unet;
    void OnEnable()
    {
        bigfont.SetActive(false);
        font.SetActive(true);
        energy.SetActive(true);
        mockUp.SetActive(true);
    }
    public void click(string obj)
    {
        switch (obj)
        {
            case "Fonte":
                energy.SetActive(false);
                font.SetActive(false);
                Invoke("BigFont", 0.5f);
                break;
            case "FimFase1":
                _unet.nextStage();
                break;
        }
    }
    void BigFont()
    {
        bigfont.SetActive(true);
    }
}
