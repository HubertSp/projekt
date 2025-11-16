using WpfApp4.vaiables;
using WpfApp4.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp4.Vaiables
{
    public class Quiz : IQuiz
    {
        private static int _idSeq;
        private readonly List<IQuestion<object>> _questions;

        public int Id { get; }
        public string Title { get; set; }
        public IReadOnlyList<IQuestion<object>> Questions => _questions;

        public Quiz(string title)
        {
            Id = ++_idSeq;
            Title = title;
        }

        public void AddQuestion<TAnswer>(IQuestion<TAnswer> question)
        {
            // Rzutujemy do object, bo generyki są różne
            _questions.Add(new QuestionWrapper<TAnswer>(question));
        }

        public int CalculateScore(IEnumerable<IAnswer<object>> answers)
        {
            int score = 0;

            foreach (var answer in answers)
            {
                var question = _questions.FirstOrDefault(q => q.Id == answer.QuestionId);
                if (question != null && question.IsCorrect(answer.Value))
                    score++;
            }

            return score;
        }

        // Pomocniczy wrapper, żeby przechować różne typy pytań w jednej liście
        private class QuestionWrapper<TAnswer> : IQuestion<object>
        {
            private readonly IQuestion<TAnswer> _inner;
            public int Id => _inner.Id;
            public string Text { get => _inner.Text; set => _inner.Text = value; }

            public QuestionWrapper(IQuestion<TAnswer> inner)
            {
                _inner = inner;
            }

            public bool IsCorrect(object answer)
            {
                if (answer is TAnswer typed)
                    return _inner.IsCorrect(typed);
                return false;
            }
        }
    }
}
