using UnityEngine;
using System.Collections;
using TouchScript;

public class tapTutorial : MonoBehaviour {

    public TutorialFase1 Fase1;

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
        Debug.Log(nameObject);
        if (nameObject == "ApagaA")
            Fase1.DesativaFalaA();
        if (nameObject == "ApagaB")
            Fase1.DesativaFalaB();

        if (nameObject == "TesteTutorial1")
            Fase1.AtivaFalaA(0);
        if (nameObject == "TesteTutorial2")
            Fase1.AtivaFalaA(1);
        if (nameObject == "TesteTutorial3")
            Fase1.AtivaFalaA(2);
        if (nameObject == "TesteTutorial4")
            Fase1.AtivaFalaA(3);
    }

    private void touchesBeganHandler(object sender, TouchEventArgs e)
    {
        foreach (var point in e.Touches)
        {
            spawnPrefabAt(point.Hit.RaycastHit2D.collider.gameObject.name);
        }
    }
}
