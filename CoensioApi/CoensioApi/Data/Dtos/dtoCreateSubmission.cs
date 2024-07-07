namespace CoensioApi.Data.Dtos
{
    public class dtoCreateSubmission
    {
        public int AssignmentId { get; set; }
        public int CodingQuestionId { get; set; }
        public string CodingQuesitonUserSubmission { get; set; }
        public int MultipleChoiceQuestionId1 { get; set; }
        public string MultipleChoiceQuesitonUserSubmission1 { get; set; }
        public int MultipleChoiceQuestionId2 { get; set; }
        public string MultipleChoiceQuesitonUserSubmission2 { get; set; }
        public int FreeTextQuestionId1 { get; set; }
        public string FreeTextQuesitonUserSubmission1 { get; set; }
        public int FreeTextQuestionId2 { get; set; }
        public string FreeTextQuesitonUserSubmission2 { get; set; }

    }
}
