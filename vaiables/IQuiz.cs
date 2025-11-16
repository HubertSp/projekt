using WpfApp4.vaiables;
using WpfApp4.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp4.Vaiables
{
    public interface IQuiz
    {
        int Id { get; }
        string Title { get; set; }

        // Lista pytań — generycznie (dowolny typ implementujący IQuestion)
        IReadOnlyList<IQuestion<object>> Questions { get; }

        // Dodawanie pytania
        void AddQuestion<TAnswer>(IQuestion<TAnswer> question);

        // Sprawdzenie wyniku użytkownika
        int CalculateScore(IEnumerable<IAnswer<object>> answers);
    }
}
