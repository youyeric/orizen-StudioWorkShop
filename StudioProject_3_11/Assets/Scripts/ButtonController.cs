using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour {

    public GameObject button1;
    
    public Button[] button;
    
    
    private ArrayList card_arr;
    public Text cardNum;
    private int cardTol = 60;
    
	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    public void gameStartClick(GameObject button)
    {

        Debug.Log("GameObject " + button.name);
        /* card_arr = new ArrayList();
         for(int index = 0; index < 5; index++)
         {
             card_arr.Add("a");
             cardTol--;
         }
         cardNum.text = cardTol.ToString();*/

        //連接資料庫
        //倒入排組陣列
        //抽五張牌
    }
}
