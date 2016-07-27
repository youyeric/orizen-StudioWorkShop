using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using NLua;

public class DeckList : MonoBehaviour
{
    Lua env;
    public MyCard cardAlbum, deckList;
    UICreator uic;
    GameObject deckContentContent;
    GameObject deckListContent;
    List<GameObject> deckbutton;
    GameObject temp;
    public Text AlbuName;
    public Text cardName;
    private Vector2 DeckSize = new Vector2(0, 320);
    

    void Start()
    {
        deckbutton = new List<GameObject>();
        deckContentContent = GameObject.Find("DeckContentContent");
        deckListContent = GameObject.Find("DeckListContent");
        AlbuName = GameObject.Find("DeckListTabText").GetComponent<Text>();
        cardName = GameObject.Find("DeckContentTabText").GetComponent<Text>();
        cardAlbum = new MyCard();
        deckList = new MyCard();
        deckList.loadCard("addDeckToList.csv");
        cardAlbum.loadCard("bag.csv");
        uic = new UICreator(5);
        callDeckList();
        callDeckContent(deckContentContent.gameObject.transform, "default");
        addCardSelectInterface();
    }
    public void callDeckList()
    {
        int i = 0;
        RectTransform tranRect = deckListContent.GetComponent<RectTransform>();
       
        int width = (int)DeckSize.y;
        float posY;
        float posX = 0;
        float height = DeckSize.x + deckList.yourCard.Count*65f;

        if (height <= 410)
        {
            height = 410;
        }
        tranRect.sizeDelta = new Vector2(width, height + 65f);
        posY = (height + 65) / 2 - 32.5f;
        foreach (string[] data in deckList.yourCard)
        {
            if (i == 0)
            {
                uic.createButton(data[0], deckListContent.gameObject.transform, new Vector2(posX, posY - 65 * i), new Vector2(320, 60), data[0], 25, Color.white, "decklist", delegate { resetDeckContentContent(); callDeckContent(deckContentContent.gameObject.transform, "default"); addCardSelectInterface(); Debug.Log("push it!!"); });

                i++;
            }
            else
            {
                temp = uic.createButton(data[0], deckListContent.gameObject.transform, new Vector2(posX, posY - 65 * i), new Vector2(320, 60), data[0], 25, Color.white, "decklist", delegate { resetDeckContentContent(); });
                DeckAlbumSelect deckTemp = temp.AddComponent<DeckAlbumSelect>();
                deckTemp.objectname = data[0];

                GameObject edit = uic.createButton(data[0] + "Edit", GameObject.Find(data[0]).gameObject.transform, new Vector2(130, 0), new Vector2(50, 50), "編輯", 18, Color.white, "button", delegate { });
                EditCardAlbum editcardalb = edit.AddComponent<EditCardAlbum>();
                editcardalb.albumName = data[0];

                GameObject delete = uic.createButton(data[0] + "Delete", GameObject.Find(data[0]).gameObject.transform, new Vector2(75, 0), new Vector2(50, 50), "刪除", 18, Color.white, "button", delegate { });
                Temp deleteTemp = delete.AddComponent<Temp>();
                deleteTemp.objectName = data[0];
                deleteTemp.index = i;

                i++;
            }
        }
    }
    public void callDeckContent(Transform tr, string Album)
    {
        int i = 0;
        RectTransform tranRect = deckContentContent.GetComponent<RectTransform>();
        float height = DeckSize.x + cardAlbum.yourCard.Count*130.7f;
        int width = (int)DeckSize.y;
        float posY;
        float posX = -128.5f;
        if (height <= 410)
        {
            height = 410;
        }
        tranRect.sizeDelta = new Vector2(width, height / 4 + 130.7f);
        posY = (height / 4 + 130.7f) / 2 - 55;
        if (Album.Equals("default"))
        {
            foreach (string[] data in cardAlbum.yourCard)
            {
                uic.createImage(data[0], tr, new Vector2(63, 108), new Vector2(posX + (85.7f * (i % 4)), posY - 130.7f * (i / 4)), data[10]);
                i++;
            }
        }
        else if (Album.Equals("remain"))
        {
            Debug.Log(AlbuName.text);
            foreach (string[] data in cardAlbum.cardSelectByAlbumRemain(AlbuName.text))
            {
                uic.createImage(data[0], tr, new Vector2(63, 108), new Vector2(posX + (85.7f * (i % 4)), posY - 130.7f * (i / 4)), data[10]);
                i++;
            }
        }
        else
        {
            List<string[]> datas = cardAlbum.cardSelectByAlbum(Album);
            foreach (string[] data in datas)
            {
                uic.createImage(data[0], tr, new Vector2(63, 108), new Vector2(posX + (85.7f * (i % 4)), posY - 130.7f * (i / 4)), data[10]);
                i++;
            }
        }

    }
    public void reLoadScene()
    {
        deckList.saveCard("addDeckToList.csv", deckList.getCard(0)[0], false);
        for (int i = 1; i < deckList.yourCard.Count; i++)
        {
            deckList.saveCard("addDeckToList.csv", deckList.getCard(i)[0], true);
        }
        this.GetComponent<LoadScene>().enterBagScene();
    }
    public void resetDeckContentContent()
    {
        foreach (Transform child in deckContentContent.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }
    public void resetDeckListContent()
    {
        foreach (Transform child in deckListContent.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }
    public void switchListContent(GameObject g)
    {
        if (g.transform.parent.name.Equals("DeckContentContent"))
        {
            g.transform.SetParent(deckListContent.gameObject.transform);
            int children = deckListContent.gameObject.transform.childCount - 1;
            int elementCount = cardAlbum.yourCard.Count;
            g.GetComponent<RectTransform>().anchoredPosition = new Vector2(-128.5f + (85.7f * (children % 4)), (((DeckSize.x + (130.7f * elementCount)) / 4 + 130.7f) / 2 - 55) - 130.7f * (children / 4));
            //add           
            cardAlbum.addOneCardAlbumByBagId(g.name, AlbuName.text);
            restructedContent();
        }
        else
        {
            g.transform.SetParent(deckContentContent.gameObject.transform);
            int children = deckContentContent.gameObject.transform.childCount - 1;
            int elementCount = cardAlbum.yourCard.Count;
            g.GetComponent<RectTransform>().anchoredPosition = new Vector2(-128.5f + (85.7f * (children % 4)), (((DeckSize.x + (130.7f * elementCount)) / 4 + 130.7f) / 2 - 55) - 130.7f * (children / 4));
            //remove
            cardAlbum.removeOneCardAlbumByBagId(g.name, AlbuName.text);
            restructedList();
        }
    }
    public void restructedContent()
    {
        int i = 0;
        int elementCount = cardAlbum.yourCard.Count;
        foreach (Transform child in deckContentContent.transform)
        {
            child.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(-128.5f + (85.7f * (i % 4)), (((DeckSize.x + (130.7f * elementCount)) / 4 + 130.7f) / 2 - 55) - 130.7f * (i / 4));
            i++;
        }
    }
    public void restructedList()
    {
        int i = 0;
        int elementCount = cardAlbum.yourCard.Count;
        foreach (Transform child in deckListContent.transform)
        {
            child.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(-128.5f + (85.7f * (i % 4)), (((DeckSize.x + (130.7f * elementCount)) / 4 + 130.7f) / 2 - 55) - 130.7f * (i / 4));
            i++;
        }
    }
    public void addSwitchEvent()
    {
        foreach (Transform child in deckContentContent.transform)
        {
            child.gameObject.AddComponent<SwitchListContent>();
        }
        foreach (Transform child in deckListContent.transform)
        {
            child.gameObject.AddComponent<SwitchListContent>();
        }
    }
    public void addCardSelectInterface() {
        foreach (Transform child in deckContentContent.transform) {
            child.gameObject.AddComponent<BagCardSelected>();
        }
    }
    public void editCardAlbumView(string album) {
        GameObject Buttons = GameObject.Find("Buttons");
        GameObject checkButton = GameObject.Find("AddNewDeck");
        
        Destroy(checkButton);
        resetDeckContentContent();
        resetDeckListContent();
        AlbuName.text = album;
        cardName.text = "剩餘卡牌";
       
        uic.createButton("checkButton", Buttons.transform, new Vector2(-323, -165), new Vector2(50, 50), "確定", 18, Color.white, "button", delegate { cardAlbum.saveAllCard("bag.csv"); GameObject.Find("GameController").GetComponent<LoadScene>().enterBagScene(); });
        uic.createButton("return", Buttons.transform, new Vector2(-65, -165), new Vector2(50,50), "返回卡冊", 18, Color.white, "button",delegate { GameObject.Find("GameController").GetComponent<LoadScene>().enterBagScene(); } );
        callDeckContent(deckListContent.gameObject.transform,album);
        callDeckContent(deckContentContent.gameObject.transform, "remain");
        addSwitchEvent();
    }
}
