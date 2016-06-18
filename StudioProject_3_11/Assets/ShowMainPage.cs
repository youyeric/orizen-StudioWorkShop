using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShowMainPage : MonoBehaviour {
    public Text AccountId;
    private Account acct;
	// Use this for initialization
	void Start () {
        acct = Account.getAccountInstance;
        AccountId.text = acct.accountID;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
