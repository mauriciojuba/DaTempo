using UnityEngine;
using System.Collections;
using TouchScript;

public class tapTabuleiro : MonoBehaviour
{
    public mudandoPecas controladorPecas;
    public mudandoGemas controladorGemas;
    public energyCollect energycollect;
    public canoVapor pipe;
    public static int puzzleAtivo;
    void Start()
    {
        //lembrar de voltar para 0 antes da build
        puzzleAtivo = 0;
    }

    private void OnEnable()
    {
        if (TouchManager.Instance != null)
        {
            TouchManager.Instance.TouchesBegan += touchesBeganHandler;
        }
    }

    private void OnDisable()
    {
        if (TouchManager.Instance != null)
        {
            TouchManager.Instance.TouchesBegan -= touchesBeganHandler;
        }
    }

    private void spawnPrefabAt(string nameObject)
    {
        if(nameObject == "ConsertaPipe")
        {
            pipe.click(nameObject);
        }
        //nome do script que controlara o touch
        if (puzzleAtivo == 0)
        {
            controladorPecas.click(nameObject);
        }
        if(puzzleAtivo == 1)
        {
            controladorGemas.click(nameObject);
        }
        if (puzzleAtivo == 2)
        {
            energycollect.click(nameObject);
        }
    }

    private void touchesBeganHandler(object sender, TouchEventArgs e)
    {
        foreach (var point in e.Touches)
        {
            spawnPrefabAt(point.Hit.RaycastHit2D.collider.gameObject.name);
        }
    }
}