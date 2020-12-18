using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CustomGUILayout : Editor
{
    private static bool manaFoldout = false;
    private static float buttonWidth = 20f;

    private static GUIContent
        addManaCostButton = new GUIContent("+", "Add mana cost"),
        removeManaCostButton = new GUIContent("-", "Remove mana cost");

    public static void ManaValueDictionaryField(ManaValueDictionary dictionary)
    {
        ManaValueDictionaryField("Mana value dictionary", dictionary);
    }
    public static void ManaValueDictionaryField(string label, ManaValueDictionary dictionary)
    {
        manaFoldout = EditorGUILayout.BeginFoldoutHeaderGroup(manaFoldout, label);
        EditorGUILayout.EndFoldoutHeaderGroup();
        if (manaFoldout)
        {
            for (int i = 0; i < dictionary.Count; i++)
            {
                GUILayout.BeginHorizontal();
                dictionary.FirstValues[i] = (ManaType)EditorGUILayout.ObjectField(dictionary.FirstValues[i], typeof(ManaType), false);
                dictionary.SecondValues[i] = EditorGUILayout.IntField(dictionary.SecondValues[i]);
                GUILayout.EndHorizontal();
            }

            GUILayout.BeginHorizontal();
            if (GUILayout.Button(addManaCostButton, GUILayout.Width(buttonWidth)))
                dictionary.Add(null, 0);
            if (GUILayout.Button(removeManaCostButton, GUILayout.Width(buttonWidth)))
                dictionary.RemoveAt(dictionary.Count - 1);
            GUILayout.EndHorizontal();
        }
    }
}
