using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Effect : MonoBehaviour {
    public string[] ef;
    public GameObject onHand;
    public MyCard mcard;
    public GameProcessControll gameController;
    public List<string> eventList;
    public static GameObject effectDoPanel = null;
    public string tile;
    // Use this for initialization
    void Start() {
        gameController = GameObject.Find("GameController").GetComponent<GameProcessControll>();
        onHand = GameObject.Find("HandArea");
        eventList = new List<string>();
        tile = this.gameObject.name;
        effectDoPanel = gameController.ViewUI.createPanel("whatCardwantoDo", GameObject.Find("RegularCanvas").gameObject.transform, 200, 200, 0, 0, "MessageBox");
        effectDoPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update() {
        foreach(string cmd in eventList)
        {
            when(cmd);
        }
    }
    //when
    public void when(string cmd) {
        var cm = cmd.Split(' ');
        if (cm[0].Equals("set"))
        {
            set(setcmd(cm));
        }
        //我修改部分
        else if (cm[0].Equals("Main"))
        {
            when(setcmd(cm));
            if (cm[0].Equals("OnGround"))
            {
                when(setcmd(cm));
            }
            else if (cm[0].Equals("dead"))
            {
                eventList.Add(cmd);
                if (System.Int32.Parse(this.gameController.GetComponent<CardData>().cm.cardLifePoint) <= 0)
                {
                    when(setcmd(cm));
                }
            }
        }

        else if (cm[0].Equals("Battle"))
        {
            when(setcmd(cm));
            if (cm[0].Equals("OnGround"))
            {
                when(setcmd(cm));
            }
            else if (cm[0].Equals("dead"))
            {
                eventList.Add(cmd);
                if (System.Int32.Parse(this.gameController.GetComponent<CardData>().cm.cardLifePoint) <= 0)
                {
                    when(setcmd(cm));
                }
            }
        }
     /*
        else if (cm[0].Equals("mix"))
        {

        }
        else if (cm[0].Equals("Ask"))
        {
            tileClickEvevtCheck();//做視窗 做效果發動button 作效果取消button
            eventList.Add("Ask");
        }*/
    }

    //which
    public GameObject which(string cmd)
    {
        var cm = cmd.Split(' ');
        GameObject g;
        if(cm[0].Substring(0, 4).Equals("self"))
        {
           g = GameObject.Find(gameController.GetComponent<Account>().accountID + cm[0].Substring(4,5));
        }
        else
        {
            g = GameObject.Find(cm[0]);
        }
        return g;
    }
    
    public void set(string cmd) {
        var cm = cmd.Split(' ');
        GameObject g = this.gameObject;
        if (cm[0].Equals("which"))
        {
            g = which(setcmd(cm));
   
        }
        else if (cm.Length > 0)
        {
            if (cm[0].Equals("HP"))
            {
                g.gameObject.GetComponent<CardData>().setHP(cm[1]);
            }
            else if (cm[0].Equals("Attack"))
            {
                g.gameObject.GetComponent<CardData>().setAttack(cm[1]);
            }
            else if (cm[0].Equals("Speed"))
            {
                g.gameObject.GetComponent<CardData>().setSpeed(cm[1]);
            }
            else if (cm[0].Equals("AttackRange"))
            {
                g.gameObject.GetComponent<CardData>().setAttackRange(cm[1]);
            }
            else if (cm[0].Equals("AttackType"))
            {
                g.gameObject.GetComponent<CardData>().setAttackType(cm[1]);
            }
            else if (cm[0].Equals("CardAttribute"))
            {
                g.gameObject.GetComponent<CardData>().setCardAttribute(cm[1]);
            }
            else if (cm[0].Equals("CardPosition"))
            {
                
            } 
            else if (cm[0].Equals("drawCard"))
            {
                drawCard(setcmd(cm));
            }
            else if (cm[0].Equals("search"))
            {
                

            }
            else
            {
                Debug.Log("No this function!!");
            }
        }
        else
        {
            Debug.Log("please Enter more than one parameter");
        }
    }
    public void onGround(string cmd) {
        var cm = cmd.Split(' '); 
        setcmd(cm); //移除onGround字串
        set(cmd); //再度執行set
    }
    public string setcmd(string[] cmd)
    {
        string result = null;
        for(int i = 1; i < cmd.Length; i++)
        {
            result += cmd[i] + " ";
        }
        return result;
    }
    public void drawCard(string cmd) {
        var cm = cmd.Split(' ');
        if (cm[0].Equals("which"))
        {
            cm = setcmd(cm).Split(' ');
            int index = System.Int32.Parse(cm[0]);
            cm = setcmd(cm).Split(' ');
            string tag = cm[0];            
            gameController.drawCard(mcard.cardIndex(index, tag));
        }
        else if (cm.Length > 0)
        {
            for(int i = 0; i < System.Int32.Parse(cm[0]); i++)
            {
                gameController.setStage(1);
                gameController.drawCard();
                gameController.setStage(2);
            }
        }
    }
    public void choose(int index, string who) {
        TileMouseOver tlmo = gameController.gameObject.AddComponent<TileMouseOver>();
        for(int i = 0; i < this.transform.parent.transform.gameObject.transform.childCount; i++)
        {
            GameObject g = this.transform.parent.transform.gameObject.transform.GetChild(i).gameObject;
            if (g.name.Equals(this.name))
            {
                //matirial set
                if (g.GetComponent<CardData>().cm.info[index].Equals(who))
                {
                    g.GetComponent<Renderer>().material.color = new Color(0, 1, 0, 0.3f);
                }
            }
        }
    }
    void tileClickEvevtCheck() {
        if (Input.GetMouseButtonDown(0))
        {
            //focusObj = null;
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                // focusObj = hit.transform.gameObject;
                /*if (focusObj.tag == "Tile" && !focusObj.GetComponent<ForTile>().isUsed)
                {
                    this.setTileToNormalColor();
                    focusObj.GetComponent<ForTile>().setCardOnTile(m, GameObject.Find(cardName));
                    GetComponent<LoadScene>().changeEventSystemStatus();
                }*/
                GameObject focusObj = hit.transform.gameObject;
                if (focusObj.name.Equals(tile))
                {
                    Debug.Log(tile);

                 //effectDoBuuton
                    TileMouseOver TMO = gameController.GetComponent<TileMouseOver>();
                    TMO.resetHighLightColor();
                    TMO.setCardName(this.gameObject.name, null);
                    //TMO.setTileToHighLightColor(position);
                    eventList.Remove("Ask");
                }

            }

        }
    }
    void effectDoButton(string buttonName ,string cmd) {
        var cm = cmd.Split(' ');
        //make panel
        //make do effect button
        //effect button will do the setcmd(cm)
        //make cancel button
        //cancel button destroy this gobj and this script
        //最後要AddcardMove
    }
}
