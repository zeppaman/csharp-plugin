using Microsoft.Extensions.Logging;
using System;

namespace CSharpPlugin.Library
{
    public class Dependency
    {
        //HtmlAgilityPack.HtmlWeb web; //force

        private readonly ILogger _logger;

        public string ComesFrom { get; set; }

        public Dependency(ILogger<Dependency> logger)
        {
            this._logger = logger;
        }

        public void Log(string pluginName)
        {
            _logger.LogInformation($"I'm used inside {pluginName}, and I came from {ComesFrom}");
        }
    }
}
