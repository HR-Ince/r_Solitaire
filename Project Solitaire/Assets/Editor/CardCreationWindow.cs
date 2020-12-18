using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CardCreationWindow : EditorWindow
{
    float buttonWidth = 75f;
    float labelWidth = 120f;
    float entryAreaWidth = 300f;
    int selected = 0;
    string[] cardPresetTypes = new string[] { "None", "Act", "Commander", "Unit" };

    bool showManaCost = false;
    bool showRank = false;
    bool showContribution = false;
    bool showAtkDef = false;

    CardData gO;

    // CARD VARIABLES

    string cardName = "";
    Sprite cardImage = null;
    string[] cardTypes = new string[3];

    int rank = 0;

    List<ManaType> manaTypes = new List<ManaType>();
    ManaType entryType = null;
    List<int> amounts = new List<int>();
    int entryAmount = 0;

    int cardAtk = 0;
    int cardDef = 0;

    GUIContent
        addCardButton = new GUIContent("Add Card", "Add card to assets"),
        addComponentButton = new GUIContent("Add", "Add card component"),
        addManaCostButton = new GUIContent("Add", "Add mana cost"),
        removeComponentButton = new GUIContent("-", "Remove card component");

    [MenuItem("Custom/Card Creator")]
    static void Init()
    {
        CardCreationWindow window = (CardCreationWindow)GetWindow(typeof(CardCreationWindow), true, "Card Creator");
        window.Show();
    }

    private void OnGUI()
    {
        GUILayout.Space(10);

        GUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Preset types", GUILayout.Width(labelWidth));
        selected = EditorGUILayout.Popup(selected, cardPresetTypes);
        GUILayout.EndHorizontal();

        if(selected == 0) // None
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
        else if(selected == 2) // Commander
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
        if (entryType != null && entryAmount != 0)
        {
            manaTypes.Add(entryType);
            amounts.Add(entryAmount);

            entryType = null;
            entryAmount = 0;
        }

        if (selected == 0)
            return;
        else if (selected == 1)
            CreateCostly();
        else if (selected == 2)
            CreateCommander();
        else if (selected == 3)
            CreateUnit();

        AssetDatabase.CreateAsset(gO, "Assets/Cards/" + cardName + ".asset");

        ClearEntryVariables();
    }

    private void CreateCostly()
    {
        CardData_CostBased temp = CreateInstance<CardData_CostBased>();
        temp.Construct(cardName, cardImage, cardTypes, manaTypes, amounts);

        gO = temp;
    }

    private void CreateCommander()
    {
        CardData_Commander temp = CreateInstance<CardData_Commander>();
        temp.Construct(cardName, cardImage, cardTypes, rank, manaTypes, amounts);

        gO = temp;
    }

    private void CreateUnit()
    {
        CardData_Unit temp = CreateInstance<CardData_Unit>();
        temp.Construct(cardName, cardImage, cardTypes, manaTypes, amounts, cardAtk, cardDef);

        gO = temp;
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

        DisplayManaAmountEntryForm();
    }

    private void ShowManaCost()
    {
        GUILayout.Space(10);
        EditorGUI.indentLevel = 0;

        GUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Mana cost properties", EditorStyles.boldLabel);
        if (GUILayout.Button(removeComponentButton, GUILayout.Width(buttonWidth)))
        {
            //Clear properties
        }
        GUILayout.EndHorizontal();

        GUILayout.Space(5);
        EditorGUI.indentLevel = 1;
                
        EditorGUILayout.LabelField("Mana cost", GUILayout.Width(labelWidth));

        DisplayManaAmountEntryForm();
    }

    private void DisplayManaAmountEntryForm()
    {
        if(amounts.Count > 0 && manaTypes.Count > 0)
        {
            for (int i = 0; i < manaTypes.Count; i++)
            {
                EditorGUI.indentLevel = 2;
                GUILayout.BeginHorizontal(GUILayout.Width(entryAreaWidth));
                manaTypes[i] = (ManaType)EditorGUILayout.ObjectField(manaTypes[i], typeof(ManaType), false);
                amounts[i] = EditorGUILayout.IntField(amounts[i]);
                GUILayout.EndHorizontal();
            }
        }

        EditorGUI.indentLevel = 2;
        GUILayout.BeginHorizontal(GUILayout.Width(entryAreaWidth + buttonWidth));
        entryType = (ManaType)EditorGUILayout.ObjectField(entryType, typeof(ManaType), false);
        entryAmount = EditorGUILayout.IntField(entryAmount);
        if (GUILayout.Button(addManaCostButton, GUILayout.Width(buttonWidth)))
        {
            if(entryType != null && entryAmount != 0)
            {
                manaTypes.Add(entryType);
                amounts.Add(entryAmount);

                entryType = null;
                entryAmount = 0;
            }
        }
        GUILayout.EndHorizontal();
    }

    private void ClearEntryVariables()
    {

        cardName = "";
        cardImage = null;
        cardTypes = new string[3];

        rank = 0;

        manaTypes.Clear();
        amounts.Clear();

        cardAtk = 0;
        cardDef = 0;
    }
}
