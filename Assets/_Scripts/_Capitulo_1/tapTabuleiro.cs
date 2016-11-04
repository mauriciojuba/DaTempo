using UnityEngine;
using System.Collections;
using TouchScript;

public class tapTabuleiro : MonoBehaviour
{
    public mudandoPecas controladorPecas;

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
        controladorPecas.click(nameObject);
    }

    private void touchesBeganHandler(object sender, TouchEventArgs e)
    {
        foreach (var point in e.Touches)
        {
            spawnPrefabAt(point.Hit.RaycastHit2D.collider.gameObject.name);
        }
    }
}