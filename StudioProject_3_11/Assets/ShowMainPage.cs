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
    private static int index;
    Texture2D origin;
    TeachModel ta;
    // Use this for initialization
    void Start() {
        Texture2D tex = Resources.Load<Texture2D>("button_lock");
        origin = Resources.Load<Texture2D>("button");
       
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
        index = model.yourCard.Count;
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
        string temp = "";
        model.saveCard("addDeckToList.csv", "卡冊(所有卡片),", false);
        foreach (string data in datas)
        {
            var ds = data.Split(',');
            StartCoroutine(model.catchWebData(this, "selectCard.php?num=" + ds[0] + "&album=" + ds[1]));
            //儲存牌組庫
            //過濾重複的牌組名稱
            if (!temp.Equals(ds[1]))
            {
                model.saveCard("addDeckToList.csv", ds[1] + ",", true);
                temp = ds[1];
            }
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
        model.saveCard("bag.csv", "bagcard" + this.addIndex().ToString() + "," + info, true);       
    }
    public void beTeach() {            
        StartCoroutine(model.catchWebData(ta, "Login.php?accountId=Teacher&passWord=teacher"));
       // ta.teacherSuccess();
        //AccountLevel.text = "Level  " + acct.accountLevel;
        //openBagLock();
        //downLoadCardData();
    }
    public void upDateLevel() {
        AccountLevel.text = "Level  " + acct.accountLevel;
        openBagLock();
        StartCoroutine(model.pushWebData("UpdateData.php?tname=Accounts&cname=AccountLevel&data=" + acct.accountLevel + "&conditionT=Account_Name&conditionV=" + acct.accountID));
        StartCoroutine(model.pushWebData("UpdateData.php?tname=Accounts&cname=Account_beg&data=" + acct.accountCard + "&conditionT=Account_Name&conditionV=" + acct.accountID));
        Debug.Log(acct.accountCard);
    }
    public int addIndex() {
      return  index++;
    }
}
