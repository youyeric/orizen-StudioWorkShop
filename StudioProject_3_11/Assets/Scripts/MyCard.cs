using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;




public class MyCard {
   //暫存牌庫
    public List<string[]> yourCard;
    private string CardDataPathBase;
    private StreamReader SR;
    private StreamWriter SW;
    private System.Random r;
    public string PathBase;
    private int i;
    private string webUrl;
    public MyCard()
    {
        r = new System.Random();
        this.i = 0;
        yourCard = new List<string[]>();
        this.PathBase = Path.Combine(System.Environment.CurrentDirectory, "CardData");
        //this.PathBase = Application.persistentDataPath;
        this.webUrl = "http://studiogame-orizen.rhcloud.com/";
    }
    public void loadCard(string path) {
        //Path.Combine(PathBase, path)
        string str;
        SR = new StreamReader(Path.Combine(PathBase, path));
        Debug.Log(Path.Combine(PathBase, path));
        str = SR.ReadLine();
        while (str != null)
        {
       
            var data = str.Split(',');
            yourCard.Add(data);
            //this.addCard(data, int.Parse(data[9]));
            str = SR.ReadLine();
           
        }
        SR.Close();
    }
	public string[] getCard(int quantity)
    {
        string[] temp = yourCard[quantity];
        yourCard.RemoveAt(quantity);
        return temp;
    }
    public int getCardQuantity() {
        return yourCard.Count;
    }
    //複寫是false不復寫是true
    public void saveCard(string path, string Data, bool writeState)
    {
        SW = new StreamWriter(Path.Combine(PathBase, path), writeState);
        SW.WriteLine(Data);
        SW.Close();
    }
    public IEnumerator catchWebData(string url) {
        WWW web = new WWW(webUrl + url);
        yield return web;
        Debug.Log("Download OK!!");
    }

    public bool isFileExist(string path) {
        return File.Exists(Path.Combine(PathBase, path));
    }
    public void writeJS(GameObject g, string path)
    {
        for (int i = 0; i < yourCard.Count; i++)
        {
            string data = null;
            for (int j = 0; j < yourCard[i].Length; j++)
            {
                data += yourCard[i][j];
            }
            if (i == 0)
            {
                saveScript(path, data, FileMode.Create);
            }
            else
            {
                saveScript(path, data, FileMode.Append);
            }

            data = null;
        }
        // g.AddComponent<GetEffect>();
    }
    public void saveScript(string path, string Data, FileMode fm)
    {
        FileStream fs = new FileStream(System.Environment.CurrentDirectory + "/Assets/" + path, fm);
        byte[] data = System.Text.Encoding.Default.GetBytes(Data + "\r\n");
        fs.Write(data, 0, data.Length);
        fs.Flush();
        fs.Close();
        /*SW = new StreamWriter(System.Environment.CurrentDirectory + "/Assets/Scripts/" + path, writeState);
        SW.WriteLine(Data);
        SW.Close();*/
    }
    /* void startGetCard()
     {
         textobject = new GameObject("Text");
         textobject.transform.SetParent(parent.transform);
         textobject.layer = 5;
         RectTransform trans = textobject.AddComponent<RectTransform>();

     }*/
}
