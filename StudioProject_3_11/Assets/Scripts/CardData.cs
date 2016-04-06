using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.UI;

public class CardData : MonoBehaviour
{
    public string cardNumber, cardName, cardLifePoint, cardAttack, cardSpeed, attackRange, gold,
           attackType, cardAttribute, cardPicturePath;
    public string[] cardAlbums;
    public UICreator ui;
    Texture2D tex;

    void Start()
    {
       
        ui.createText("Text", this.gameObject.transform, 0, 0, 63, 108, cardName, 10, Color.white);
        if (cardPicturePath.Equals("n"))
        {
            tex = Resources.Load<Texture2D>("tileEdge");
            this.gameObject.GetComponent<Image>().sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0.5f, 0.5f));
        }
        else
        {
            tex = Resources.Load<Texture2D>(cardPicturePath);
            this.gameObject.GetComponent<Image>().sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0.5f, 0.5f));
        }
    }
    
}
