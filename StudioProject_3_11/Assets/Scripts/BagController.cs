using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BagController {
    UICreator ui;
    Transform allCardpanel,albumsCardpanel;
    MyCard bagCard ,bgAlbums;
    private int allCardLoadindex , albumCardLoadindex, pageNum;
    private string PageName;
    List<GameObject> pages;
    public BagController(UICreator view, Transform acp, Transform alp, MyCard model)
    {
        this.ui = view;
        this.allCardpanel = acp;
        this.albumsCardpanel = alp;
        this.bagCard = model;
        this.allCardLoadindex = 0;
        PageName = "PagePanel";
        this.pageNum = 0;
        pages = new List<GameObject>();
        LoadCardToView();
        bgAlbums = new MyCard("cardAlbums.csv");
        
    }
    private void LoadCardToView()
    {
       
        int initialIndex = this.allCardLoadindex;
        setView(initialIndex ,this.allCardLoadindex);
    }
    private void LoadAlbums()
    {
        //新增牌組button
       
    }
    private void setView(int initial ,int end) {
        int posX = 75;
        int posY = 120;
        for(int i = 0; i < (bagCard.getCardQuantity()/15) + 1; i++)
        {
            pages.Add(ui.createPanel(PageName + i.ToString(), allCardpanel, 400, 450, 0, 0, "tileEdge"));
        }
        for (int i = 0; initial < end; initial++, i++)
        {
            float x, y;
            int pagedir = initial / 15;
            x = initial % 5 * posX;
            y = i / 5 * posY;
            var s = bagCard.getCard(initial);
            ui.createCardGUI(s[0], pages[pagedir].gameObject.transform, new Vector2(63, 108), new Vector2(x - 200 + 25, 200 - y - 75), s[1], s);
            if(pagedir > 0)
            {
                GameObject nextPageBut = ui.createButton("nextPage", pages[pagedir - 1].gameObject.transform, new Vector2(100, -200) ,new Vector2(200, 15), "下一頁", 18, Color.white, "button", delegate { this.PageControll(pagedir); });
                GameObject prePageBut = ui.createButton("prePage", pages[pagedir].gameObject.transform, new Vector2(-100, -200), new Vector2(200, 15), "上一頁", 18, Color.white, "button", delegate { this.PageControll(pagedir - 1); });
            }
        }
        PageControll(0);
    }
    private void PageControll(int page)
    {
        for(int i = 0; i < pages.Count; i++)
        {
            if(i == page)
            {
                pages[i].gameObject.SetActive(true);
            }
            else
            {
                pages[i].gameObject.SetActive(false);
            }
        }
    }

}
