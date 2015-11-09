using System;
using System.IdentityModel.Metadata;

namespace Kentor.AuthServices.Metadata
{
    /// <summary>
    /// Subclass to EntityDescriptor that contains support for extensions.
    /// </summary>
    public class ExtendedEntityDescriptor : EntityDescriptor, ICachedMetadata
    {
        /// <summary>
        /// Permitted cache duration for the metadata.
        /// </summary>
        public TimeSpan? CacheDuration { get; set; }

        /// <summary>
        /// Valid until
        /// </summary>
        public DateTime? ValidUntil { get; set; }
    }
}
