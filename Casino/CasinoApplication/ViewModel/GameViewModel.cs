using CasinoApplication.Common;
using CasinoApplication.Model;
using CasinoApplication.ViewModel.Commands;
using CasinoData;
using CasinoLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

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

        private Action<object> closeDelegate;

        public void SetCloseAction(Action<object> closeDelegate)
        {
            this.closeDelegate = closeDelegate;
        }

        private Action<object> addDelegate;

        public void SetAddAction(Action<object> addDelegate)
        {
            this.addDelegate = addDelegate;
        }

        private ICommand saveCommand;

        public ICommand SaveCommand {
            get {
                if (saveCommand == null)
                {
                    saveCommand = new DefaultCommand(e => OnSave(), null);
                }
                return saveCommand;
            }
        }

        private ICommand cancelCommand;

        public ICommand CancelCommand {
            get {
                if (cancelCommand == null)
                {
                    cancelCommand = new DefaultCommand(e => OnCancel(), null);
                }
                return cancelCommand;
            }
        }

        public void OnSave()
        {
            DataRepository dataRepository = Data.DataRepository;

            if (Mode == Mode.ADD)
            {
                Game game = new Game()
                {
                    Name = Name,
                    Type = Type,
                };
                
                Task.Run(() =>
                {
                    dataRepository.AddGame(game);
                });

                addDelegate(game);
            }
            else
            {
                Game modified = new Game()
                {
                    Id = Id,
                    Name = Name,
                    Type = Type,
                };

                Task.Run(() =>
                {
                    dataRepository.UpdateGame(game, modified);
                });
                
            }

            closeDelegate(this);
        }

        private void OnCancel()
        {
            closeDelegate(this);
        }

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
