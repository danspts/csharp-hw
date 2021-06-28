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

        // passed in null in the case of a tie
        protected abstract bool ShouldGameContinue(Game.Player i_Winner);

        private void startNewGame(Game.GameSettings i_Settings)
        {
            Game.Game game = new Game.Game(new Game.Board(i_Settings.BoardSize), i_Settings.Player1, i_Settings.Player2);

            if (this.BeforeGame != null)
            {
                this.BeforeGame.Invoke(this, game);
            }

            game.GameOver += this.Game_GameOver;

            game.Start();
        }

        public virtual void Start()
        {
            this.startNewGame(this.PromptForGameSettings());
        }

        private void Game_GameOver(Game.Game i_Sender, Game.Player i_Winner)
        {
            if (this.AfterGame != null)
            {
                this.AfterGame.Invoke(this, i_Sender, i_Winner);
            }

            i_Sender.GameOver -= this.Game_GameOver;

            if (this.ShouldGameContinue(i_Winner))
            {
                this.startNewGame(new Game.GameSettings(i_Sender.Board.Size, i_Sender.Player1, i_Sender.Player2));
            }
            else
            {
                Environment.Exit(0);
            }
        }
    }
}
