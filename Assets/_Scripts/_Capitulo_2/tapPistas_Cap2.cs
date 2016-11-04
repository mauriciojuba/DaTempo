using UnityEngine;
using System.Collections;
using TouchScript;

public class tapPistas_Cap2 : MonoBehaviour {

    public Capitulo2 capitulo2;

    private void OnEnable()
    {
        if (TouchManager.Instance != null)
        {
            TouchManager.Instance.TouchesMoved += touchesBeganHandler;
        }
    }

    private void OnDisable()
    {
        if (TouchManager.Instance != null)
        {
            TouchManager.Instance.TouchesMoved -= touchesBeganHandler;
        }
    }

    private void spawnPrefabAt(string nameObject)
    {
        Debug.Log(nameObject);
        capitulo2.click(nameObject);
    }

    private void touchesBeganHandler(object sender, TouchEventArgs e)
    {
        foreach (var point in e.Touches)
        {
            spawnPrefabAt(point.Hit.RaycastHit2D.collider.gameObject.name);
        }
    }
}
