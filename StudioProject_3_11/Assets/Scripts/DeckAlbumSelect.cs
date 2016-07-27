using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class DeckAlbumSelect : MonoBehaviour {
    public string objectname;
    public GameObject controller;
	// Use this for initialization
	void Start () {
        controller = GameObject.Find("GameController");
        this.GetComponent<Button>().onClick.AddListener(delegate { this.selectAlbum(); });
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    public void selectAlbum() {
        DeckList dl = controller.GetComponent<DeckList>();
        dl.callDeckContent(GameObject.Find("DeckContentContent").gameObject.transform, objectname);
        dl.addCardSelectInterface();
    }
}
