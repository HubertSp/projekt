using System.Collections.Generic;
using System.Linq;
using WpfApp4.Variables;

namespace WpfApp4.vaiables
{
    public class ClosedQuestion : IQuestion<int>, IHasOptions<string>
    {
        public int Id { get; }
        public string Text { get; set; }

        private readonly List<string> _options = new();
        public IReadOnlyList<string> Options => _options;

        public int CorrectOptionIndex { get; }

        public ClosedQuestion(string text, IEnumerable<string> options, int correctOptionIndex)
        {
            Text = text;
            _options.AddRange(options ?? Enumerable.Empty<string>());
            CorrectOptionIndex = correctOptionIndex;
        }

        public bool IsCorrect(int answerIndex) => answerIndex == CorrectOptionIndex;
    }
}
