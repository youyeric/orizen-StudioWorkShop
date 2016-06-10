using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Account : MonoBehaviour {
    public string accountID;
    public string accountName;
    public Button checkButton;
    public Text ID, Password;
    private MyCard cd;
    private webReadTest webPost;
	// Use this for initialization
	void Start () {
        cd = new MyCard();
        if (cd.isFileExist("account.txt"))
        {
            cd.loadCard("account.txt");
            accountID = cd.getCard(0)[0];
            accountName = cd.getCard(0)[1];
            //跳轉遊戲主畫面
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
        Debug.Log(ID.text + Password.text);
        //webPost.POST("Login.php?id="+ ID.text+"&passwd="+ Password.text,);
        cd.catchWebData("Login.php");

    }
}
