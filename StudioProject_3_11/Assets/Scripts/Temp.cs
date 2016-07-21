using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Temp : MonoBehaviour
{
    public string objectName;
    public int index;
    public GameObject controller;
    void Start()
    {
        controller = GameObject.Find("GameController");
        this.GetComponent<Button>().onClick.AddListener(delegate { this.destroyParents(); } );
    }

    public void destroyParents()
    {
        Debug.Log(objectName);
        controller.GetComponent<DeckList>().cardAlbum.removeCardAlbum(objectName);
        Destroy(GameObject.Find(objectName).gameObject);
        controller.GetComponent<DeckList>().deckList.yourCard.RemoveAt(index);
        controller.GetComponent<DeckList>().deckList.restoreData("addDeckToList.csv");
        
        controller.GetComponent<LoadScene>().enterBagScene();
        //GameObject.Find("GameController").GetComponent<DeckList>().reLoadScene();      
    }
}
