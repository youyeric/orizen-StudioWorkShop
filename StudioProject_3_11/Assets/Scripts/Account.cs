using UnityEngine;
using System.Collections;

public class Account : MonoBehaviour {
    public string accountID;
    public string accountName;
    private MyCard cd;
	// Use this for initialization
	void Start () {
        cd = new MyCard();
        if (cd.isFileExist("account.txt"))
        {
            cd.loadCard("account.txt");
            accountID = cd.getCard(0)[0];
            accountName = cd.getCard(0)[1];
        }
        else
        {
            //
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
