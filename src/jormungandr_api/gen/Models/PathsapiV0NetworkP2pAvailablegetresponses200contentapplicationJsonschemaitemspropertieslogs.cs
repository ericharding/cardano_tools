// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Jormungandr.Models
{
    using Microsoft.Rest;
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// the different logged events associated to this node
    /// </summary>
    public partial class PathsapiV0NetworkP2pAvailablegetresponses200contentapplicationJsonschemaitemspropertieslogs
    {
        /// <summary>
        /// Initializes a new instance of the
        /// PathsapiV0NetworkP2pAvailablegetresponses200contentapplicationJsonschemaitemspropertieslogs
        /// class.
        /// </summary>
        public PathsapiV0NetworkP2pAvailablegetresponses200contentapplicationJsonschemaitemspropertieslogs()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// PathsapiV0NetworkP2pAvailablegetresponses200contentapplicationJsonschemaitemspropertieslogs
        /// class.
        /// </summary>
        /// <param name="creationTime">when the node was known of our
        /// node</param>
        /// <param name="lastGossip">the last time we gossiped with the
        /// node</param>
        /// <param name="lastUpdate">the last time we received an update of the
        /// node (via gossiping with another node)</param>
        /// <param name="quarantined">the time at which the node was
        /// quarantined (if not there then the node is not quarantined)</param>
        /// <param name="lastUseOf">the last time this node has been part of a
        /// view for event propagation</param>
        public PathsapiV0NetworkP2pAvailablegetresponses200contentapplicationJsonschemaitemspropertieslogs(PathsapiV0NetworkP2pAvailablegetresponses200contentapplicationJsonschemaitemspropertieslogspropertiescreationTime creationTime, PathsapiV0NetworkP2pAvailablegetresponses200contentapplicationJsonschemaitemspropertieslogspropertieslastGossip lastGossip = default(PathsapiV0NetworkP2pAvailablegetresponses200contentapplicationJsonschemaitemspropertieslogspropertieslastGossip), PathsapiV0NetworkP2pAvailablegetresponses200contentapplicationJsonschemaitemspropertieslogspropertieslastUpdate lastUpdate = default(PathsapiV0NetworkP2pAvailablegetresponses200contentapplicationJsonschemaitemspropertieslogspropertieslastUpdate), PathsapiV0NetworkP2pAvailablegetresponses200contentapplicationJsonschemaitemspropertieslogspropertiesquarantined quarantined = default(PathsapiV0NetworkP2pAvailablegetresponses200contentapplicationJsonschemaitemspropertieslogspropertiesquarantined), PathsapiV0NetworkP2pAvailablegetresponses200contentapplicationJsonschemaitemspropertieslogspropertieslastUseOf lastUseOf = default(PathsapiV0NetworkP2pAvailablegetresponses200contentapplicationJsonschemaitemspropertieslogspropertieslastUseOf))
        {
            CreationTime = creationTime;
            LastGossip = lastGossip;
            LastUpdate = lastUpdate;
            Quarantined = quarantined;
            LastUseOf = lastUseOf;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets when the node was known of our node
        /// </summary>
        [JsonProperty(PropertyName = "creation_time")]
        public PathsapiV0NetworkP2pAvailablegetresponses200contentapplicationJsonschemaitemspropertieslogspropertiescreationTime CreationTime { get; set; }

        /// <summary>
        /// Gets or sets the last time we gossiped with the node
        /// </summary>
        [JsonProperty(PropertyName = "last_gossip")]
        public PathsapiV0NetworkP2pAvailablegetresponses200contentapplicationJsonschemaitemspropertieslogspropertieslastGossip LastGossip { get; set; }

        /// <summary>
        /// Gets or sets the last time we received an update of the node (via
        /// gossiping with another node)
        /// </summary>
        [JsonProperty(PropertyName = "last_update")]
        public PathsapiV0NetworkP2pAvailablegetresponses200contentapplicationJsonschemaitemspropertieslogspropertieslastUpdate LastUpdate { get; set; }

        /// <summary>
        /// Gets or sets the time at which the node was quarantined (if not
        /// there then the node is not quarantined)
        /// </summary>
        [JsonProperty(PropertyName = "quarantined")]
        public PathsapiV0NetworkP2pAvailablegetresponses200contentapplicationJsonschemaitemspropertieslogspropertiesquarantined Quarantined { get; set; }

        /// <summary>
        /// Gets or sets the last time this node has been part of a view for
        /// event propagation
        /// </summary>
        [JsonProperty(PropertyName = "last_use_of")]
        public PathsapiV0NetworkP2pAvailablegetresponses200contentapplicationJsonschemaitemspropertieslogspropertieslastUseOf LastUseOf { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (CreationTime == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "CreationTime");
            }
            if (CreationTime != null)
            {
                CreationTime.Validate();
            }
            if (LastGossip != null)
            {
                LastGossip.Validate();
            }
            if (LastUpdate != null)
            {
                LastUpdate.Validate();
            }
            if (Quarantined != null)
            {
                Quarantined.Validate();
            }
            if (LastUseOf != null)
            {
                LastUseOf.Validate();
            }
        }
    }
}