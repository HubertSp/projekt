namespace WpfApp4.vaiables
{
    public interface IAnswer<TValue>
    {
        int QuestionId { get; }
        int UserId { get; }
        TValue Value { get; set; }
    }

    public class Answer<TValue> : IAnswer<TValue>
    {
        public int QuestionId { get; }
        public int UserId { get; }
        public TValue Value { get; set; }

        public Answer(int questionId, int userId, TValue value)
        {
            QuestionId = questionId;
            UserId = userId;
            Value = value;
        }
    }
}
