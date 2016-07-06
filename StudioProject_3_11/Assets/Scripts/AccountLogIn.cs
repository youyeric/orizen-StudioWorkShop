using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

public class AccountLogIn : MonoBehaviour,ShowWebInfo {
    public string accountID;
    public string accountName;
    public Button checkButton;
    public GameObject viewBase;
    public InputField ID,Passwd;
    Account acct;
    private UICreator view;
    private MyCard cd;
    private LoadScene ls;
    
	// Use this for initialization
	void Start () {
        view = new UICreator(5);
        cd = new MyCard();
        acct = Account.getAccountInstance;
        ls = this.GetComponent<LoadScene>();
        
        Debug.Log("UpdateData.php?tname=Accounts&cname=AccountLevel&data=2&conditionT=Account_Name&conditionV=youyeric");
        if (cd.isFileExist("account.txt"))
        {
            cd.loadCard("account.txt");
            //accountID = cd.getCard(0)[0];
            //accountName = cd.getCard(0)[1];
            acct.setAccountId(cd.yourCard[0][0]);
            acct.accountPassword = cd.yourCard[0][0];
           Debug.Log(cd.yourCard[0][2]);
            acct.setAccountLevel(cd.yourCard[0][2]);
            //跳轉遊戲主畫面
            ls.enterMainScene();
        }
        else
        {
            checkButton.onClick.AddListener(() => this.signIn());
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void signIn() {
        Debug.Log(ID.text + Passwd.text);
        //StartCoroutine(webPost.WaitForRequest(webPost.POST("http://studiogame-orizen.rhcloud.com/Login.php", post)));
        StartCoroutine(cd.catchWebData(this,"Login.php?accountId="+ ID.text + "&passWord=" + Passwd.text));

    }

    public void show(String info)
    {
        if (info.Equals("ID or Password don't be null!")) { nullView(); }
        else if (info.Equals("Login Failed!! Check your Id and Password.")) { failView(); }
        else {
            successView(info);
        }
    }
    void successView(string info) {
        GameObject pbase = view.createPanel("LoginSuccess", viewBase.transform, 500, 200, 0, 0, "MessageBox");
        view.createText("LoginSuccessText",pbase.transform,-50 ,50, 500, 50, info, 30, Color.green);
        //把資料傳給AccountModel Account.cs
        acct.setAccountLevel(info.Split(' ')[2]);
        acct.setAccountCardData(info.Split(' ')[0]);
        acct.setAccountId(info.Split(' ')[5]);
        Debug.Log(acct.accountID);
        //把資料存在account.txt
        cd.saveCard("account.txt", ID.text + "," + Passwd.text + "," + acct.accountLevel, false);
        //跳轉
        ls.enterMainScene();

    }
    /*void dealCardDownload(string data) {
        var datas = data.Split(',');
        foreach(string d in datas)
        {
            var ds = d.Split('/');
            StartCoroutine(cd.catchWebData(this, "selectCard.php?num=" + ds[ds.Length - 1]));
        }
        
    }*/
    void failView() {
        GameObject pbase = view.createPanel("Loginfail", viewBase.transform, 500, 200, 0, 0, "MessageBox");
        view.createText("LoginFailText", pbase.transform, -30, 50, 500, 50, "Login Failed!! Check your Id and Password.", 20, Color.green);
        view.createButton("checkButton", pbase.transform, new Vector2(0, 0), new Vector2(100, 20), "Check", 14, Color.white, "button", delegate { Destroy(GameObject.Find("Loginfail")); });
    }
    void nullView() {
        GameObject pbase = view.createPanel("LoginNull", viewBase.transform, 500, 200, 0, 0, "MessageBox");
        view.createText("LoginNullText", pbase.transform, -30, 50, 500, 50, "ID or Password don't be null!", 30, Color.green);
        view.createButton("checkButton", pbase.transform, new Vector2(0, 0), new Vector2(100, 20), "Check", 14, Color.white, "button", delegate { Destroy(GameObject.Find("LoginNull")); });
    }
}
