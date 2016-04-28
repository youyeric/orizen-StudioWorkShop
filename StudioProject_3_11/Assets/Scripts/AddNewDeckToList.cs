using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public class AddNewDeckToList : MonoBehaviour {
    public InputField inputField;
    string deckName;
    MyCard mc;
    Regex regex = new Regex("^[\u4e00-\u9fa5_a-zA-Z0-9]+$");
    public GameObject MessageBox;
    void Start () {
        mc = new MyCard();
	}
	public void setDeckName()
    {
        deckName = inputField.text;
    }
    public void addDeckToList()
    {
        StreamReader sr = new StreamReader(Path.Combine(Path.Combine(System.Environment.CurrentDirectory, "CardData"), "addDeckToList.csv"));
        List<string> data = new List<string>();
        if (!regex.IsMatch(deckName))
        {
            MessageBox.SetActive(true);
            return;
        }
               
        while (sr.Peek() >0)
        {
            data.Add(sr.ReadLine());
        }
        var count = data.Where((x) => x.Equals(deckName)).Count();
        sr.Close();
        
        if (count == 0)
        {
            mc.saveCard("addDeckToList.csv", deckName, true);
        }
        else
        {
            MessageBox.SetActive(true);
            return;
        }
        this.GetComponent<LoadScene>().enterBagScene();
    }
}

