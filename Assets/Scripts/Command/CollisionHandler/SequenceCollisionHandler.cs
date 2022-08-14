using System;
using System.Collections.Generic;

namespace DeviceControl
{
    public class SequenceCollisionHandler : ICollisionHandler
    {
        // TODO возможно расширить до бесконечной очереди команд
        //private Dictionary<Command, Queue<Command>> commandSequences = new();

        private List<Command> requestedCommands = new();

        public void Handle(Command current, Action runRequestedCommand)
        {
            if (requestedCommands.Contains(current))
            {
                // игнорим повторный запрос на добавление в очередь выполнения команды
                return;
            }

            requestedCommands.Add(current);
            
            current.SubscribeOnFinishOnce(() => requestedCommands.Remove(current));
            current.SubscribeOnFinishOnce(runRequestedCommand);
        }
    }
}