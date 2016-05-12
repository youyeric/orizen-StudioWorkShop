using UnityEngine;
using System.Collections;

public class ForTile : MonoBehaviour {
    Renderer rend;
    Color normalColor;
    string cardName;
    Material orgMaterial;
    public bool isUsed = false;
    GameObject gameController;
    GameObject[] onTileCards = null;
    
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
        //CardData cd = this.gameObject.AddComponent<CardData>();
        //cd.cm = temp;
        //rend.material = m;
        gameController.GetComponent<CreateTile>().addHasCardOnTile(temp, this.gameObject);
        Destroy(card);
        Destroy(gameController.GetComponent<TileMouseOver>());
       
    }
    public void setCardOnMove(GameObject card)
    {
        GameObject preTile = GameObject.Find("Tile"+ card.GetComponent<CardMove>().location.ToString());
        //CardModel temp = card.GetComponent<CardData>().cm;
        preTile.GetComponent<ForTile>().isUsed = false;
        this.isUsed = true;
        Transform cardtr = card.transform;
        cardtr.position = new Vector3(this.gameObject.transform.position.x,this.gameObject.transform.position.y,7);

        //CardData cd = this.gameObject.AddComponent<CardData>();
        //cd.cm = temp;
        //card.GetComponent<Renderer>().material = orgMaterial;
        Destroy(card.GetComponent<CardMove>());
        //Destroy(card.GetComponent<CardData>());
        if (onTileCards == null)
            onTileCards = GameObject.FindGameObjectsWithTag("OnTileCard");
        foreach (GameObject go in onTileCards)
            go.GetComponent<Effect>().enabled = true;

    }
    public void setHighLightColor()
    {
        if(GetComponent<Renderer>().material.name.Substring(0,4) == orgMaterial.name.Substring(0,4))
        {
            rend.material.color = new Color(1, 1, 1, 0.3f);
        }
    }
    public void setNormalColor()
    {
        if(GetComponent<Renderer>().material.name.Substring(0, 4) == orgMaterial.name.Substring(0, 4))
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
