using UnityEngine;
using System.Collections;

public class energyCollect : MonoBehaviour {

    public GameObject mockUp, energy, font, bigfont;
    public InteractionPuzzleA _unet;

    public AudioManager Effect;

    void OnEnable()
    {
        Effect.playSound("PedraArrastando");
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
                Effect.playSound("PedraPlaca");
                energy.SetActive(false);
                font.SetActive(false);
                Invoke("BigFont", 0.5f);
                break;
            case "FimFase1":
                Effect.playSound("PainelAcerto");
                Invoke("Next", 1f);
                break;
        }
    }

    void Next()
    {
        _unet.nextStage();
    }

    void BigFont()
    {
        bigfont.SetActive(true);
    }
}
