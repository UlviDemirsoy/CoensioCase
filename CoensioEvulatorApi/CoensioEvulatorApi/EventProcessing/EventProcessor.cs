using System;
using System.Text.Json;
using CoensioEvulatorApi.Data.Dtos;
using CoensioEvulatorApi.Repositories.Abstracts;
using Microsoft.Extensions.DependencyInjection;

namespace CoensioEvulatorApi.EventProcessing
{
    public class EventProcessor : IEventProcessor
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly IEvaluationRepository _evaluationRepository;

        public EventProcessor(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        public void ProcessEvent(string message)
        {
            var eventType = DetermineEvent(message);

            switch (eventType)
            {
                case EventType.Submission:
                    EvaluateSubmission(message);
                    break;
                default:
                    break;
            }
        }

        private EventType DetermineEvent(string notifcationMessage)
        {
            Console.WriteLine("--> Determining Event");

            var eventType = JsonSerializer.Deserialize<dtoGenericEvent>(notifcationMessage);

            switch(eventType.Event)
            {
                case "submission":
                    Console.WriteLine("--> Submission Event Detected");
                    return EventType.Submission;
                default:
                    Console.WriteLine("--> Could not determine the event type");
                    return EventType.Undetermined;
            }
        }

        private void EvaluateSubmission(string message)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                
                var dtoPublishedSubmission = JsonSerializer.Deserialize<dtoPublishedSubmission>(message);
                var repo = scope.ServiceProvider.GetRequiredService<IEvaluationRepository>();
                try
                {

                    repo.Evaluate(dtoPublishedSubmission.AssignmentId);

                    Console.WriteLine("--> Submission added!");

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"--> Could not add Submission to DB {ex.Message}");
                }
            }
        }
    }

    enum EventType
    {
        Submission,
        Undetermined
    }
}