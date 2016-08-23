﻿using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {

    public ContentData cd;
    public QuestData qd;

    // Use this for initialization
    void Awake () {
        cd = new ContentData(Application.dataPath + "/../../valkyrie-contentpacks/");
        foreach(string pack in cd.GetPacks())
        {
            cd.LoadContent(pack);
        }

        qd = new QuestData(Application.dataPath + "/../../valkyrie-quests/roag-intro/quest.ini", this);

    }

    void OnGUI()
    {
        //GUI.DrawTexture(new Rect(0, 0, 100, 100), d2e);
        //ih.drawGUI();
    }
	// Update is called once per frame
	void Update () {
        if (Input.GetKey("escape"))
           Application.Quit();
    }

    public void triggerEvent(string name)
    {
        QuestData.Event e = (QuestData.Event)qd.components[name];
        DialogWindow dw = new DialogWindow(e);
        foreach (string s in e.addComponents)
        {
            qd.components[s].setVisible(true);
        }

        if (e.location != null)
        {
            Camera cam = FindObjectOfType<Camera>();
            cam.transform.position = new Vector3(e.location.x * 105, e.location.y * 105, cam.transform.position.z);
        }
    }
}
