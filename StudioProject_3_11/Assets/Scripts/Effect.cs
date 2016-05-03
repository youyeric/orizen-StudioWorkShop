using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Effect : MonoBehaviour {
    public string[] ef;
    public GameObject onHand;
    public MyCard mcard;
    public GameProcessControll gameController;
    public List<string> eventList;
    // Use this for initialization
    void Start() {
        gameController = GameObject.Find("GameController").GetComponent<GameProcessControll>();
        onHand = GameObject.Find("HandArea");
        eventList = new List<string>();
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
        else if (cm[0].Equals("drawCard"))
        {
            drawCard(setcmd(cm));
        }
        else if (cm[0].Equals("OnGround"))
        {
            when(setcmd(cm));
        }
        else if (cm[0].Equals("dead"))
        {
            eventList.Add(cmd);
            if(System.Int32.Parse(this.gameController.GetComponent<CardData>().cm.cardLifePoint) <= 0)
            {
                when(setcmd(cm));
            }
        }
        else if (cm[0].Equals("mix"))
        {

        }
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
            else if (cm[0].Equals("OnGround")) {

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
}
