using HtmlAgilityPack;
using Newtonsoft.Json;
using System;

namespace CSharpPlugin.Plugin
{
    public class PluginImplementation : Library.IPlugin
    {
        public override void DoThings()
        {
            this.dep.Log("PluginImplementation");
            this.dep.Log(JsonConvert.SerializeObject(new { prova="ddd", prova2="dddd"}));


            // From Web
            var url = "https://github.com/arduosoft/RawCMS";
            var web = new HtmlWeb();
            var doc = web.Load(url);

            this.dep.Log(doc.ParsedText);
        }
    }
}
