namespace CoensioApi.Services.Abstracts
{
    public interface IMessageProducer
    {
        public void PublishMessage<T>(T message);
    }
}
