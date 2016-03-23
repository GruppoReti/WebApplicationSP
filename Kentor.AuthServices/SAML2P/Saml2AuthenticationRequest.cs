using System;
using System.Xml;
using System.Xml.Linq;
using Kentor.AuthServices.Internal;

namespace Kentor.AuthServices.Saml2P
{
    /// <summary>
    /// An authentication request corresponding to section 3.4.1 in SAML Core specification.
    /// </summary>
    public class Saml2AuthenticationRequest : Saml2RequestBase
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public Saml2AuthenticationRequest()
        {

        }

        /// <summary>
        /// The SAML2 request name
        /// </summary>
        protected override string LocalName
        {
            get { return "AuthnRequest"; }
        }

        /// <summary>
        /// The SAML2 
        /// tag
        /// </summary>
        protected string NameIdPolicy
        {
            get { return "NameIdPolicy"; }
        }

        /// <summary>
        /// The SAML2 RequestedAuthnContext tag
        /// </summary>
        protected string RequestedAuthnContext
        {
            get { return "RequestedAuthnContext"; }
        }

        /// <summary>
        /// The SAML2 AuthnContextClassRef tag
        /// </summary>
        protected string AuthnContextClassRef
        {
            get { return "AuthnContextClassRef"; }
        }   

        /// <summary>
        /// Serializes the request to a Xml message.
        /// </summary>
        /// <returns>XElement</returns>
        public XElement ToXElement()
        {
            // Create base element and set attributes
            var x = new XElement(Saml2Namespaces.Saml2P + LocalName);
            x.Add(base.ToXNodes());
            x.AddAttributeIfNotNullOrEmpty("AssertionConsumerServiceURL", AssertionConsumerServiceUrl);
            x.AddAttributeIfNotNullOrEmpty("AttributeConsumingServiceIndex", AttributeConsumingServiceIndex);

            // Add parameter for nameid policy
            if (NameIdPolicyAllowCreate != null)
            {
                var nameid = new XElement(Saml2Namespaces.Saml2P + NameIdPolicy);
                nameid.AddAttributeIfNotNullOrEmpty("AllowCreate", NameIdPolicyAllowCreate);
                x.Add(nameid);
            }

            // Add requested authentication context
            if (RequestedAuthenticationContext != null && RequestedAuthenticationContext != string.Empty)
            { 
                var authc = new XElement(Saml2Namespaces.Saml2P + RequestedAuthnContext);
                authc.AddAttributeIfNotNullOrEmpty("Comparison", "exact");
                var authcRef = new XElement(Saml2Namespaces.Saml2 + AuthnContextClassRef);
                authcRef.Value = RequestedAuthenticationContext;
                authc.Add(authcRef);
                x.Add(authc);
            }

            return x;
        }

        /// <summary>
        /// Serializes the message into wellformed Xml.
        /// </summary>
        /// <returns>string containing the Xml data.</returns>
        public override string ToXml()
        {
            XDocument xDoc = new XDocument();
            xDoc.Add(ToXElement());
            return xDoc.ToString();
        }

        /// <summary>
        /// Read the supplied Xml and parse it into a authenticationrequest.
        /// </summary>
        /// <param name="xml">xml data.</param>
        /// <returns>Saml2Request</returns>
        /// <exception cref="XmlException">On xml errors or unexpected xml structure.</exception>
        public static Saml2AuthenticationRequest Read(string xml)
        {
            if (xml == null)
            {
                return null;
            }
            var x = new XmlDocument();
            x.PreserveWhitespace = true;
            x.LoadXml(xml);
            
            return new Saml2AuthenticationRequest(x);
        }

        private Saml2AuthenticationRequest(XmlDocument xml)
        {
            ReadBaseProperties(xml);

            var AssertionConsumerServiceUriString = xml.DocumentElement.Attributes["AssertionConsumerServiceURL"].GetValueIfNotNull();

            if (AssertionConsumerServiceUriString != null)
            {
                AssertionConsumerServiceUrl = new Uri(AssertionConsumerServiceUriString);
            }
        }

        /// <summary>
        /// The assertion consumer url that the idp should send its response back to.
        /// </summary>
        public Uri AssertionConsumerServiceUrl { get; set; }

        /// <summary>
        /// The requested authentication context for the authentication request.
        /// </summary>
        public string RequestedAuthenticationContext { get; set; }

        /// <summary>
        /// Index to the SP metadata where the list of requested attributes is found.
        /// </summary>
        public int? AttributeConsumingServiceIndex { get; set; }

        /// <summary>
        /// NameIdPolicy allowCreate parameter
        /// </summary>
        public string NameIdPolicyAllowCreate { get; set; }
    }
}
