using UnityEngine;
using System.Collections;
using System;

public class TeachModel : MonoBehaviour, ShowWebInfo
{
    UICreator uic;
    GameObject pbase,viewBase;
    private Account acct;
	// Use this for initialization
	void Start () {
        uic = new UICreator(5);
        viewBase = GameObject.Find("RegularCanvas");
        acct = Account.getAccountInstance;
        pbase = uic.createPanel("teachModel", viewBase.transform, 750, 200, 0, 0, "MessageBox");
        uic.createText("text", pbase.transform, -30, 50, 500, 50, "教學 請點擊劇情模式", 20, Color.green);
        uic.createButton("checkButton", pbase.transform, new Vector2(0, 0), new Vector2(100, 20), "Check", 14, Color.white, "button", delegate { Destroy(GameObject.Find("teachModel")); });
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    public void teacherSuccess() {
        viewBase = GameObject.Find("RegularCanvas");
        pbase = uic.createPanel("teachModel", viewBase.transform, 750, 200, 0, 0, "MessageBox");
        uic.createText("text", pbase.transform, -30, 50, 500, 50, "教學完成", 20, Color.green);
        uic.createButton("checkButton", pbase.transform, new Vector2(0, 0), new Vector2(100, 20), "Check", 14, Color.white, "button", delegate { Destroy(GameObject.Find("teachModel")); });
        acct.updateAccountLevel();
    }

    public void show(string info)
    {
        acct.accountCard = info.Split(' ')[0];
        this.GetComponent<ShowMainPage>().downLoadCardData();
        teacherSuccess();
        this.GetComponent<ShowMainPage>().AccountLevel.text = acct.accountLevel;
        this.GetComponent<ShowMainPage>().openBagLock();
        this.GetComponent<ShowMainPage>().upDateLevel();
    }
}
