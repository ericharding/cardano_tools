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

    public partial class PathsapiV0LeadersLogsgetresponses200contentapplicationJsonschemaitemspropertiesstatusoneof2propertiesinablock
    {
        /// <summary>
        /// Initializes a new instance of the
        /// PathsapiV0LeadersLogsgetresponses200contentapplicationJsonschemaitemspropertiesstatusoneof2propertiesinablock
        /// class.
        /// </summary>
        public PathsapiV0LeadersLogsgetresponses200contentapplicationJsonschemaitemspropertiesstatusoneof2propertiesinablock()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// PathsapiV0LeadersLogsgetresponses200contentapplicationJsonschemaitemspropertiesstatusoneof2propertiesinablock
        /// class.
        /// </summary>
        /// <param name="block">Block hash that has been created</param>
        /// <param name="chainLength">Block hash that has been created</param>
        public PathsapiV0LeadersLogsgetresponses200contentapplicationJsonschemaitemspropertiesstatusoneof2propertiesinablock(string block, double chainLength)
        {
            Block = block;
            ChainLength = chainLength;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets block hash that has been created
        /// </summary>
        [JsonProperty(PropertyName = "block")]
        public string Block { get; set; }

        /// <summary>
        /// Gets or sets block hash that has been created
        /// </summary>
        [JsonProperty(PropertyName = "chain_length")]
        public double ChainLength { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (Block == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Block");
            }
            if (ChainLength < 0)
            {
                throw new ValidationException(ValidationRules.InclusiveMinimum, "ChainLength", 0);
            }
        }
    }
}
