using System.Collections.Generic;

namespace HETHONGTINHNHUANBUT.Services.AI.Memory
{
    public class ConversationMemory
    {
        private readonly List<string> _history;
        private readonly int _maxHistoryLength;

        public ConversationMemory(int maxHistoryLength = 10)
        {
            _history = new List<string>();
            _maxHistoryLength = maxHistoryLength;
        }

        public void AddUserMessage(string message)
        {
            AddMessage($"User: {message}");
        }

        public void AddAIMessage(string message)
        {
            AddMessage($"AI: {message}");
        }

        private void AddMessage(string message)
        {
            _history.Add(message);
            if (_history.Count > _maxHistoryLength)
            {
                _history.RemoveAt(0);
            }
        }

        public string GetContextString()
        {
            return string.Join("\n", _history);
        }

        public void Clear()
        {
            _history.Clear();
        }
    }
}
