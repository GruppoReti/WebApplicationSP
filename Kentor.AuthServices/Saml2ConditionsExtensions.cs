using System;
using System.IdentityModel.Tokens;
using System.Xml.Linq;
using Kentor.AuthServices.Internal;

namespace Kentor.AuthServices
{
    /// <summary>
    /// Extension methods for Saml2Condition
    /// </summary>
    public static class Saml2ConditionsExtensions
    {
        /// <summary>
        /// Writes out the conditions as an XElement.
        /// </summary>
        /// <param name="conditions">Conditions to create xml for.</param>
        /// <returns>XElement</returns>
        public static XElement ToXElement(this Saml2Conditions conditions)
        {
            if(conditions == null)
            {
                throw new ArgumentNullException(nameof(conditions));
            }

            return new XElement(Saml2Namespaces.Saml2 + "Conditions",
                    new XAttribute("NotOnOrAfter", 
                        conditions.NotOnOrAfter.Value.ToSaml2DateTimeString()));
        }
    }
}
