using System.IdentityModel.Metadata;

namespace Kentor.AuthServices.Metadata
{
    /// <summary>
    /// Metadata extensions
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "SignOn", Justification = "Using SAML2 established terms." )]
    public class ServiceProviderSingleSignOnDescriptorExtensions
    {
        /// <summary>
        /// RequestInitiator url.
        /// </summary>
        public ProtocolEndpoint RequestInitiator
        {
            get;
            set;
        }

        /// <summary>
        /// Discovery Service response url.
        /// </summary>
        public IndexedProtocolEndpoint DiscoveryResponse
        {
            get;
            set;
        }
    }
}
