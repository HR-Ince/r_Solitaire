using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public enum TurnPhase
    {
        Draw,
        Main1,
        Battle,
        Main2,
        End
    }

    public PlayerController ActivePlayer { get; private set; }
    public TurnPhase turnPhase { get; private set; }

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

    private void DrawPhase()
    {
        ActivePlayer.DrawCard();
    }

    private void MainPhase1()
    {
        turnPhase = TurnPhase.Main1;
    }
}
