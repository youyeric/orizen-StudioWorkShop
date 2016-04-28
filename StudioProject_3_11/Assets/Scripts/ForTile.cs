using UnityEngine;
using System.Collections;

public class ForTile : MonoBehaviour {
    Renderer rend;
    Color normalColor;
    string cardName;
    Material orgMaterial;
    public bool isUsed = false;
    GameObject gameController;
    void Start()
    {
        rend = GetComponent<Renderer>();
        normalColor = GetComponent<Renderer>().material.color;
        orgMaterial = GetComponent<Renderer>().material;
        gameController = GameObject.Find("GameController");
    }
    public void setCardOnTile(Material m, GameObject card)
    {
        CardModel temp = card.GetComponent<CardData>().cm;
        temp.state = "Ground";
        isUsed = true;
        CardData cd = this.gameObject.AddComponent<CardData>();
        cd.cm = temp;
        //rend.material = m;
        this.gameObject.AddComponent<CardMove>();
        Destroy(card);
        Destroy(gameController.GetComponent<TileMouseOver>());
    }
    public void setCardOnMove()
    {

    }
    public void setHighLightColor()
    {
        if(GetComponent<Renderer>().material.name == orgMaterial.name)
        {
            rend.material.color = new Color(1, 1, 1, 0.3f);
        }
    }
    public void setNormalColor()
    {
        if(GetComponent<Renderer>().material.name == orgMaterial.name)
        {
            rend.material.color = normalColor;
        }
    }
    public void setCardName(string cardName)
    {
        this.cardName = cardName;
    }
    public void cardExitTile()
    {
        rend.material = orgMaterial;
    }
}
