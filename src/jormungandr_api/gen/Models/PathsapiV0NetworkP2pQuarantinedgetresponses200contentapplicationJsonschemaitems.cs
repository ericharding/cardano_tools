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
    /// a node and its associated logged data and records
    /// </summary>
    public partial class PathsapiV0NetworkP2pQuarantinedgetresponses200contentapplicationJsonschemaitems
    {
        /// <summary>
        /// Initializes a new instance of the
        /// PathsapiV0NetworkP2pQuarantinedgetresponses200contentapplicationJsonschemaitems
        /// class.
        /// </summary>
        public PathsapiV0NetworkP2pQuarantinedgetresponses200contentapplicationJsonschemaitems()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// PathsapiV0NetworkP2pQuarantinedgetresponses200contentapplicationJsonschemaitems
        /// class.
        /// </summary>
        /// <param name="profile">the node public profile</param>
        /// <param name="records">all the recorded error with this node</param>
        /// <param name="logs">the different logged events associated to this
        /// node</param>
        public PathsapiV0NetworkP2pQuarantinedgetresponses200contentapplicationJsonschemaitems(PathsapiV0NetworkP2pQuarantinedgetresponses200contentapplicationJsonschemaitemspropertiesprofile profile, PathsapiV0NetworkP2pQuarantinedgetresponses200contentapplicationJsonschemaitemspropertiesrecords records = default(PathsapiV0NetworkP2pQuarantinedgetresponses200contentapplicationJsonschemaitemspropertiesrecords), PathsapiV0NetworkP2pQuarantinedgetresponses200contentapplicationJsonschemaitemspropertieslogs logs = default(PathsapiV0NetworkP2pQuarantinedgetresponses200contentapplicationJsonschemaitemspropertieslogs))
        {
            Profile = profile;
            Records = records;
            Logs = logs;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets the node public profile
        /// </summary>
        [JsonProperty(PropertyName = "profile")]
        public PathsapiV0NetworkP2pQuarantinedgetresponses200contentapplicationJsonschemaitemspropertiesprofile Profile { get; set; }

        /// <summary>
        /// Gets or sets all the recorded error with this node
        /// </summary>
        [JsonProperty(PropertyName = "records")]
        public PathsapiV0NetworkP2pQuarantinedgetresponses200contentapplicationJsonschemaitemspropertiesrecords Records { get; set; }

        /// <summary>
        /// Gets or sets the different logged events associated to this node
        /// </summary>
        [JsonProperty(PropertyName = "logs")]
        public PathsapiV0NetworkP2pQuarantinedgetresponses200contentapplicationJsonschemaitemspropertieslogs Logs { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (Profile == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Profile");
            }
            if (Profile != null)
            {
                Profile.Validate();
            }
            if (Records != null)
            {
                Records.Validate();
            }
            if (Logs != null)
            {
                Logs.Validate();
            }
        }
    }
}
