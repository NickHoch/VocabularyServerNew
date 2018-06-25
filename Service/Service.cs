using System.ComponentModel;
using System.ServiceModel;
using System.ServiceProcess;
using System.Configuration;
using System.Configuration.Install;
using System;

namespace Microsoft.ServiceModel.Samples
{
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class VocabularyWindowsService : ServiceBase
    {
        public ServiceHost serviceHost = null;
        public VocabularyWindowsService()
        {
            ServiceName = "_VocabularyNT";
        }
        public static void Main()
        {
            Run(new VocabularyWindowsService());
        }
        protected override void OnStart(string[] args)
        {
            try
            {
                if (serviceHost != null)
                {
                    serviceHost.Close();
                }
                serviceHost = new ServiceHost(typeof(WCF.Vocabulary));
                serviceHost.Open();
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.ToString());
            }
        }
        protected override void OnStop()
        {
            try
            {
                if (serviceHost != null)
                {
                    serviceHost.Close();
                    serviceHost = null;
                }
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.ToString());
            }
        }
    } 
}
