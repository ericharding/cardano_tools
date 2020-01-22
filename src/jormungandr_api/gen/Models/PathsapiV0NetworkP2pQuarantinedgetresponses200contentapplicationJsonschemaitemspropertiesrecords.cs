// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Jormungandr.Models
{
    using Microsoft.Rest;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// all the recorded error with this node
    /// </summary>
    public partial class PathsapiV0NetworkP2pQuarantinedgetresponses200contentapplicationJsonschemaitemspropertiesrecords
    {
        /// <summary>
        /// Initializes a new instance of the
        /// PathsapiV0NetworkP2pQuarantinedgetresponses200contentapplicationJsonschemaitemspropertiesrecords
        /// class.
        /// </summary>
        public PathsapiV0NetworkP2pQuarantinedgetresponses200contentapplicationJsonschemaitemspropertiesrecords()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// PathsapiV0NetworkP2pQuarantinedgetresponses200contentapplicationJsonschemaitemspropertiesrecords
        /// class.
        /// </summary>
        /// <param name="strikes">the strikes recorded on this node</param>
        public PathsapiV0NetworkP2pQuarantinedgetresponses200contentapplicationJsonschemaitemspropertiesrecords(IList<PathsapiV0NetworkP2pQuarantinedgetresponses200contentapplicationJsonschemaitemspropertiesrecordspropertiesstrikesitems> strikes)
        {
            Strikes = strikes;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets the strikes recorded on this node
        /// </summary>
        [JsonProperty(PropertyName = "strikes")]
        public IList<PathsapiV0NetworkP2pQuarantinedgetresponses200contentapplicationJsonschemaitemspropertiesrecordspropertiesstrikesitems> Strikes { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (Strikes == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Strikes");
            }
            if (Strikes != null)
            {
                foreach (var element in Strikes)
                {
                    if (element != null)
                    {
                        element.Validate();
                    }
                }
            }
        }
    }
}