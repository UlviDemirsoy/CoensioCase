namespace CoensioApi.Data.Dtos
{
    public class dtoUpdateMultipleChoiceQuestion
    {
        public int Id { get; set; }
        public string QuestionText { get; set; }
        public string Options { get; set; }
        public string TrueAnswer { get; set; }

    }
}
