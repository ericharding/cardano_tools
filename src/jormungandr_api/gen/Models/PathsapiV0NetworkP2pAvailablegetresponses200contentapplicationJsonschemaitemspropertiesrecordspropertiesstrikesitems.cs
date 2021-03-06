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
    /// the type of strike recorded against a node
    /// </summary>
    public partial class PathsapiV0NetworkP2pAvailablegetresponses200contentapplicationJsonschemaitemspropertiesrecordspropertiesstrikesitems
    {
        /// <summary>
        /// Initializes a new instance of the
        /// PathsapiV0NetworkP2pAvailablegetresponses200contentapplicationJsonschemaitemspropertiesrecordspropertiesstrikesitems
        /// class.
        /// </summary>
        public PathsapiV0NetworkP2pAvailablegetresponses200contentapplicationJsonschemaitemspropertiesrecordspropertiesstrikesitems()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// PathsapiV0NetworkP2pAvailablegetresponses200contentapplicationJsonschemaitemspropertiesrecordspropertiesstrikesitems
        /// class.
        /// </summary>
        /// <param name="reason">a short message describing the cause of the
        /// strike</param>
        /// <param name="when">when the strike was recorded</param>
        public PathsapiV0NetworkP2pAvailablegetresponses200contentapplicationJsonschemaitemspropertiesrecordspropertiesstrikesitems(string reason, PathsapiV0NetworkP2pAvailablegetresponses200contentapplicationJsonschemaitemspropertiesrecordspropertiesstrikesitemspropertieswhen when)
        {
            Reason = reason;
            When = when;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets a short message describing the cause of the strike
        /// </summary>
        [JsonProperty(PropertyName = "reason")]
        public string Reason { get; set; }

        /// <summary>
        /// Gets or sets when the strike was recorded
        /// </summary>
        [JsonProperty(PropertyName = "when")]
        public PathsapiV0NetworkP2pAvailablegetresponses200contentapplicationJsonschemaitemspropertiesrecordspropertiesstrikesitemspropertieswhen When { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (Reason == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Reason");
            }
            if (When == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "When");
            }
            if (When != null)
            {
                When.Validate();
            }
        }
    }
}
