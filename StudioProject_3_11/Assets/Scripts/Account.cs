using UnityEngine;
using System.Collections;
using System;

public class Account : MonoBehaviour{
    public string accountID;
    public string accountPassword;
    public string accountLevel;
    public string accountCard;
    private static Account yourAccount = new Account();
    private static MyCard dataHandle = new MyCard();
    /* Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}*/
    private Account() {

    }
    public static Account getAccountInstance {
        get {
            return yourAccount;
        }
    }
    public void setAccountId(string id) {
        this.accountID = id;
    }
    public void setAccountCardData(string data)
    {
        this.accountCard = data;
    }
    public void setAccountLevel(string level)
    {
        this.accountLevel = level;
    }
    public void updateAccountCard() {
        
    }
    public void updateAccountLevel() {
        int temp = Int32.Parse(this.accountLevel) + 1;
        this.accountLevel = temp.ToString();
         
        dataHandle.saveCard("account.txt",this.accountID+","+this.accountPassword+","+this.accountLevel, false);
        Debug.Log("UpdateData.php?tname=Accounts&cname=AccountLevel&data=" + accountLevel + "&conditionT=Account_Name&conditionV=" + accountID);
        //UpdateToWeb();
    }
    void UpdateToWeb(){
        StartCoroutine(dataHandle.pushWebData("UpdateData.php?tname=Accounts&cname=AccountLevel&data=" + accountLevel + "&conditionT=Account_Name&conditionV=" + accountID));
    }

}
