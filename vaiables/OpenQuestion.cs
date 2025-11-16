using System;
using WpfApp4.Vaiables;
using WpfApp4.Variables;

namespace WpfApp4.vaiables
{
    public class OpenQuestion : IQuestion<string>
    {
        public int Id { get; }
        public string Text { get; set; }

        public string ExpectedAnswer { get; set; }

        public OpenQuestion(string text, string expectedAnswer)
        {
            Text = text;
            ExpectedAnswer = expectedAnswer ?? string.Empty;
        }

        public bool IsCorrect(string answer)
            => string.Equals(ExpectedAnswer ?? string.Empty, answer ?? string.Empty,
                             StringComparison.OrdinalIgnoreCase);
    }
}
