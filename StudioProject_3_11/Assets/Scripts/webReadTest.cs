using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class webReadTest : MonoBehaviour {
    LoadScene ls;
    // Use this for initialization
    
	void Start () {
         
        MyCard cd = new MyCard();
        //StartCoroutine(cd.catchWebData("selectCard.php"));
         MyCard javascriptwriteTest = new MyCard();
         javascriptwriteTest.loadCard("getEffec.txt");
         //javascriptwriteTest.writeJS(this.gameObject,"GetEffect.cs");

    }
	
	// Update is called once per frame
	void Update () {
        
    }
    public WWW POST(string url, Dictionary<string, string> post)
    {
        WWWForm form = new WWWForm();
        foreach (KeyValuePair<string, string> post_arg in post)
        {
            form.AddField(post_arg.Key, post_arg.Value);
        }
        WWW www = new WWW(url, form);

        StartCoroutine(WaitForRequest(www));
        return www;
    }
    public IEnumerator WaitForRequest(WWW www)
    {
        yield return www;

        // check for errors
        if (www.error == null)
        {
            Debug.Log("WWW Ok!: " + www.text);
        }
        else
        {
            Debug.Log("WWW Error: " + www.error);
        }
    }
}
