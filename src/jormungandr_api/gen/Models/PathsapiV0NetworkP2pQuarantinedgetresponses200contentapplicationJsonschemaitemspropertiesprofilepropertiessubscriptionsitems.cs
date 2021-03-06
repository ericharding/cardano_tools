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
    /// a subscription
    /// </summary>
    public partial class PathsapiV0NetworkP2pQuarantinedgetresponses200contentapplicationJsonschemaitemspropertiesprofilepropertiessubscriptionsitems
    {
        /// <summary>
        /// Initializes a new instance of the
        /// PathsapiV0NetworkP2pQuarantinedgetresponses200contentapplicationJsonschemaitemspropertiesprofilepropertiessubscriptionsitems
        /// class.
        /// </summary>
        public PathsapiV0NetworkP2pQuarantinedgetresponses200contentapplicationJsonschemaitemspropertiesprofilepropertiessubscriptionsitems()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// PathsapiV0NetworkP2pQuarantinedgetresponses200contentapplicationJsonschemaitemspropertiesprofilepropertiessubscriptionsitems
        /// class.
        /// </summary>
        /// <param name="interest">the level of interest on the associate
        /// subscription. Possible values include: 'High', 'Normal',
        /// 'Low'</param>
        /// <param name="topic">0 for fragment topic and 1 for a block
        /// topic</param>
        public PathsapiV0NetworkP2pQuarantinedgetresponses200contentapplicationJsonschemaitemspropertiesprofilepropertiessubscriptionsitems(string interest, int topic)
        {
            Interest = interest;
            Topic = topic;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets the level of interest on the associate subscription.
        /// Possible values include: 'High', 'Normal', 'Low'
        /// </summary>
        [JsonProperty(PropertyName = "interest")]
        public string Interest { get; set; }

        /// <summary>
        /// Gets or sets 0 for fragment topic and 1 for a block topic
        /// </summary>
        [JsonProperty(PropertyName = "topic")]
        public int Topic { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (Interest == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Interest");
            }
        }
    }
}
