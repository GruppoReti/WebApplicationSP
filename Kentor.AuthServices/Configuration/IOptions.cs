namespace Kentor.AuthServices.Configuration
{
    /// <summary>
    /// Root interface for the options objects, handling all configuration of
    /// AuthServices.
    /// </summary>
    public interface IOptions
    {
        /// <summary>
        /// Options for the service provider's behaviour; i.e. everything except
        /// the idp and federation list.
        /// </summary>
        ISPOptions SPOptions { get; }

        /// <summary>
        /// Information about known identity providers.
        /// </summary>
        IdentityProviderDictionary IdentityProviders { get; }
    }
}
