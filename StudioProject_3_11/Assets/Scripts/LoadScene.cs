using UnityEngine;
using System.Collections;

public class LoadScene : MonoBehaviour {
    GameObject eventSystem;
    bool eventSystemActivate = true;
    UICreator ui;
    void Start()
    {
        eventSystem = GameObject.Find("EventSystem");
        ui = new UICreator(5);
    }
    public void enterStartScene()
    {
        Application.LoadLevel(0);
    }
    public void enterMainScene() {
        Application.LoadLevel(1);
    }
    public void enterOnlineBattleScene()
    {
        Application.LoadLevel(2);
    }
    public void enterEditDeckScene()
    {
        Application.LoadLevel(3);
    }
    public void enterBagScene()
    {
        Application.LoadLevel(4);
    }
    public void enterTextField()
    {
        Application.LoadLevel(5);
    }

    public void changeEventSystemStatus()
    {
        if (eventSystemActivate)
        {
            eventSystem.SetActive(false);
            eventSystemActivate = false;
        }
        else
        {
            eventSystem.SetActive(true);
            eventSystemActivate = true;
        }
    }
}
