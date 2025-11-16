using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp4.Vaiables
{
    public class QuestionRecord : INotifyPropertyChanged
    {
        private int _id;
        private string _text = "";
        private string _questionType = "closed"; // "closed" / "open"

        public int Id
        {
            get { return _id; }
            set { SetField(ref _id, value); }
        }

        public string Text
        {
            get { return _text; }
            set { SetField(ref _text, value); }
        }

        public string QuestionType
        {
            get { return _questionType; }
            set { SetField(ref _questionType, value); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return false;

            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
