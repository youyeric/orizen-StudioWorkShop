using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.UI;

public class CardData : MonoBehaviour
{
    public UICreator ui;
    public CardModel cm;
    Material tex;
    Texture2D texs;
    MyCard cd;
    void Start()
    {
       
        //ui.createText("Text", this.gameObject.transform, 0, 0, 63, 108, cm.cardName, 10, Color.white);
        if (cm.state.Equals("OnHand"))
        {
            if (cm.cardPicturePath.Equals("n"))
            {
                texs = Resources.Load<Texture2D>("titleEdge");
                this.gameObject.GetComponent<Image>().sprite = Sprite.Create(texs, new Rect(0, 0, texs.width, texs.height), new Vector2(0.5f, 0.5f));
            }
            else
            {
                texs = Resources.Load<Texture2D>(cm.cardPicturePath);
                this.gameObject.GetComponent<Image>().sprite = Sprite.Create(texs, new Rect(0, 0, texs.width, texs.height), new Vector2(0.5f, 0.5f));
            }

        }
        else
        {
            if (cm.cardPicturePath.Equals("n"))
            {
                tex = Resources.Load<Material>("Materials/tileEdge");
                this.gameObject.GetComponent<Renderer>().material = tex;
            }
            else
            {
                tex = Resources.Load<Material>("Materials/"+cm.cardPicturePath);
                this.gameObject.GetComponent<Renderer>().material = tex;
            }    
       }
    }
    void Update()
    {

    }
    public void attack(GameObject who) {
        //目標cardTile.getComponent<CardData>()
        //目標card.actionEffect(-cardAttack,0,0,0,0,0);
    }
    public void actionEffect(int vCarLifepoint, int vCardAttack, int vCardSpeed, int vAttackRange, string vAttackType, string vCardAttribute) {
        int lfp = System.Int32.Parse(cm.cardLifePoint);
        int attac = System.Int32.Parse(cm.cardAttack);
        int spee = System.Int32.Parse(cm.cardSpeed);
        int AtaR = System.Int32.Parse(cm.attackRange);
        lfp += vCarLifepoint;
        attac += vCardAttack;
        spee += vCardSpeed;
        AtaR += vAttackRange;
        cm.cardLifePoint = lfp.ToString();
        cm.cardAttack = attac.ToString();
        cm.cardSpeed = spee.ToString();
        cm.attackRange = AtaR.ToString();
        cm.attackType = vAttackType;
        cm.cardAttribute = vCardAttribute;
    }
    public void setHP(string value) {
        int changeValue = System.Int32.Parse(value);
        actionEffect(changeValue, 0, 0, 0, cm.attackType, cm.cardAttribute);
    }
    public void setAttack(string value)
    {
        int chageValue = System.Int32.Parse(value);
        actionEffect(0, chageValue, 0, 0, cm.attackType, cm.cardAttribute);
    }
    public void setSpeed(string value)
    {
        int chageValue = System.Int32.Parse(value);
        actionEffect(0, 0, chageValue, 0, cm.attackType, cm.cardAttribute);
    }
    public void setAttackRange(string value)
    {
        int chageValue = System.Int32.Parse(value);
        actionEffect(0, 0, 0, chageValue, cm.attackType, cm.cardAttribute);
    }
    public void setAttackType(string value)
    {
        actionEffect(0, 0, 0, 0, value, cm.cardAttribute);
    }
    public void setCardAttribute(string value)
    {
        actionEffect(0, 0, 0, 0, cm.attackType, value);
    }

}
