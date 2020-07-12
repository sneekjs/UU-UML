using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public List<Player> players = new List<Player>();
    public DiscardPile discardPile;
    public Deck deck;
    [SerializeField] private Player currentPlayer;

    public Player CurrentPlayer
    {
        get { return currentPlayer; }
        set
        {
            currentPlayer = value;
            currentPlayer.stable.TriggerStartupEffect();
            GivePlayerACard(currentPlayer);
        }
    }

    private void Start()
    {
        SetupGame();
    }

    public bool CheckVictory(Player currentPlayer)
    {
        Debug.Log("Victory is checked");
        if (currentPlayer.GetStable().GetStable().Count >= 7)
        {
            EndGame();
            return true;
        }
        return false;
    }

    public void GivePlayerACard(Player rewardedPlayer)
    {
        Debug.Log("A card is given to " + rewardedPlayer);
        deck.MoveCardTo(deck.cards[Random.Range(0, deck.cards.Count)], rewardedPlayer.hand);
    }

    public void PressDrawButton()
    {
        Debug.Log(currentPlayer + " chooses to draw a card");
        GivePlayerACard(currentPlayer);
        Debug.Log("Turn is passed on to the next player");
        EndPlayerTurn();
    }

    public void PressPlayButton()
    {
        Debug.Log(currentPlayer + " chooses to play a card");
        Card randomlyPlayedCard = currentPlayer.hand.cards[Random.Range(0, currentPlayer.hand.cards.Count)];
        switch (randomlyPlayedCard.GetType().ToString())
        {
            case "Effect":
                Debug.Log("A effect card was played");
                currentPlayer.hand.MoveCardTo(randomlyPlayedCard, discardPile);
                if (randomlyPlayedCard is Effect)
                {
                    //trigger magical effect
                }
                break;
            case "Magical":
                Debug.Log("A magical unicorn card was played");
                currentPlayer.hand.MoveCardTo(randomlyPlayedCard, currentPlayer.stable);
                if (randomlyPlayedCard is Magical)
                {
                    //trigger magical effect
                }
                break;
            case "Unicorn":
                Debug.Log("A unicorn card was played");
                currentPlayer.hand.MoveCardTo(randomlyPlayedCard, currentPlayer.stable);
                break;
            case "Card":
                Debug.Log("A random placeholder card was played");
                break;
            default:
                Debug.Log("Error, a player played a card of an unknown type");
                break;
        }
        CheckVictory(currentPlayer);
        EndPlayerTurn();
    }

    private void SetupGame()
    {
        Debug.Log("The game manager is getting ready to start the game");
        Instance = this;
        CurrentPlayer = players[0];
    }

    private void EndPlayerTurn()
    {
        foreach (Player player in players)
        {
            Debug.Log("End of turn effects trigger for " + player);
            foreach (Card unicorn in player.stable.cards)
            {
                if (unicorn is Magical magicalUnicorn)
                {
                    if (!magicalUnicorn.hasStartOfTurnEffect)
                    {
                        magicalUnicorn.TriggerEffect();
                    }
                }
            }
        }

        currentPlayer.hand.EmptyToLimit();

        Debug.Log("Turn is passed on to the next player");
        int nextPlayerIndex = 0;
        nextPlayerIndex = players.IndexOf(currentPlayer) + 1;
        if (nextPlayerIndex >= players.Count)
        {
            CurrentPlayer = players[0];
        }
        else
        {
            CurrentPlayer = players[nextPlayerIndex];
        }
    }

    private void EndGame()
    {
        Debug.Log("End of the game, the winner is " + currentPlayer);
        //ends game
    }
}
