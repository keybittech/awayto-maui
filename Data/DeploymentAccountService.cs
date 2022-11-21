using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon.Runtime;
using Amazon.Runtime.CredentialManagement;

namespace AwaytoMAUI.Data
{
    internal class DeploymentAccountService
    {
        public void RegisterAccount(string name, string key, string secret)
        {
            var opts = new CredentialProfileOptions
            {
                AccessKey = key,
                SecretKey = secret
            };
            var account = new CredentialProfile(name, opts);
            var netSdkStore = new NetSDKCredentialsFile();
            netSdkStore.RegisterProfile(account);
		}

		public void UnregisterAccount(string name)
		{
			var netSdkStore = new NetSDKCredentialsFile();
			netSdkStore.UnregisterProfile(name);
		}

		public string TestCredentials(string name)
		{
            var chain = new CredentialProfileStoreChain();
            AWSCredentials awsCredentials;
            if (chain.TryGetAWSCredentials(name, out awsCredentials)) {
                return "valid";
            } else
            {
                return "invalid";
            }
		}

		public Task<List<string>> ListAccounts()
        {
            var netSdkStore = new NetSDKCredentialsFile();
            return Task.FromResult(netSdkStore.ListProfileNames());
        }
    }
}
