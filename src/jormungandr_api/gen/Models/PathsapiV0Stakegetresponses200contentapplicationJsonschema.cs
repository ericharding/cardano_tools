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

    public partial class PathsapiV0Stakegetresponses200contentapplicationJsonschema
    {
        /// <summary>
        /// Initializes a new instance of the
        /// PathsapiV0Stakegetresponses200contentapplicationJsonschema class.
        /// </summary>
        public PathsapiV0Stakegetresponses200contentapplicationJsonschema()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// PathsapiV0Stakegetresponses200contentapplicationJsonschema class.
        /// </summary>
        /// <param name="epoch">Epoch of last block</param>
        /// <param name="stake">Stake state, present only if there is
        /// leadership and it works with Genesis Praos consensus</param>
        public PathsapiV0Stakegetresponses200contentapplicationJsonschema(int epoch, PathsapiV0Stakegetresponses200contentapplicationJsonschemapropertiesstake stake = default(PathsapiV0Stakegetresponses200contentapplicationJsonschemapropertiesstake))
        {
            Epoch = epoch;
            Stake = stake;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets epoch of last block
        /// </summary>
        [JsonProperty(PropertyName = "epoch")]
        public int Epoch { get; set; }

        /// <summary>
        /// Gets or sets stake state, present only if there is leadership and
        /// it works with Genesis Praos consensus
        /// </summary>
        [JsonProperty(PropertyName = "stake")]
        public PathsapiV0Stakegetresponses200contentapplicationJsonschemapropertiesstake Stake { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (Epoch < 0)
            {
                throw new ValidationException(ValidationRules.InclusiveMinimum, "Epoch", 0);
            }
            if (Stake != null)
            {
                Stake.Validate();
            }
        }
    }
}
