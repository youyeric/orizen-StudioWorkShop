using UnityEngine;
using System.Collections;
[System.Serializable]
//³o­Ó¬O¥Î¨Ó®·®»¥i¥H©ñ¸mªºtile
public class TileMouseOver : MonoBehaviour {
    string cardName;
    Material m;
    private GameObject focusObj;
    GameObject tiles;
    void Start(){
        setInnitailTile();
    }
    void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            focusObj = null;
            
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                focusObj = hit.transform.gameObject;
                if (focusObj.tag == "Tile" && !focusObj.GetComponent<ForTile>().isUsed)
                {
                    this.setTileToNormalColor();
                    focusObj.GetComponent<ForTile>().setCardOnTile(m, GameObject.Find(cardName));
                    GetComponent<LoadScene>().changeEventSystemStatus();
                }
                else if(focusObj.tag == "GameController" && !focusObj.GetComponent<ForTile>().isUsed)
                {
                        this.setTileToNormalColor();
                    focusObj.GetComponent<ForTile>().setCardOnMove(GameObject.Find(cardName));
                }
                else {
                        this.setTileToNormalColor();
                }
            }

        }
        /*if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            focusObj = null;
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                focusObj = hit.transform.gameObject;
                if (focusObj.tag == "Tile" && !focusObj.GetComponent<ForTile>().isUsed)
                {
                    this.setTileToNormalColor();
                    focusObj.GetComponent<ForTile>().setCardOnTile(m, GameObject.Find(cardName));
                    GetComponent<LoadScene>().changeEventSystemStatus();
                }
            }
        }*/
    }
    public void setCardName(string cn, Material m)
    {
        cardName = cn;
        this.m = m;
    }
    public void setTileToHighLightColor()
    {
        for (int i = 0; i < 300; i++)
        {
            tiles = GameObject.Find("Tile" + i);
            if(tiles.tag.Equals("Tile")){
               tiles.GetComponent<ForTile>().setHighLightColor();
                tiles.GetComponent<ForTile>().setCardName(cardName); 
            }
            
        }
    }
    public void setTileToHighLightColor(int[] t)
    {
        foreach(int i in t)
        {
             if(i >= 0)
                {
                    tiles = GameObject.Find("Tile" + i);
                    tiles.tag = "GameController";
                    tiles.GetComponent<ForTile>().setHighLightColor();
                }   
        }
    }
    public void setTileToNormalColor()
    {
        for (int i = 0; i < 15; i++)
        {
            tiles = GameObject.Find("Tile" + i);
            tiles.tag = "Tile";
            tiles.GetComponent<ForTile>().setNormalColor();
            tiles.GetComponent<ForTile>().setCardName(cardName);
        }
    }
    public void setInnitailTile(){
        for (int i = 0; i < 15; i++)
        {
            tiles = GameObject.Find("Tile" + i);
            tiles.tag = "Tile";
        }
    }
}
