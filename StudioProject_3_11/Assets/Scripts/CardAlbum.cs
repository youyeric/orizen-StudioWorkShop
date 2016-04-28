using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class CardAlbum : MonoBehaviour {
    MyCard cardAlbum;
    UICreator uic;
    GameObject cardAlbumContent;
    GameObject deckContentContent;
    void Start()
    {
        cardAlbumContent = GameObject.Find("CardAlbumContent");
        deckContentContent = GameObject.Find("DeckContentContent");
        cardAlbum = new MyCard();
        cardAlbum.loadCard("cardAlbum.csv");
        uic = new UICreator(5);
        callDeckContent();
        callCardAlbum();
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
            uic.createImage("DeckContent" + i, deckContentContent.gameObject.transform, new Vector2(63, 108), new Vector2(posX+(85.7f*(i%4)), posY- 130.7f * (i/4)), data[9]);
            i++;
        }
    }
    public void callCardAlbum()
    {
        int i = 0;
        RectTransform tranRect = cardAlbumContent.GetComponent<RectTransform>();
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
            uic.createImage("CardAlbum" + i, cardAlbumContent.gameObject.transform, new Vector2(63, 108), new Vector2(posX + (85.7f * (i % 4)), posY - 130.7f * (i / 4)), data[9]);
            i++;
        }
    }
}
