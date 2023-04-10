﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Game
    {
        [Key]
        public int ID { get; set; }
		public int PlayerOnTurn { get; set; }
		public int TurnNumber { get; set; }
        [JsonIgnore]
        public List<Player>? Players { get; set; }
		[JsonIgnore]
		public List<Turn>? Turns { get; set; }

        public Game()
        {

        }
        public void NewTurn(Turn turn)
        {
            this.Turns.Add(turn);
            this.TurnNumber = turn.ID;
        }

    }
}
