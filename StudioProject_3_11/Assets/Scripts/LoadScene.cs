using UnityEngine;
using System.Collections;

public class LoadScene : MonoBehaviour {
    GameObject eventSystem;
    GameObject mainPanel;
    bool eventSystemActivate = true;
    UICreator ui;
    void Awake()
    {
        eventSystem = GameObject.Find("EventSystem");
        mainPanel = GameObject.Find("MainPanel").gameObject;
        ui = new UICreator(5);
    }

       
    
    public void enterStartScene()
    {
        Application.LoadLevel(0);
    }
    public void enterOnlineBattleScene()
    {
        Application.LoadLevel(1);
    }
    public void enterBagPanel()
    {
        mainPanel.SetActive(false);
        GameObject bagPanel = ui.createPanel("bag", GameObject.Find("RegularCanvas").gameObject.transform, 800, 500, 0, 0, "442432");
        bagPanel.AddComponent<BagView>();
    }
    public void returnToMain(GameObject putInvisibleObject)
    {
        Destroy(putInvisibleObject);
        mainPanel.SetActive(true);
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
