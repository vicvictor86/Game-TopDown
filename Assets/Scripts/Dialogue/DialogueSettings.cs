﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "New Dialogue", menuName = "New Dialogue/Dialogue")]
public class DialogueSettings : ScriptableObject
{
    [Header("Settings")]
    public GameObject actor;

    [Header("Dialogue")] 
    public Sprite speakerSprite;
    public string sentece;

    public List<Sentences> dialogues = new List<Sentences>();
}

[System.Serializable]
public class Sentences
{
    public string actorName;
    public Sprite profile;
    public Languages sentece;
}

[System.Serializable]
public class Languages
{
    public string portuguese;
    public string english;
    public string spanish;
}

#if UNITY_EDITOR
[CustomEditor(typeof(DialogueSettings))]
public class BuilderEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        DialogueSettings ds = (DialogueSettings) target;

        Languages l = new Languages();
        l.portuguese = ds.sentece;

        Sentences s = new Sentences();
        s.profile = ds.speakerSprite;
        s.sentece = l;

        if (GUILayout.Button("Create Dialogue"))
        {
            if (ds.sentece != "")
            {
                ds.dialogues.Add(s);

                ds.speakerSprite = null;
                ds.sentece = "";
            }
        }
    }
}


#endif
