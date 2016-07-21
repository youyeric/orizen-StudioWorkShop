using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SwitchListContent : MonoBehaviour {
    Button imgButton;
    GameObject controller;
	// Use this for initialization
	void Start () {
        imgButton = this.gameObject.AddComponent<Button>();
        controller = GameObject.Find("GameController");
        imgButton.onClick.AddListener(delegate { controller.GetComponent<DeckList>().switchListContent(this.gameObject); });
    }
	
	// Update is called once per frame
	void Update () {
	}
}
