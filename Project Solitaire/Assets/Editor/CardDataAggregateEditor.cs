using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(CardDataAggregate))]
public class CardDataAggregateEditor : Editor
{
    float labelWidth = 120f;
    float buttonWidth = 30f;
    bool foldout = false;

    private GUIContent
        addManaCostButton = new GUIContent("+", "Add mana cost"),
        removeManaCost = new GUIContent("-", "Remove mana cost");

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        serializedObject.FindProperty("cardName").stringValue = EditorGUILayout.TextField("Card name", serializedObject.FindProperty("cardName").stringValue);

        GUILayout.BeginHorizontal();
        GUILayout.Label("Card Image", GUILayout.Width(labelWidth));
        serializedObject.FindProperty("cardImage").objectReferenceValue = (Sprite)EditorGUILayout.ObjectField
            (serializedObject.FindProperty("cardImage").objectReferenceValue,
            typeof(Sprite),
            allowSceneObjects: false);
        GUILayout.EndHorizontal();

        GUILayout.Label("Card Types");
        GUILayout.BeginHorizontal();
        serializedObject.FindProperty("cardTypes").GetArrayElementAtIndex(0).stringValue = EditorGUILayout.TextField(serializedObject.FindProperty("cardTypes").GetArrayElementAtIndex(0).stringValue);
        serializedObject.FindProperty("cardTypes").GetArrayElementAtIndex(1).stringValue = EditorGUILayout.TextField(serializedObject.FindProperty("cardTypes").GetArrayElementAtIndex(1).stringValue);
        GUILayout.Label("-");
        serializedObject.FindProperty("cardTypes").GetArrayElementAtIndex(2).stringValue = EditorGUILayout.TextField(serializedObject.FindProperty("cardTypes").GetArrayElementAtIndex(2).stringValue);
        GUILayout.EndHorizontal();

        CardCostType costType = (CardCostType)serializedObject.FindProperty("costType").objectReferenceValue;
        if (costType != null)
        {
            if (costType is CardCost_Mana manaContainer)
            {
                ManaValueDictionary manaCost = manaContainer.values;

                CustomGUILayout.ManaValueDictionaryField("Mana cost", manaCost);
            }            
        }

        if (serializedObject.FindProperty("isAttackerDefender").boolValue)
        {
            GUILayout.BeginHorizontal();
            GUILayout.Label("Atk/Def");
            serializedObject.FindProperty("atk").intValue = EditorGUILayout.IntField(serializedObject.FindProperty("atk").intValue);
            serializedObject.FindProperty("def").intValue = EditorGUILayout.IntField(serializedObject.FindProperty("def").intValue);
            GUILayout.EndHorizontal();
        }

        serializedObject.ApplyModifiedProperties();
    }
}
