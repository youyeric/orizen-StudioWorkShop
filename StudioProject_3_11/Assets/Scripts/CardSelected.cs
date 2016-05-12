using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class CardSelected : MonoBehaviour {
    TileMouseOver tileMouseOver;
    public string thisName;
    string mName;
    bool isCardSeleted = false;
    UICreator uic = new UICreator(5);
    Button setCardButton;
    Button thisCardButton;
    private static GameObject whatCardwantoDo = null;
    GameObject gameController;
    Material newMaterial;
    public GameObject[] cards;
    void Start()
    {
        mName = this.GetComponent<CardData>().cm.cardPicturePath;
        thisCardButton = this.GetComponent<Button>();
        gameController = GameObject.Find("GameController");
        thisName = this.transform.name;
        newMaterial = Resources.Load("Materials/"+mName, typeof(Material)) as Material;
    }
    public void selected() {
        if (!isCardSeleted && GameObject.Find("whatCardwantoDo") == null)
        {
            float Xposition = this.gameObject.GetComponent<RectTransform>().anchoredPosition.x + 30;
            whatCardwantoDo = uic.createPanel("whatCardwantoDo", GameObject.Find("RegularCanvas").gameObject.transform, 200, 200, Xposition, 0, "MessageBox");
            setCardButton = uic.createButton("set", GameObject.Find("whatCardwantoDo").gameObject.transform, new Vector2(0, 53), new Vector2(160, 50), "放置", 30, Color.white, "button", delegate { setCardButtonScript();}).GetComponent<Button>();
            this.gameObject.tag = "Untagged";
            if (cards == null)
                cards = GameObject.FindGameObjectsWithTag("Card");
            foreach(GameObject go in cards)
                go.GetComponent<Button>().interactable = false;
            isCardSeleted = true;
        }
        else
        {
            if (GameObject.Find("whatCardwantoDo") != null)
            {
                Destroy(whatCardwantoDo);
                foreach (GameObject go in cards)
                    go.GetComponent<Button>().interactable = true;
                this.gameObject.tag = "Card";
            }
            isCardSeleted = false;
        }
    }
    public void setCardButtonScript()
    {
        foreach (GameObject go in cards)
            go.GetComponent<Button>().interactable = true;
        this.gameObject.tag = "Card";
        thisCardButton.interactable = false;
        Destroy(whatCardwantoDo);
        TileMouseOver TMO = gameController.AddComponent<TileMouseOver>();
        TMO.tags = "Tile";
        TMO.setInnitailTile();
        TMO.setCardName(thisName, newMaterial);
        
        TMO.setTileToHighLightColor();
        gameController.GetComponent<LoadScene>().changeEventSystemStatus();
    }
}
