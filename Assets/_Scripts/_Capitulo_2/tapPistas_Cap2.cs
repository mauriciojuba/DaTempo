using UnityEngine;
using System.Collections;
using TouchScript;

public class tapPistas_Cap2 : MonoBehaviour {

    public Capitulo2 capitulo2;

    private void OnEnable()
    {
        if (TouchManager.Instance != null)
        {
            TouchManager.Instance.TouchesBegan += touchesBeganHandler;
            TouchManager.Instance.TouchesMoved += touchesMoveHandler;
            TouchManager.Instance.TouchesEnded += touchesEndedHandler;
        }
    }

    private void OnDisable()
    {
        if (TouchManager.Instance != null)
        {
            TouchManager.Instance.TouchesBegan -= touchesBeganHandler;
            TouchManager.Instance.TouchesMoved -= touchesMoveHandler;
            TouchManager.Instance.TouchesEnded -= touchesEndedHandler;
        }
    }

    private void spawnPrefabAt(string nameObject)
    {
        Debug.Log(nameObject);
        capitulo2.click(nameObject);
    }
    private void spawn(string nameObject)
    {
        if (nameObject != "LimpaSujeira")
        {
            capitulo2.click(nameObject);
        }
    }

    private void touchesMoveHandler(object sender, TouchEventArgs e)
    {
        foreach (var point in e.Touches)
        {
            spawnPrefabAt(point.Hit.RaycastHit2D.collider.gameObject.name);
        }
    }
    private void touchesEndedHandler(object sender, TouchEventArgs e)
    {
        foreach (var point in e.Touches)
        {
            capitulo2.soltou();
            Debug.Log("soltou");
        }
    }
    private void touchesBeganHandler(object sender, TouchEventArgs e)
    {
        foreach (var point in e.Touches)
        {
            spawn(point.Hit.RaycastHit2D.collider.gameObject.name);
        }
    }

}
