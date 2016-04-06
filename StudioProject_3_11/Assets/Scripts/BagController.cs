using UnityEngine;
using System.Collections;

public class BagController {
    UICreator ui;
    Transform allCardpanel,albumsCardpanel;
    MyCard bagCard ,bgAlbums;
    private int allCardLoadindex ,albumCardLoadindex;
    public BagController(UICreator view, Transform acp, Transform alp, MyCard model)
    {
        this.ui = view;
        this.allCardpanel = acp;
        this.albumsCardpanel = alp;
        this.bagCard = model;
        this.allCardLoadindex = 0;
        LoadCardToView();
        bgAlbums = new MyCard("cardAlbums.csv");
    }
    private void LoadCardToView()
    {
       
        int initialIndex = this.allCardLoadindex;
        int pre = initialIndex - 15;
        if (bagCard.getCardQuantity() - this.allCardLoadindex > 15)
        {
            this.allCardLoadindex += 15;
            ui.createButton("nextPage", allCardpanel, new Vector2(100, -200), new Vector2(200, 50), "下一頁", 18, Color.white, "button", delegate { GameObject.Find("bag").gameObject.GetComponent<BagView>().initial(allCardpanel); this.LoadCardToView(); });
            if(pre >= 0)
            {
                ui.createButton("prePage", allCardpanel, new Vector2(-100, -200), new Vector2(200, 50), "上一頁", 18, Color.white, "button", delegate { GameObject.Find("bag").gameObject.GetComponent<BagView>().initial(allCardpanel); this.setView(pre , initialIndex); });
            }
          
        }
        else
        {
            this.allCardLoadindex = bagCard.getCardQuantity();
        }
        
        setView(initialIndex ,this.allCardLoadindex);
    }
    private void LoadAlbums()
    {
       
        
    }
    private void setView(int initial ,int end) {
        int posX = 75;
        int posY = 120;
        for (int i = 0; initial < end; initial++, i++)
        {
            float x, y;
            x = initial % 5 * posX;
            y = i / 5 * posY;
            var s = bagCard.getCard(initial);
            ui.createCardGUI(s[0], allCardpanel, new Vector2(63, 108), new Vector2(x - 200 + 25, 200 - y - 75), s[1], s);
        }
        this.allCardLoadindex = initial;
    }

}
