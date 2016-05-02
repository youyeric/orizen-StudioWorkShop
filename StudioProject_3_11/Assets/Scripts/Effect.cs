using UnityEngine;
using System.Collections;

public class Effect : MonoBehaviour {
    public string[] ef;
    public GameObject gameController;
    // Use this for initialization
    void Start() {
        gameController = GameObject.Find("GameController");
    }

    // Update is called once per frame
    void Update() {

    }
    //when
    public void when(string cmd) {
        var cm = cmd.Split(' ');
        if (cm[0].Equals("set"))
        {
            set(this.gameObject , setcmd(cm));
        }


    }

    //which
    public void which(string cmd)
    {
        var cm = cmd.Split(' ');
        if(cm[0].Substring(0, 4).Equals("self"))
        {
            set(GameObject.Find(gameController.GetComponent<Account>().accountID + cm[0].Substring(4,5)), setcmd(cm));
        }
        
    }
    public void set(GameObject g, string cmd) {
        var cm = cmd.Split(' ');
        if (cm[0].Equals("which"))
        {
            which(setcmd(cm));
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
}
