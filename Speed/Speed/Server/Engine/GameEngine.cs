﻿using System.Collections;
using Speed.Shared.Models;

namespace Speed.Server.Engine
{
    public class GameEngine
    {
        #region Properties

        public Deck Deck { get; set; }                   // Main Deck to deal cards
        public List<Card> P1Draw { get; set; }           // Player 1's draw pile. 15 cards
        public List<Card> P2Draw { get; set; }           // Player 2's draw pile. 15 cards
        public List<Card> Mid1Draw { get; set; }         // First middle draw pile. 6 cards
        public List<Card> Mid2Draw { get; set; }         // Second middle draw pile. 6 cards
        public List<Card> Mid1Discard { get; set; }      // First empty pile to play on. 0 cards
        public List<Card> Mid2Discard { get; set; }      // Second empty pile to play on. 0 cards
        public List<Card> P1Hand { get; set; }           // Player 1's Hand
        public List<Card> P2Hand { get; set; }           // Player 2's Hand
        public GameService GameService { get; set; }     // Game Functions
        public IEnumerator? DeckEnumerator;

        #endregion

        #region Constructor

        public GameEngine()
        {
            Deck = new Deck();
            Deck.BuildDeck();
            GameService = new GameService();
            Shuffle(Deck.cards);
            P1Draw = new List<Card>();
            P2Draw = new List<Card>();
            Mid1Draw = new List<Card>();
            Mid2Draw = new List<Card>();
            Mid1Discard = new List<Card>();
            Mid2Discard = new List<Card>();
            P1Hand = new List<Card>();              // Limited to 5 cards at once
            P2Hand = new List<Card>();              // Limited to 5 cards at once
            deal();
        }

        #endregion

        #region methods

        /// <summary>
        /// Removes cards from Deck and disperses them to their appropriate hands and piles
        /// </summary>
        public void deal()
        {
            // add 5 cards to each player's hand
            for (var i = 0; i < 5; i++)
            {
                P1Hand.Add(Deck.DrawTopCard());
                P2Hand.Add(Deck.DrawTopCard());
            }

            // add 15 cards to each player's draw pile
            for (var i = 0; i < 15; i++)
            {
                P1Draw.Add(Deck.DrawTopCard());
                P2Draw.Add(Deck.DrawTopCard());
            }

            // add 6 cards to each middle draw pile
            for (var i = 0; i < 6; i++)
            {
                Mid1Draw.Add(Deck.DrawTopCard());
                Mid2Draw.Add(Deck.DrawTopCard());
            }
        }

        /// <summary>
        /// Function to shuffle a list of cards
        /// </summary>
        public void Shuffle(List<Card> cardPile)
        {
            Random rng = new Random();
            int size = cardPile.Count();
            while (size > 1)
            {
                size--;
                int swapSpot = rng.Next(size + 1);
                Card a = cardPile[swapSpot];
                cardPile[swapSpot] = cardPile[size];
                cardPile[size] = a;
            }
        }

        public void build()
        {
            Deck.BuildDeck();
        }

        /// <summary>
        /// compares two cards if they are a valid move option
        /// </summary>
        /// <param name="card1"></param>
        /// <param name="card2"></param>
        /// <returns>
        /// true if the cards value is off by one
        /// or twelve for the case of ace and king
        /// </returns>
        public bool isValidMove(Card card1, Card card2)
        {
            return Math.Abs(card1.Value - card2.Value) == 1 || Math.Abs(card1.Value - card2.Value) == 12;
        }

        #endregion

    }
}

