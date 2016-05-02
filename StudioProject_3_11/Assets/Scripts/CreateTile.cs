using UnityEngine;
using System.Collections;
using System.Collections.Generic;
[System.Serializable]
public class CreateTile : MonoBehaviour {
    //GameObject[,] tileArray = new GameObject[20,15];
    static int guiLayer = 5;
    public Material tileM;
    public Material tileE;
    UICreator uic;
    MyCard card;
    List<GameObject> tileHasObject;
    void Update() {
    }
    public void create()
    {
        tileHasObject = new List<GameObject>();
        int tileNumber = 0;
        int tileEdgeN = 0;
        uic = new UICreator(5);
        // GameObject.FindObjectOfType<Canvas>().gameObject.transform 畫布的Transform
        // GameObject.Find("名字").gameObject.transform 依據名字尋找物件
       
        GameObject tiles = new GameObject("Tiles");
        GameObject tileEdges = new GameObject("TileEdges");

        
        for (int i = 0; i < 20; i++)
        {
            for (int j = 0; j < 15; j++)
            {
                uic.createTile("Tile" + tileNumber, GameObject.Find("Tiles").gameObject.transform, -7 + j, -1.7f + i, 8, tileM).AddComponent<ForTile>();
                tileNumber++;
            }
        }
        for (int i = 0; i < 20; i++)
        {
            for (int j = 0; j < 15; j++)
            {
                uic.createTile("TileEdge" + tileEdgeN, GameObject.Find("TileEdges").gameObject.transform, -7 + j, -1.7f + i, 9, tileE);
                tileEdgeN++;
            }
        }
        MyCard m = new MyCard();
        GameProcessControll Gprocess = GameObject.Find("GameController").GetComponent<GameProcessControll>();
        Gprocess.mcard = m;
        Gprocess.ViewUI = uic;
        Gprocess.initial();
    }
    public void addHasCardOnTile(GameObject g){
        tileHasObject.Add(g);
        Debug.Log("added!!" + g.gameObject.name);
    }
    public GameObject getCardOnTile(int index) {
        return tileHasObject[index];
    }
    public int howManyCardsOnTile()
    {
        return tileHasObject.Count;
    }
}
