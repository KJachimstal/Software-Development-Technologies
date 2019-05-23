using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace CasinoLibrary
{
    [Serializable()]
    public class Game : INotifyPropertyChanged
    {
        public enum GameType { POKER, BRIDGE, ROULETTE }

        private int id;

        [XmlElement("Id")]
        public int Id {
            get { return id; }
            set { id = value; }
        }

        private string name;

        [XmlElement("Name")]
        public string Name {
            get { return name; }
            set 
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        private GameType type;

        [XmlElement("Type")]
        public GameType Type {
            get { return type; }
            set 
            {
                type = value;
                OnPropertyChanged("Type");
            }
        }

        public Game(int id, string name, GameType type)
        {
            this.id = id;
            this.name = name;
            this.type = type;
        }

        public Game() { }

        public override bool Equals(object obj)
        {
            var state = obj as Game;
            return state != null &&
                id == state.Id &&
                name == state.Name &&
                type == state.Type;
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}