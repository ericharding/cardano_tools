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

    public partial class PathsapiV0LeadersLogsgetresponses200contentapplicationJsonschemaitemspropertiesstatusoneof1propertiesrejected
    {
        /// <summary>
        /// Initializes a new instance of the
        /// PathsapiV0LeadersLogsgetresponses200contentapplicationJsonschemaitemspropertiesstatusoneof1propertiesrejected
        /// class.
        /// </summary>
        public PathsapiV0LeadersLogsgetresponses200contentapplicationJsonschemaitemspropertiesstatusoneof1propertiesrejected()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// PathsapiV0LeadersLogsgetresponses200contentapplicationJsonschemaitemspropertiesstatusoneof1propertiesrejected
        /// class.
        /// </summary>
        /// <param name="reason">Reason for rejection</param>
        public PathsapiV0LeadersLogsgetresponses200contentapplicationJsonschemaitemspropertiesstatusoneof1propertiesrejected(string reason)
        {
            Reason = reason;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets reason for rejection
        /// </summary>
        [JsonProperty(PropertyName = "reason")]
        public string Reason { get; set; }

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
        }
    }
}
