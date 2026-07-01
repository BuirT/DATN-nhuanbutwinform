using System.Configuration;

namespace HETHONGTINHNHUANBUT
{
    public static class AIConfig
    {
        public static string OllamaUrl => ConfigurationManager.AppSettings["OllamaUrl"] ?? "http://localhost:11434";
        public static string OllamaModel => ConfigurationManager.AppSettings["OllamaModel"] ?? "qwen2.5";
        public static string GenerateUrl => $"{OllamaUrl.TrimEnd('/')}/api/generate";
    }
}
