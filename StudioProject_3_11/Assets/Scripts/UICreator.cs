using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class UICreator
{
    int guiLayer = 5;
    public UICreator(int setLayer)
    {
        guiLayer = setLayer;
    }
    public GameObject createCanvas(string CanvasName,Transform tr, int RRY)
    {
        GameObject canvasObject = new GameObject(CanvasName);
        canvasObject.layer = guiLayer;

        RectTransform canvasRectTran = canvasObject.AddComponent<RectTransform>();

        Canvas canvas = canvasObject.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvas.pixelPerfect = true;

        CanvasScaler canvasScale = canvasObject.AddComponent<CanvasScaler>();
        canvasScale.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
        canvasScale.screenMatchMode = CanvasScaler.ScreenMatchMode.MatchWidthOrHeight;
        canvasScale.referenceResolution = new Vector2(800, RRY);

        canvasObject.AddComponent<GraphicRaycaster>();

        canvasObject.transform.SetParent(tr);

        canvasObject.AddComponent<UI>();

        return canvasObject;
    }
    public GameObject createPanel(string panelObjectName,Transform tf, float width, float height, float pX, float pY, string imgName)
    {
        GameObject panelObject = new GameObject(panelObjectName);
        panelObject.transform.SetParent(tf);

        panelObject.layer = 5;

        RectTransform panelRectTran = panelObject.AddComponent<RectTransform>();
        panelRectTran.anchorMin = new Vector2(0.5f, 0.5f);
        panelRectTran.anchorMax = new Vector2(0.5f, 0.5f);
        panelRectTran.pivot = new Vector2(0.5f, 0.5f);
        //panelRectTran.anchoredPosition3D = new Vector3(0, 0, 0);
        panelRectTran.anchoredPosition = new Vector2(pX, pY);//同anchoredPosition3D
        //panelRectTran.offsetMin = new Vector2(0, 0);//意義不明
        //panelRectTran.offsetMax = new Vector2(0, 0);//意義不明
        //panelRectTran.localPosition = new Vector3(100, 100, 0);//同anchoredPosition3D
        panelRectTran.sizeDelta = new Vector2(width, height);//Rect Transform: Width, Height
        panelRectTran.localScale = new Vector3(1, 1, 1);

        CanvasRenderer renderer = panelObject.AddComponent<CanvasRenderer>();

        Image image = panelObject.AddComponent<Image>();
        Texture2D tex = Resources.Load<Texture2D>(imgName);
        image.sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0.5f, 0.5f));

        return panelObject;
    }
    public GameObject createText(string textObjectName,Transform tr, float x, float y,float width, float height, string message, int fontSize, Color fontC)
    {
        GameObject textObject = new GameObject(textObjectName);
        textObject.transform.SetParent(tr);

        textObject.layer = 5;

        RectTransform textTranRect = textObject.AddComponent<RectTransform>();
        textTranRect.anchorMin = new Vector2(0.5f, 0.5f);
        textTranRect.anchorMax = new Vector2(0.5f, 0.5f);
        textTranRect.pivot = new Vector2(0.5f, 0.5f);
        //textTranRect.sizeDelta.Set(w, h);
        textTranRect.sizeDelta = new Vector2(width, height);
        //textTranRect.anchoredPosition3D = new Vector3(0, 0, 0);
        //set anchored position
        textTranRect.anchoredPosition = new Vector2(x, y);//無法作用
        textTranRect.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        //textTranRect.localPosition.Set(0, 0, 0);

        CanvasRenderer rederer = textObject.AddComponent<CanvasRenderer>();

        Text text = textObject.AddComponent<Text>();
        text.supportRichText = true;
        text.text = message;//input your text
        text.fontSize = fontSize;
        text.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
        text.alignment = TextAnchor.MiddleCenter;
        text.horizontalOverflow = HorizontalWrapMode.Wrap;
        text.color = fontC;


        return textObject;
    }
    public GameObject createButton(string buttonObjectName,Transform tr, Vector2 position, Vector2 size, string message, int fontS, Color fontC, string imgName, UnityAction eventListner)
    {
        GameObject buttonObject = new GameObject(buttonObjectName);
        buttonObject.transform.SetParent(tr);

        buttonObject.layer = 5;

        RectTransform buttonTranRect = buttonObject.AddComponent<RectTransform>();
        SetSize(buttonTranRect, size);
        //buttonTranRect.anchoredPosition3D = new Vector3(0, 0, 0);
        buttonTranRect.anchoredPosition = position;
        buttonTranRect.anchorMin = new Vector2(0.5f, 0.5f);
        buttonTranRect.anchorMax = new Vector2(0.5f, 0.5f);
        buttonTranRect.pivot = new Vector2(0.5f, 0.5f);
        buttonTranRect.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        //buttonTranRect.localPosition.Set(0, 0, 0);

        CanvasRenderer renderer = buttonObject.AddComponent<CanvasRenderer>();

        Image image = buttonObject.AddComponent<Image>();
        Texture2D tex = Resources.Load<Texture2D>(imgName);
        image.sprite = Sprite.Create(tex, new Rect(0,0,tex.width, tex.height), new Vector2(0.5f, 0.5f));

        GameObject textObject = createText(buttonObjectName+"Text",buttonObject.transform, 0, 0, size.x, size.y, message, fontS, fontC);

        Button btn = buttonObject.AddComponent<Button>();
        btn.onClick.AddListener(eventListner);

        return buttonObject;
    }
    private static void SetSize(RectTransform trans, Vector2 size)
    {
        Vector2 currSize = trans.rect.size;
        Vector2 sizeDiff = size - currSize;
        trans.offsetMin = trans.offsetMin - new Vector2(sizeDiff.x * trans.pivot.x, sizeDiff.y * trans.pivot.y);
        trans.offsetMax = trans.offsetMax + new Vector2(sizeDiff.x * (1.0f - trans.pivot.x), sizeDiff.y * (1.0f - trans.pivot.y));
    }
    public GameObject createImage(string imageObjectName,Transform tr,Vector2 size , Vector2 position, string path)
    {
        GameObject imageObject = new GameObject(imageObjectName);
        imageObject.transform.SetParent(tr);

        RectTransform imageTranRect = imageObject.AddComponent<RectTransform>();
        imageTranRect.anchorMin = new Vector2(0.5f, 0.5f);
        imageTranRect.anchorMax = new Vector2(0.5f, 0.5f);
        imageTranRect.pivot = new Vector2(0.5f, 0.5f);
        imageTranRect.sizeDelta = size;
        //imageTranRect.anchoredPosition3D = new Vector3(0, 0, 0);
        imageTranRect.anchoredPosition = position;
        imageTranRect.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        //imageTranRect.localPosition.Set(0, 0, 0);

        CanvasRenderer rederer = imageObject.AddComponent<CanvasRenderer>();

        Image image = imageObject.AddComponent<Image>();
        Texture2D tex = Resources.Load<Texture2D>(path);
        image.sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0.5f, 0.5f));

        return imageObject;
    }
    //(卡名、父物件、大小、位置、Materials路徑、卡片資訊)
    public GameObject createCardGUI(string name, Transform tr, Vector2 size, Vector2 position, string path, string[] cardinfo)
    {
        GameObject card = new GameObject(name);
        card.tag = "Card";
        card.transform.SetParent(tr);

        RectTransform cardScope = card.AddComponent<RectTransform>();
        cardScope.anchorMin = new Vector2(0.5f, 0.5f);
        cardScope.anchorMax = new Vector2(0.5f, 0.5f);
        cardScope.pivot = new Vector2(0, 0.5f);
        cardScope.sizeDelta = size;
        cardScope.anchoredPosition = position;
        cardScope.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        CanvasRenderer rederer = card.AddComponent<CanvasRenderer>();

        Image image = card.AddComponent<Image>();

        CardData cd = card.AddComponent<CardData>();
        cd.cm = new CardModel(cardinfo);
        cd.ui = this;
        
        CardSelected cdsel = card.AddComponent<CardSelected>();
        

        Button btn = card.AddComponent<Button>();
        btn.onClick.AddListener(delegate { cdsel.selected(); });
        return card;
    }

    /*private GameObject createEventSystem(Transform tr)
    {
        GameObject evenObj = new GameObject("EventSystem");
        EventSystem evenClass = evenObj.AddComponent<EventSystem>();
        evenClass.sendNavigationEvents = true;
        evenClass.pixelDragThreshold = 5;

        StandaloneInputModule stdInput = evenObj.AddComponent<StandaloneInputModule>();
        stdInput.horizontalAxis = "Horizontal";
        stdInput.verticalAxis = "Vertical";
        TouchInputModule touchInput = evenObj.AddComponent<TouchInputModule>();

        evenObj.transform.SetParent(tr);

        return evenObj;
    }*/
    public GameObject createTile(string tileName,Transform tf, float x, float y, float z, Material myM) {
        GameObject tQuad = GameObject.CreatePrimitive(PrimitiveType.Quad);
        tQuad.name = tileName;
        tQuad.transform.SetParent(tf);
        tQuad.transform.position = new Vector3(x, y, z);
        tQuad.transform.rotation = Quaternion.Euler(0, 0, 0);
        //加入script
        //var TMO = tQuad.AddComponent<TileMouseOver>();
        Renderer rend = tQuad.GetComponent<Renderer>();
        rend.material = myM;
        return tQuad;
    }
}
