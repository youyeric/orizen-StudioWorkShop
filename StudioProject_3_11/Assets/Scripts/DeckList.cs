using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class DeckList : MonoBehaviour {
    public MyCard cardAlbum, deckList;
    UICreator uic;
    GameObject deckContentContent;
    GameObject deckListContent;
    GameObject temp;
    void Start () {
        deckContentContent = GameObject.Find("DeckContentContent");
        deckListContent = GameObject.Find("DeckListContent");
        cardAlbum = new MyCard();
        deckList = new MyCard();
        deckList.loadCard("addDeckToList.csv");
        cardAlbum.loadCard("bag.csv");
        uic = new UICreator(5);
        callDeckList();
        callDeckContent();
    }
    public void callDeckList()
    {
        int i = 0;
        RectTransform tranRect = deckListContent.GetComponent<RectTransform>();
        float height = 0;
        int width = 320;
        float posY;
        float posX = 0;
        foreach (string[] data in deckList.yourCard)
        {
            height += 65f;
        }
        if (height<=410)
        {
            height = 410;
        }
        tranRect.sizeDelta = new Vector2(width, height + 65f);
        posY = (height + 65)/2 - 32.5f;
        foreach (string[] data in deckList.yourCard)
        {
            if (i == 0)
            {
                temp = uic.createImage(data[0], deckListContent.gameObject.transform, new Vector2(320, 60), new Vector2(posX, posY - 65 * i), "decklist");
                temp.AddComponent<Button>();
                Text tx = uic.createText(data[0] + "Text", GameObject.Find(data[0]).gameObject.transform, -25, 0, 250, 30, data[0], 25, Color.white).GetComponent<Text>();
                tx.alignment = TextAnchor.MiddleLeft;
                i++;
            }
            else
            {
                temp = uic.createImage(data[0], deckListContent.gameObject.transform, new Vector2(320, 60), new Vector2(posX, posY - 65 * i), "decklist");
                temp.AddComponent<Button>();
                Text tx = uic.createText(data[0] + "Text", GameObject.Find(data[0]).gameObject.transform, -25, 0, 250, 30, data[0], 25, Color.white).GetComponent<Text>();
                tx.alignment = TextAnchor.MiddleLeft;
                uic.createButton(data[0] + "Edit", GameObject.Find(data[0]).gameObject.transform, new Vector2(130, 0), new Vector2(50, 50), "編輯", 18, Color.white, "button", delegate { this.GetComponent<LoadScene>().enterEditDeckScene(); });
                GameObject delete;
                delete = uic.createButton(data[0] + "Delete", GameObject.Find(data[0]).gameObject.transform, new Vector2(75, 0), new Vector2(50, 50), "刪除", 18, Color.white, "button", delegate { });
                delete.AddComponent<Temp>().objectName = data[0];
                delete.GetComponent<Temp>().index = i;
                delete.GetComponent<Button>().onClick.AddListener(delegate { delete.GetComponent<Temp>().destroyParents(); });
                i++;
            }
        }
    }
    public void callDeckContent()
    {
        int i = 0;
        RectTransform tranRect = deckContentContent.GetComponent<RectTransform>();
        float height = 0;
        int width = 320;
        float posY;
        float posX = -128.5f;
        foreach (string[] data in cardAlbum.yourCard)
        {
            height += 130.7f;
        }
        if (height <= 410)
        {
            height = 410;
        }
        tranRect.sizeDelta = new Vector2(width, height / 4 + 130.7f);
        posY = (height / 4 + 130.7f) / 2 - 55;
        foreach (string[] data in cardAlbum.yourCard)
        {
            uic.createImage("DeckContent" + i, deckContentContent.gameObject.transform, new Vector2(63, 108), new Vector2(posX + (85.7f * (i % 4)), posY - 130.7f * (i / 4)), data[9]);
            i++;
        }
    }
    public void reLoadScene()
    {
        deckList.saveCard("addDeckToList.csv", deckList.getCard(0)[0], false);
        for (int i = 1; i < deckList.getCardQuantity(); i++)
        {
            deckList.saveCard("addDeckToList.csv", deckList.getCard(i)[0], true);
        }
        this.GetComponent<LoadScene>().enterBagScene();
    }
}
