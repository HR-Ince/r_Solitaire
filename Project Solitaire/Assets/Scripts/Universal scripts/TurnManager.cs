using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TurnManager : MonoBehaviour
{
    public enum TurnPhase
    {
        Null,
        Draw,
        Main1,
        Battle,
        Main2,
        End
    }

    [SerializeField] Button progressButton;

    public PlayerController ActivePlayer { get; private set; }
    private TurnPhase turnPhase;

    [SerializeField] int startingHandSize = 5;

    private PlayerController[] players;

    private void Start()
    {
        players = FindObjectsOfType<PlayerController>();
        SetupPlayers();

        ActivePlayer = players[0];
        StartTurn();
    }

    private void SetupPlayers()
    {
        foreach(PlayerController player in players)
        {
            player.SetupPointers();
            player.SetTurnPhase(TurnPhase.Null);
            player.DeckManager.CreateDeck();
            player.Cam.enabled = false;
            
            int i = 0;
            while(i < startingHandSize)
            {
                player.DrawCard();
                i++;
            }
        }
    }

    public void StartTurn()
    {
        ActivePlayer.Cam.enabled = true;
        ActivePlayer.SetManaDisplay();
        DrawPhase();
    }

    public void ProgressTurn()
    {
        print(turnPhase);
        /*if(turnPhase == TurnPhase.Main1)
        {
            BattlePhase();
            return;
        }
        else if(turnPhase == TurnPhase.Battle)
        {
            MainPhase2();
            return;
        }*/
    }

    private void DrawPhase()
    {
        turnPhase = TurnPhase.Draw;
        print("Draw Phase");
        ActivePlayer.SetTurnPhase(TurnPhase.Draw);
        ActivePlayer.DrawCard();
        MainPhase1();
        print("Draw: " + turnPhase);
    }

    private void MainPhase1()
    {
        turnPhase = TurnPhase.Main1;
        print("Main Phase 1");
        ActivePlayer.SetTurnPhase(TurnPhase.Main1);
        progressButton.GetComponentInChildren<TextMeshProUGUI>().text = "Battle";
        print("Main: " + turnPhase);
    }

    private void BattlePhase()
    {
        turnPhase = TurnPhase.Battle;
        print("Battle Phase");
        ActivePlayer.SetTurnPhase(TurnPhase.Battle);
        progressButton.GetComponentInChildren<TextMeshProUGUI>().text = "End Battle";
    }

    private void MainPhase2()
    {
        turnPhase = TurnPhase.Main2;
        print("Main Phase 2");
        ActivePlayer.SetTurnPhase(TurnPhase.Main2);
        progressButton.GetComponentInChildren<TextMeshProUGUI>().text = "End Turn";
    }
}
