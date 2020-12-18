using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CardDataCreationWindow : EditorWindow
{
    bool manaFoldout = true;
    string manaLabel;
    float buttonWidth = 75f;
    float labelWidth = 120f;
    float entryAreaWidth = 300f;
    int selected = 0;
    string[] cardPresetTypes = new string[] { "None", "Act", "Commander", "Unit" };

    bool showManaCost = false;
    bool showRank = false;
    bool showContribution = false;
    bool showAtkDef = false;

    CardDataAggregate gO;

    #region Card Variables

    string cardName = "";
    Sprite cardImage = null;
    string[] cardTypes = new string[3];

    int rank = 0;

    ManaValueDictionary manaValues;
    List<ManaType> manaTypes = new List<ManaType>();
    ManaType emptyManaType = null;
    List<int> amounts = new List<int>();
    int emptyAmount = 0;

    int cardAtk = 0;
    int cardDef = 0;
    #endregion

    GUIContent
        addCardButton = new GUIContent("Add Card", "Add card to assets"),
        addComponentButton = new GUIContent("Add", "Add card component"),
        addManaCostButton = new GUIContent("+", "Add mana cost"),
        removeComponentButton = new GUIContent("-", "Remove card component"),
        removeManaCostButton = new GUIContent("-", "Remove mana cost");

    [MenuItem("Create/Card Data")]
    static void Init()
    {
        CardDataCreationWindow window = (CardDataCreationWindow)GetWindow(typeof(CardDataCreationWindow), true, "Card Creator");
        window.Show();
    }

    private void OnGUI()
    {
        GUILayout.Space(10);

        GUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Preset types", GUILayout.Width(labelWidth));
        selected = EditorGUILayout.Popup(selected, cardPresetTypes);
        GUILayout.EndHorizontal();

        if (selected == 0) // None
        {
            showManaCost = false;
            showRank = false;
            showContribution = false;
            showAtkDef = false;
        }
        else if (selected == 1) // Act
        {
            showManaCost = true;
            showRank = false;
            showContribution = false;
            showAtkDef = false;
        }
        else if (selected == 2) // Commander
        {
            showManaCost = false;
            showRank = true;
            showContribution = true;
            showAtkDef = false;
        }
        else if (selected == 3) // Unit
        {
            showManaCost = true;
            showRank = false;
            showContribution = false;
            showAtkDef = true;
        }

        ShowGenericProperties();
        ShowLiveComponents();

        GUILayout.Space(10);

        if (GUILayout.Button(addCardButton, GUILayout.Width(buttonWidth)))
        {
            CreateCard();
        }
    }

    private void CreateCard()
    {
        if (selected == 1)
        {
            CardCost_Mana manaCost = CreateInstance<CardCost_Mana>();
            manaCost.values = manaValues;

            gO = CreateInstance<CardDataAggregate>();
            gO.Construct(cardName, cardImage, cardTypes, manaCost);

            AssetDatabase.CreateAsset(gO, "Assets/Cards/" + cardName + ".asset");
        }
        else
        {
            return;
        }
    }

    private void ShowGenericProperties()
    {
        GUILayout.Space(10);

        GUILayout.Label("Generic properties", EditorStyles.boldLabel);

        GUILayout.Space(5);
        EditorGUI.indentLevel = 1;

        GUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Card name", GUILayout.Width(labelWidth));
        cardName = EditorGUILayout.TextField(cardName);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Card image", GUILayout.Width(labelWidth));
        cardImage = (Sprite)EditorGUILayout.ObjectField(cardImage, typeof(Sprite), false);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Card types", GUILayout.Width(labelWidth));
        cardTypes[0] = EditorGUILayout.TextField(cardTypes[0]);
        cardTypes[1] = EditorGUILayout.TextField(cardTypes[1]);
        cardTypes[2] = EditorGUILayout.TextField(cardTypes[2]);
        GUILayout.EndHorizontal();
    }

    private void ShowLiveComponents()
    {
        if (showManaCost)
            ShowManaCost();
        if (showRank)
            ShowRank();
        if (showContribution)
            ShowContributionEntry();
        if (showAtkDef)
            ShowAtkDef();
    }

    private void ShowAtkDef()
    {
        GUILayout.Space(10);
        EditorGUI.indentLevel = 0;

        EditorGUILayout.LabelField("Attack and Defence Properties", EditorStyles.boldLabel);

        GUILayout.Space(5);
        EditorGUI.indentLevel = 1;

        GUILayout.BeginHorizontal();
        cardAtk = EditorGUILayout.IntField("Attack ", cardAtk);
        cardDef = EditorGUILayout.IntField("Defence ", cardDef);
        GUILayout.EndHorizontal();
    }

    private void ShowRank()
    {
        GUILayout.Space(10);
        EditorGUI.indentLevel = 0;

        EditorGUILayout.LabelField("Rank properties", EditorStyles.boldLabel);

        EditorGUI.indentLevel = 1;
        GUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Rank", GUILayout.Width(labelWidth));
        rank = EditorGUILayout.IntField(rank);
        GUILayout.EndHorizontal();
    }

    private void ShowContributionEntry()
    {
        GUILayout.Space(10);
        EditorGUI.indentLevel = 0;

        GUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Contribution properties", EditorStyles.boldLabel);
        if (GUILayout.Button(removeComponentButton, GUILayout.Width(buttonWidth)))
        {
            //Clear properties
        }
        GUILayout.EndHorizontal();

        GUILayout.Space(5);
        EditorGUI.indentLevel = 1;

        EditorGUILayout.LabelField("Contribution", GUILayout.Width(labelWidth));

        GUILayout.Space(5);

        if (manaValues == null)
            manaValues = new ManaValueDictionary();

        CustomGUILayout.ManaValueDictionaryField("Mana cost", manaValues);
    }

    private void ShowManaCost()
    {
        GUILayout.Space(10);
        EditorGUI.indentLevel = 0;

        EditorGUILayout.LabelField("Mana cost properties", EditorStyles.boldLabel);

        GUILayout.Space(5);

        if (manaValues == null)
            manaValues = new ManaValueDictionary();

        CustomGUILayout.ManaValueDictionaryField("Mana cost", manaValues);
    }
}
