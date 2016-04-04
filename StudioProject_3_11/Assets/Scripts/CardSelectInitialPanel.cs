using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;


public class CardSelectInitialPanel : MonoBehaviour {
    public GameObject panelSelect;
    private GameProcessControll Gprocess;
    
	// Use this for initialization
	void Start () {
       
    }
	
	// Update is called once per frame
	void Update () {
       
    }
    public void selectCardOne(GameObject eventButton)
    {
        panelSelect.SetActive(false);
      
    }
}