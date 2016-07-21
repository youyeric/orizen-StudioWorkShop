using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class EditCardAlbum : MonoBehaviour {
    public string albumName;
    public Button editButton;
    public GameObject controller;
	// Use this for initialization
	void Start () {
        controller = GameObject.Find("GameController");
        editButton = this.GetComponent<Button>();
        editButton.onClick.AddListener(delegate { this.enterEditView(); });
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void enterEditView() {
        controller.GetComponent<DeckList>().editCardAlbumView(albumName);
    }
    
}
