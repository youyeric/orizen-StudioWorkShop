using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class CardSelected : MonoBehaviour {
    TileMouseOver tileMouseOver;
    string thisName;
    bool isCardSeleted = false;
    UICreator uic = new UICreator(5);
    Button setCardButton;
    Button thisCardButton;
    private static GameObject whatCardwantoDo = null;
    GameObject gameController;
    Material newMaterial;
    void Start()
    {
        thisCardButton = this.GetComponent<Button>();
        gameController = GameObject.Find("GameController");
        thisName = this.transform.name;
        newMaterial = Resources.Load("Materials/wolf", typeof(Material)) as Material;
    }
    public void selected() {
        if (!isCardSeleted && GameObject.Find("whatCardwantoDo") == null)
        {
            float Xposition = this.gameObject.GetComponent<RectTransform>().anchoredPosition.x;
            whatCardwantoDo = uic.createPanel("whatCardwantoDo", GameObject.Find("RegularCanvas").gameObject.transform, 200, 200, Xposition, 0, "MessageBox");
            setCardButton = uic.createButton("set", GameObject.Find("whatCardwantoDo").gameObject.transform, 0, 53, 160, 50, "放置", 30, Color.white, "button").GetComponent<Button>();
            setCardButton.onClick.AddListener(delegate { setCardButtonScript(); });
            isCardSeleted = true;
        }
        else
        {
            if (GameObject.Find("whatCardwantoDo") != null)
            {
                Destroy(whatCardwantoDo);
            }
            isCardSeleted = false;
        }
    }
    public void setCardButtonScript()
    {
        thisCardButton.interactable = false;
        Destroy(whatCardwantoDo);
        gameController.AddComponent<TileMouseOver>();
        gameController.GetComponent<TileMouseOver>().setCardName(thisName, newMaterial);
        gameController.GetComponent<TileMouseOver>().setTileToHighLightColor();
        gameController.GetComponent<LoadScene>().changeEventSystemStatus();
    }
}