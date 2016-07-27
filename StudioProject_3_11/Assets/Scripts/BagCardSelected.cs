using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BagCardSelected : MonoBehaviour {
    GameObject controller;
    Image img;
    bool state;
	// Use this for initialization
	void Start () {
        controller = GameObject.Find("GameController");
        img = this.gameObject.GetComponent<Image>();
        state = false;
        Button cardb = this.gameObject.AddComponent<Button>();
        cardb.onClick.AddListener(delegate { this.changeSelectState(); });
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void changeSelectState() {
        if (state)
        {
            state = false;
            img.color = new Color(255, 255, 255);
        }
        else
        {
            state = true;
            img.color = new Color(255, 0, 0);
        }
    }
}
