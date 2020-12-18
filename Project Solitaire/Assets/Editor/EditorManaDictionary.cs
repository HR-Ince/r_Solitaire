using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EditorManaDictionary
{
    private static float buttonWidth = 20f;

    private static ManaType type = null;
    private static int amount = 0;

    private static GUIContent
        addButtonContent = new GUIContent("+", "Add"),
        deleteButtonContent = new GUIContent("-", "Delete");

    public static void ManaDictionaryField(string label, ManaValueDictionary dictionary)
    {
        if (dictionary == null)
            dictionary = new ManaValueDictionary();

        EditorGUILayout.LabelField(label);
        if(dictionary.Count > 0)
        {
            for(int i = 0; i < dictionary.Count; i++)
            {
                EditorGUI.indentLevel += 1;
                GUILayout.BeginHorizontal();
                dictionary.FirstValues[i] = (ManaType)EditorGUILayout.ObjectField(dictionary.FirstValues[i], typeof(ManaType), false);
                dictionary.SecondValues[i] = EditorGUILayout.IntField(dictionary.SecondValues[i]);
                GUILayout.EndHorizontal();
            }
        }

        GUILayout.BeginHorizontal();
        type = (ManaType)EditorGUILayout.ObjectField(type, typeof(ManaType), false);
        amount = EditorGUILayout.IntField(amount);
        GUILayout.EndHorizontal();

        ShowButtons(dictionary);
        
    }

    public static void Serialize(SerializedProperty list1, SerializedProperty list2, string name)
    {
        list2.arraySize = list1.arraySize;

        list1.isExpanded = EditorGUILayout.Foldout(list1.isExpanded, name);
        if (list1.isExpanded)
        {
            for (int i = 0; i < list1.arraySize; i++)
            {
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.PropertyField(list1.GetArrayElementAtIndex(i), GUIContent.none);
                EditorGUILayout.PropertyField(list2.GetArrayElementAtIndex(i), GUIContent.none);
                EditorGUILayout.EndHorizontal();
            }
            ShowButtons(list1, list2);
        }
        
    }

    private static void ShowButtons(ManaValueDictionary dictionary)
    {
        EditorGUILayout.BeginHorizontal();
        if(GUILayout.Button(addButtonContent, EditorStyles.miniButton, GUILayout.Width(buttonWidth)))
        {
            dictionary.Add(type, amount);

            type = null;
            amount = 0;
        }
        if(GUILayout.Button(deleteButtonContent, EditorStyles.miniButton, GUILayout.Width(buttonWidth)))
        {
            dictionary.RemoveAt(dictionary.Count - 1);
        }
    }

    private static void ShowButtons(SerializedProperty list1, SerializedProperty list2)
    {
        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button(addButtonContent, EditorStyles.miniButton, GUILayout.Width(20f)))
        {
            list1.arraySize += 1;
            list2.arraySize += 1;
        }
            
        if (GUILayout.Button(deleteButtonContent, EditorStyles.miniButton, GUILayout.Width(20f)))
        {
            int incomingSize = list1.arraySize;
            list1.DeleteArrayElementAtIndex(list1.arraySize - 1);
            if (list1.arraySize == incomingSize)
                list1.arraySize -= 1;

            list2.DeleteArrayElementAtIndex(list2.arraySize - 1);
            if (list2.arraySize == incomingSize)
                list2.arraySize -= 1;
        }
            
        EditorGUILayout.EndHorizontal();
    }
}
