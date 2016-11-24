using System;
using System.Configuration;
using System.Linq;
using Microsoft.Extensions.Configuration;

namespace Nethereum.RPC.Tests.Testers
{
    public class TestSettings
    {
        public TestSettings()
        {
            var builder = new ConfigurationBuilder()
           .AddJsonFile("test-settings.json");
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; set; }

        public string GetDefaultAccount()
        {
            return GetAppSettingsValue("defaultAccount");
        }

        public string GetBlockHash()
        {
            return GetAppSettingsValue("blockhash");
        }

        public string GetTransactionHash()
        {
            return GetAppSettingsValue("transactionHash");
        }

        public ulong GetBlockNumber()
        {
            return Convert.ToUInt64(GetAppSettingsValue("blocknumber"));
        }

        private string GetAppSettingsValue(string key)
        {
            var configuration = Configuration.GetSection("testSettings");
            var children = configuration.GetChildren();
            var setting = children.FirstOrDefault(x => x.Key == key);
            if (setting != null)
                return setting.Value;
            throw  new Exception("Setting: " + key + " Not found");
        }

        public string GetRPCUrl()
        {
            return GetAppSettingsValue("rpcUrl");
        }

        public string GetDefaultAccountPassword()
        {
            return GetAppSettingsValue("defaultAccountPassword");
        }

        public string GetDefaultLogLocation()
        {
            return GetAppSettingsValue("debugLogLocation");
        }
    }
}