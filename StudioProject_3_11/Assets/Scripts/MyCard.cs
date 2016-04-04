using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;




public class MyCard {
   //暫存牌庫
    private List<string[]> yourCard;
    private string CardDataPathBase;
    private StreamReader SR;
    private System.Random r;

    private int i;

    public MyCard()
    {
        r = new System.Random();
        this.i = 0;
        yourCard = new List<string[]>();
        this.loadCard();
    }

    public void loadCard() {
        string str;
        SR = new StreamReader(System.Environment.CurrentDirectory + "/CardData/cardAlbum.csv");
        str = SR.ReadLine();
        while (str != null)
        {
       
            var data = str.Split(',');
            yourCard.Add(data);
            //this.addCard(data, int.Parse(data[9]));
            str = SR.ReadLine();
           
        }
        SR.Close();
    }
    public void addCard(string[] data,int cardQuantity)
    {
        for(int i = 0; i< cardQuantity; i++)
        {
            yourCard.Add(data);
        }
    }
	public string[] getCard(int quantity)
    {
        
        return yourCard[quantity];
    }
   public void cardAdd(string c_name , int cardQuantity)
    {
        for(int i = 0; i < cardQuantity; i++)
        {
            //yourCard.Add(new Card(c_name ,"+5"));
        }
    }
   /* void startGetCard()
    {
        textobject = new GameObject("Text");
        textobject.transform.SetParent(parent.transform);
        textobject.layer = 5;
        RectTransform trans = textobject.AddComponent<RectTransform>();

    }*/
}
