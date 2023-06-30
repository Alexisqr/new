
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfApp1.VievModels;

namespace WpfApp1.VievModels
{
    public class CreateAnVievModels: VievModelsBase
    {
        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));

                //ClearErrors(nameof(Name));

                //if (!HasUsername)
                //{
                //    AddError("Username cannot be empty.", nameof(Username));
                //}

                //OnPropertyChanged(nameof(CanCreateReservation));
            }

        }
        private int _age;
        public int Age
        {
            get
            {
                return _age;
            }
            set
            {
                _age = value;
                OnPropertyChanged(nameof(Age));

            }

        }
        private string _gender;
        public string Gender
        {
            get
            {
                return _gender;
            }
            set
            {
                _gender = value;
                OnPropertyChanged(nameof(Gender));

            }

        }
        private int _kind;
        public int Kind
        {
            get
            {
                return _kind;
            }
            set
            {
                _kind = value;
                OnPropertyChanged(nameof(Kind));

               
            }

        }
        public ICommand SubmitCommand { get; }
        public ICommand CancelCommand { get; }

        public CreateAnVievModels()
        {
          
        }

    }
}

//private readonly Animals _animas;

//public string? Name => _animas.Name;
//public int? Age => _animas.Age;

//public string? Gender => _animas.Gender;
//public int? Kind => _animas.Kind;

//public CreateAnVievModels(Animals reservation)
//{
//    _animas = reservation;
//}