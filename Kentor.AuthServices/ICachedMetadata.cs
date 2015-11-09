using System;

namespace Kentor.AuthServices
{
    interface ICachedMetadata
    {
        /// <summary>
        /// Permitted cache duration for the metadata.
        /// </summary>
        TimeSpan? CacheDuration { get; set; }

        /// <summary>
        /// Valid until
        /// </summary>
        DateTime? ValidUntil { get; set; }
    }
}
