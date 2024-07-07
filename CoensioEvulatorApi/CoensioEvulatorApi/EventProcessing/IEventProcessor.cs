namespace CoensioEvulatorApi.EventProcessing
{
    public interface IEventProcessor
    {
        void ProcessEvent(string message);
    }
}