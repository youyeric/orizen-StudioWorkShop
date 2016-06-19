using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class ShowMainPage : MonoBehaviour, ShowWebInfo
{
    public Text AccountId, AccountLevel;
    private Account acct;
    private MyCard model;
    public GameObject bag, connectBattle;
    private int index;
    Texture2D origin;
    TeachModel ta;
    // Use this for initialization
    void Start() {
        Texture2D tex = Resources.Load<Texture2D>("button_lock");
        origin = Resources.Load<Texture2D>("button");
        index = 0;
        acct = Account.getAccountInstance;
        AccountId.text = acct.accountID;
        AccountLevel.text = "Level  " + acct.accountLevel;
        if (Int32.Parse(acct.accountLevel) == 0)
        {
            bag.GetComponent<Button>().enabled = false;
            bag.GetComponent<Image>().sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0.5f, 0.5f));
            connectBattle.GetComponent<Button>().enabled = false;
            connectBattle.GetComponent<Image>().sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0.5f, 0.5f));
            ta = this.gameObject.AddComponent<TeachModel>();
        }

        model = new MyCard();
        if (model.isFileExist("bag.csv"))
        {
            Debug.Log("hello");
        }
        else
        {
            downLoadCardData();
        }
        //show(acct.accountCard);
    }

    // Update is called once per frame
    void Update() {

    }
    public void downLoadCardData() {
        var datas = acct.accountCard.Split('/');
        foreach (string data in datas)
        {
            var ds = data.Split(',');
            StartCoroutine(model.catchWebData(this, "selectCard.php?num=" + ds[0] + "&album=" + ds[1]));
            index++;
        }
    }
    public void openBagLock() {
        bag.GetComponent<Button>().enabled = true;
        bag.GetComponent<Image>().sprite = Sprite.Create(origin, new Rect(0, 0, origin.width, origin.height), new Vector2(0.5f, 0.5f));
    }
    public void openConnectLock() {
        connectBattle.GetComponent<Button>().enabled = true;
        connectBattle.GetComponent<Image>().sprite = Sprite.Create(origin, new Rect(0, 0, origin.width, origin.height), new Vector2(0.5f, 0.5f));
    }
        
    public void show(string info)
    {
        if(index == 0)
        {
            model.saveCard("bag.csv", info, false);
        }
        else
        {
            model.saveCard("bag.csv", info, true);
        }
        
    }
    public void beTeach() {
        acct.accountLevel = (Int32.Parse(acct.accountLevel)+1).ToString();
        AccountLevel.text = "Level  " + acct.accountLevel;
        ta.teacherSuccess();
        StartCoroutine(model.catchWebData(ta, "Login.php?accountId=Teacher&passWord=teacher"));
        //downLoadCardData();
    }
}
