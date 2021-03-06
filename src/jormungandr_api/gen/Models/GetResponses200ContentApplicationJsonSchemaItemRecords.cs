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
    public partial class GetResponses200ContentApplicationJsonSchemaItemRecords
    {
        /// <summary>
        /// Initializes a new instance of the
        /// GetResponses200ContentApplicationJsonSchemaItemRecords class.
        /// </summary>
        public GetResponses200ContentApplicationJsonSchemaItemRecords()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// GetResponses200ContentApplicationJsonSchemaItemRecords class.
        /// </summary>
        /// <param name="strikes">the strikes recorded on this node</param>
        public GetResponses200ContentApplicationJsonSchemaItemRecords(IList<Get200ApplicationJsonItemsRecordsStrikesItem> strikes)
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
        public IList<Get200ApplicationJsonItemsRecordsStrikesItem> Strikes { get; set; }

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
