using UnityEngine;
using System.Collections;

public class CardMove : MonoBehaviour {
    private CardModel cm;
    public int speed;
    public string tile;
    public int location;
    GameObject gameController;
    public int[] position;
    // Use this for initialization
    void Start () {
        cm = this.gameObject.GetComponent<CardData>().cm;
        this.speed = System.Int32.Parse(cm.cardSpeed);
        position = new int[speed * 4];
       tile = this.gameObject.name;
        location = System.Int32.Parse(this.gameObject.name.Split('/')[1]);
        gameController = GameObject.Find("GameController");
    }
	
	// Update is called once per frame
	/*void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                GameObject focusObj = hit.transform.gameObject;
                if (focusObj.name.Equals(tile))
                {
                    Debug.Log(tile);
                    moveInfo();
                }
                
            }

        }
    }*/
    public void moveInfo()
    {      
        for(int i = 1; i<= position.Length/4; i++)
        {
            setMove(location + i, location - i, location + i*9, location - i*9, i - 1);
        }
        TileMouseOver TMO = gameController.GetComponent<TileMouseOver>();
        TMO.tags = "GameController";
        TMO.resetHighLightColor();
        TMO.setCardName(this.gameObject.name, null);
        TMO.setTileToHighLightColor(position);
    }
    void setMove(int east, int west, int south, int north, int index)
    {
        if(east/9 == location/9){
            position[index * 4] = east;
        }
        else{
            position[index * 4] = -1;
        }
        if(west/9 == location/9){
            position[index * 4 + 1] = west;
        }
        else{
            position[index * 4 + 1] = -1;
        }
        if((north >= 0) && (north <= 126)){
            position[index * 4 + 2] = north;
        }
        else{
            position[index * 4 + 2] = -1;
        }
        if((south >= 0) && (south <= 126)){
            position[index * 4 + 3] = south;
        }
        else{
            position[index * 4 + 3] = -1;
        }
    }
}
