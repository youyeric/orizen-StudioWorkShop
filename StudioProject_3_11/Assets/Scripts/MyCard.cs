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
    public IEnumerator catchWebData(ShowWebInfo obj,string url) {
        WWW web = new WWW(webUrl + url);
        yield return web;
        Debug.Log("Download OK!!"+ webUrl + url + web.text);
        if (!obj.Equals(null)) { obj.show(web.text); }
        
    }
    public IEnumerator pushWebData(string url)
    {
        WWW web = new WWW(webUrl + url);
        yield return web;
        Debug.Log("Download OK!!" + webUrl + url + web.text);
    }
    public bool isFileExist(string path) {
        return File.Exists(Path.Combine(PathBase, path));
    }
  /*  public void writeJS(GameObject g, string path)
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
    }*/
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
    public int cardIndex(int index , string tag) {
        int i = 0;
        while(i < yourCard.Count&& !yourCard[i][index].Equals(tag))
        {
            i++;
        }
        return i;
    }
    public List<string[]> cardSelectByAlbum(string album) {
        List<string[]> temp = new List<string[]>();
        
        foreach (string[] data in yourCard) {
            var albums = data[11].Split('|');
            foreach (string al in albums) {
                if (al.Equals(album))
                {
                    Debug.Log("add" + album);
                    temp.Add(data);
                }
            }
        }
        return temp;
    }
    public List<string[]> cardSelectByAlbumRemain(string album) {
        List<string[]> temp = new List<string[]>();

        foreach (string[] data in yourCard)
        {
            var albums = data[11].Split('|');
            int i = 0;
            foreach (string al in albums)
            {
                if (al.Equals(album)) {
                    i++;
                }
            }
            if (i == 0) {
                temp.Add(data);
            }
        }
        return temp;
    }
    public void restoreData(string path) {
        string temp = "";
        for(int i = 0; i < this.yourCard.Count; i++)
        {
            foreach (string data in yourCard[i]) {
                temp = temp + data + ",";
            }
            this.saveCard(path, temp, (i>0)?true:false);
            temp = "";
        }
    }
    public void addCardAlbum(string card, string album) {
        List<string[]> tempdata = this.cardSelectByAlbum(card);
        List<string> savedata = new List<string>();
        for (int i = 0; i < tempdata.Count; i++)
        {
            var albums = tempdata[i][11].Split('|');
            int j = 0;
            foreach (string al in albums) {
                if (al.Equals(album))
                {
                    j++;
                }
            }
            if(j == 0)
            {
                savedata.Add(yourCard[i][0] + "," + yourCard[i][1] + "," + yourCard[i][2] + "," + yourCard[i][3] + "," + yourCard[i][4] + "," + yourCard[i][5] + "," + yourCard[i][6] + "," + yourCard[i][7] + "," + yourCard[i][8] + "," + yourCard[i][9] + "," + yourCard[i][10] + ","+yourCard[i][11]+"|"+album);
            }
        }

        this.saveMultiData(savedata, "bag.csv");
    }
    public void removeCardAlbum(string album) {
        string temp = "";
        List<string> tempdata = new List<string>();
        Debug.Log(yourCard.Count);
        for (int i = 0; i < yourCard.Count;i++)
        {
            temp = yourCard[i][0] + "," + yourCard[i][1] + "," + yourCard[i][2] + "," + yourCard[i][3] + "," + yourCard[i][4] + "," + yourCard[i][5] + "," + yourCard[i][6] + "," + yourCard[i][7] + "," + yourCard[i][8] + "," + yourCard[i][9] + "," + yourCard[i][10] + ",";
            var albums = yourCard[i][11].Split('|');
            for(int j = 0; j < albums.Length; j++)
            {
                if (!albums[j].Equals(album))
                {
                    temp += "|"+albums[j];
                }
            }
            tempdata.Add(temp);
            Debug.Log(temp);
        }
        this.saveMultiData(tempdata,"bag.csv");
    }
    public void saveMultiData(List<string> data, string path) {
        for(int i = 0; i < data.Count; i++)
        {
            this.saveCard(path, data[i], (i > 0) ? true : false);
        }
    }
    public void saveAllCard(string path){
        string temp = "";
        for(int i = 0; i<yourCard.Count; i++)
        {
            temp = yourCard[i][0] + "," + yourCard[i][1] + "," + yourCard[i][2] + "," + yourCard[i][3] + "," + yourCard[i][4] + "," + yourCard[i][5] + "," + yourCard[i][6] + "," + yourCard[i][7] + "," + yourCard[i][8] + "," + yourCard[i][9] + "," + yourCard[i][10] + ","+yourCard[i][11];
            this.saveCard(path, temp, (i > 0) ? true : false);
        }
    }
    public List<string[]> cardSelectByBagId(string ids) {
        List<string[]> temp = new List<string[]>();
        var idss = ids.Split(',');
        foreach(string[] data in yourCard)
        {
            foreach (string id in idss)
            {
                if (data[0].Equals(id))
                {
                    temp.Add(data);
                }
            }            
        }
        return temp;
    }
    public void removeOneCardAlbumByBagId(string id, string album) {
        string temp="";
        for(int i = 0; i< yourCard.Count; i++)
        {
            if (yourCard[i][0].Equals(id))
            {
                var albums = yourCard[i][11].Split('|');
                foreach (string al in albums)
                {
                    if (!al.Equals(album))
                    {
                        temp += "|" + al;
                    }
                }
                yourCard[i][11] = temp;
                Debug.Log(yourCard[i][0] + " " + yourCard[i][11]);
            }
        }
    }
    public void addOneCardAlbumByBagId(string id, string album) {
        for (int i = 0; i < yourCard.Count; i++)
        {
            if (yourCard[i][0].Equals(id))
            {
                yourCard[i][11] += "|" + album;
                Debug.Log(yourCard[i][0] + " " + yourCard[i][11]);
            }
        }
    }
    /* void startGetCard()
     {
         textobject = new GameObject("Text");
         textobject.transform.SetParent(parent.transform);
         textobject.layer = 5;
         RectTransform trans = textobject.AddComponent<RectTransform>();

     }*/
}
