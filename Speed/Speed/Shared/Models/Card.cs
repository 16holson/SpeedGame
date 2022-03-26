﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Speed.Shared.Models.Enums;

namespace Speed.Shared.Models {
    public class Card {

        public CardSuit Suit { get; set; }
        public CardValue Value { get; set; }


        public bool IsRed {
            get {
                return Suit == CardSuit.Diamonds || Suit == CardSuit.Hearts;
            }
        }

        public bool IsBlack {
            get {
                return !IsRed;
            }
        }

        public override string ToString() {
            return Value.ToString() + " of " + Suit.ToString();
        }

    }
}
