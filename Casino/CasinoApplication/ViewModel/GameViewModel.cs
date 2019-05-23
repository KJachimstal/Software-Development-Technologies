using CasinoLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CasinoApplication.ViewModel
{
    class GameViewModel : ViewModel, IDataErrorInfo
    {
        private Game game;

        private int id;

        public int Id {
            get { return id; }
            set { id = value; }
        }

        private string name;

        public string Name {
            get { return name; }
            set { name = value; }
        }

        private Game.GameType type = Game.GameType.EMPTY;

        public Game.GameType Type {
            get { return type; }
            set { type = value; }
        }

        public List<Game.GameType> GameTypes {
            get {
                return new List<Game.GameType> {
                    Game.GameType.POKER,
                    Game.GameType.BRIDGE,
                    Game.GameType.ROULETTE
                };
            }
        }


        public GameViewModel(Game game)
        {
            this.game = game;
            Id = game.Id;
            Name = game.Name;
            Type = game.Type;
        }

        public GameViewModel() { }


        #region IDataErrorInfo Members
        string IDataErrorInfo.this[string columnName] {
            get {
                if (columnName == "Name")
                {
                    if (Name == null)
                    {
                        return "Please enter game name";
                    }
                    else if (Name.Trim() == string.Empty)
                    {
                        return "Game name is required";
                    }
                } else if (columnName == "Type")
                {
                    if (Type == Game.GameType.EMPTY)
                    {
                        return "Please select game type";
                    }
                }
                return null;
            }
        }

        string IDataErrorInfo.Error {
            get { return string.Empty; }
        }
        #endregion
    }
}
