using UnityEngine;
using System.Collections;
[System.Serializable]
//這個是用來捕捉可以放置的tile
public class TileMouseOver : MonoBehaviour {
    string cardName;
    Material m;
    private GameObject focusObj;
    GameObject tiles;
    void Update () {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
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
        }
    }
    public void setCardName(string cn, Material m)
    {
        cardName = cn;
        this.m = m;
    }
    public void setTileToHighLightColor()
    {
        for (int i = 0; i < 15; i++)
        {
            tiles = GameObject.Find("Tile" + i);
            tiles.tag = "Tile";
            tiles.GetComponent<ForTile>().setHighLightColor();
            tiles.GetComponent<ForTile>().setCardName(cardName);
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
}
