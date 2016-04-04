using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameProcessControll{
    private int round;
    private int stage;
    private MyCard mcard;
    private int handcardposition;
    private int cardpositionNum;
    private UICreator ViewUI;
    private int cardQuantity;
    private string setCardQuantitySt;
    public GameProcessControll(MyCard m,UICreator UI)
    {
        this.round = 0;
        this.stage = 0;
        this.mcard = m;
        this.ViewUI = UI;
        this.handcardposition = 0;
        this.cardpositionNum = 600 / 5;
        this.cardQuantity = 40;
        
        initial();       
    }
    void initial()
    {
        //把排導到場上牌堆
        //action 抽五張牌
        var s = mcard.getCard(1);
        for(int i = 0; i < 5; i++)
        {
            GameObject temp = ViewUI.createCardGUI(s[1], GameObject.Find("HandArea").gameObject.transform, new Vector2(63, 108), new Vector2(handcardposition - 100, 0), "wolf", s);
           
            changePosition();
        }
        ViewUI.createButton("DeckImg", GameObject.Find("RegularCanvas").gameObject.transform, new Vector2(300, -185), new Vector2(63, 108), cardQuantity.ToString(), 40, new Color(1, 1, 1), "wolf", delegate { drawCard(); });
       
        //handCard = s;
        round++;
        //UI家五張卡
    }
    void mainStage()
    {
        this.stage = 1;
        //主要階段：每次只能召喚一次，怪獸效果或是魔法卡等輔助的召喚並不再此限制，魔法卡的使用沒有上限。
    }
    void BattleStage()
    {
        this.stage = 2;
        //戰鬥階段：這個階段中可以移動怪獸並進行戰鬥，這個階段可能會有相對的魔法卡可以輔助使用。
    }
    void changePosition() {
        if (handcardposition == 0)
        {
            handcardposition += cardpositionNum;
        }
        else if (handcardposition > 0) {
            handcardposition = 0 - handcardposition;
        }
        else if (handcardposition < 0)
        {
            handcardposition = cardpositionNum - handcardposition;
        }
    }
    public void drawCard() {
        cardQuantity--;
        GameObject.Find("DeckImgText").gameObject.GetComponent<Text>().text = cardQuantity.ToString();
    }
}
