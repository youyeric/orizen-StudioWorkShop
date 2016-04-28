using UnityEngine;
using System.Collections;

public class Temp : MonoBehaviour
{
    public string objectName;
    public int index;
    public void destroyParents()
    {
        Destroy(GameObject.Find(objectName).gameObject);
        GameObject.Find("GameController").GetComponent<DeckList>().deckList.yourCard.RemoveAt(index);
        GameObject.Find("GameController").GetComponent<DeckList>().reLoadScene();
    }
}
