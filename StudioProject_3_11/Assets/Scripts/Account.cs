using UnityEngine;
using System.Collections;



public class Account : MonoBehaviour{
    public string accountID;
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
    public void updateAccountCard() {
        
    }
    public void updateAccountLevel() {
       StartCoroutine(dataHandle.catchWebData(null, "UpdateData.php?data =" + accountLevel));
    }

}
