using UnityEngine;
using System.Collections;

public class LoadScene : MonoBehaviour {
    GameObject eventSystem;
    bool eventSystemActivate = true;
    void Awake()
    {
        eventSystem = GameObject.Find("EventSystem");
    }
    public void enterStartScene()
    {
        Application.LoadLevel(0);
    }
    public void enterOnlineBattleScene()
    {
        Application.LoadLevel(1);
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
