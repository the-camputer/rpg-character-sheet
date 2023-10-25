using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGCharacterSheet.Models
{
    public class AbilityScore: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string Name { get; set; }

        private int _score;
        public int Score 
        { 
            get => _score; 
            set { 
                _score = value; 
                OnPropertyChanged("Score");
                OnPropertyChanged("Modifier"); 
            } 
        }

        public int Modifier
        {
            get
            {
                return (int) Math.Floor((Score - 10) / 2d);
            }
        }

        protected void OnPropertyChanged(string propertyName)
        {
            System.Diagnostics.Debug.WriteLine($"{propertyName}, {GetType().GetProperty(propertyName).GetValue(this)}");
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
