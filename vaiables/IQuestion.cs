using System.Collections.Generic;

namespace WpfApp4.Variables
{
    public interface IQuestion<TAnswer>
    {
        int Id { get; }
        string Text { get; set; }
        bool IsCorrect(TAnswer answer);
    }
        
    public interface IHasOptions<TOption>
    {
        IReadOnlyList<TOption> Options { get; }
    }
}
