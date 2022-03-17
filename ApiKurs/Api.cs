using Newtonsoft.Json.Linq;
using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ApiKurs
{
    internal class Api : IJob
    {
        private static readonly string url = "http://dev.virtualearth.net/REST/v1/Routes?wayPoint.1={start}&wayPoint.2={end}&optimize=timeWithTraffic&routeAttributes=routeSummariesOnly&key=AilQsGyFGIOyYAks2zcgnMH_7LKPWAlikHfNgouhNBuJAatAgxZmh_ImOKANKPs0";
        private static readonly HttpClient client = new HttpClient();
        private static string tempUrl { get; set; }
        private static IScheduler scheduler { get; set; }
        private static string time { get; set; } = "0 0 0,6,12,18";

        private async Task<string> CallApi(string tempUrl)
        {
            var response = await client.GetAsync(tempUrl);
            var responseString = await response.Content.ReadAsStringAsync();
            JObject jo = JObject.Parse(responseString);
            return (string)jo.SelectToken("resourceSets.[0].resources.[0].travelDurationTraffic");
        }

        private async Task InputFileHandler()
        {
            using (StreamReader sr = new StreamReader("coordinates.txt"))
            {
                while (sr.Peek() != -1)
                {
                    string line = await sr.ReadLineAsync();
                    if (line != "")
                    {
                        string coords;
                        if (line.Contains(':')) coords = line.Split(':')[1].Trim();
                        else coords = line;
                        string start = coords.Split()[0];
                        string end = coords.Split()[1];
                        Dictionary<string, string> replacements = new Dictionary<string, string> { { "{start}", start }, { "{end}", end } };
                        tempUrl = replacements.Aggregate(url, (current, replacement) => current.Replace(replacement.Key, replacement.Value));
                        await OutputFileHandler(line.Split(':')[0]);
                    }
                }
            }
        }

        private async Task OutputFileHandler(string pathInfo)
        {
            using (StreamWriter sw = File.AppendText("output.txt"))
            {
                await Task.Delay(TimeSpan.FromSeconds(1));
                string time = await CallApi(tempUrl);
                sw.WriteLine($"{pathInfo}: {time} {DateTime.Now}");
            }
        }

        public async void RunAutomatic()
        {
            StdSchedulerFactory factory = new StdSchedulerFactory();
            scheduler = await factory.GetScheduler();

            await scheduler.Start();

            IJobDetail job = JobBuilder.Create<Api>()
                .WithIdentity("job1", "group1")
                .Build();

            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("trigger1", "group1")
                .WithCronSchedule($"{time} * * ?")
                .ForJob(job)
                .Build();

            await scheduler.ScheduleJob(job, trigger);
        }

        public async void RunNow()
        {
            await InputFileHandler();
        }

        public async void StopRunning()
        {
            if(scheduler != null) await scheduler.Shutdown();
        }

        public void SetTime()
        {
            TimeSet ts = new TimeSet();
            ts.Show();
            ts.FormClosed += (s, e) =>
            {
                time = ts.timeAns;
            };
        }

        public async Task Execute(IJobExecutionContext context)
        {
            await InputFileHandler();
        }
    }
}