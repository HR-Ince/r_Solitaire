using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(CardData_CostBased))]
public class CardData_CostBasedEditor : Editor
{
    float labelWidth = 120f;

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

        EditorManaDictionary.Serialize(
            serializedObject.FindProperty("costTypes"), 
            serializedObject.FindProperty("costAmounts"),
            "Mana Cost");

        serializedObject.ApplyModifiedProperties();
    }
}
