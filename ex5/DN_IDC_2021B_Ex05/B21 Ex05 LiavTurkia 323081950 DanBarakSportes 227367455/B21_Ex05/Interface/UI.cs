using System;
using System.Collections.Generic;
using System.Text;

namespace B21_Ex05.Interface
{
	public abstract class UI
	{
        public delegate void GameEventHandler(UI i_Sender, Game.Game i_Game);
        public delegate void GameEndedEventHandler(UI i_Sender, Game.Game i_Game, Game.Player i_Winner);

        public event GameEventHandler BeforeGame;
        public event GameEndedEventHandler AfterGame;

		protected abstract Game.GameSettings PromptForGameSettings();

        // TODO: do we need a better way of getting the human player move?
		public abstract Game.CellPosition PromptForMove(Game.Board i_Board);


        //  passed in null in the case of a tie
        protected abstract bool ShouldGameContinue(Game.Player i_Winner);

        public void Start()
        {
            Game.GameSettings settings = this.PromptForGameSettings();

            Game.Player winner;
            do
            {
                Game.Game game = new Game.Game(new Game.Board(settings.BoardSize), settings.Player1, settings.Player2);

                if (this.BeforeGame != null)
                {
                    this.BeforeGame.Invoke(this, game);
                }

                while (!game.IsGameOver(out winner))
                {
                    game.PlayRound();
                }

                if (this.AfterGame != null)
				{
                    this.AfterGame.Invoke(this, game, winner);
				}
            }
            while (this.ShouldGameContinue(winner));
        }
    }
}
