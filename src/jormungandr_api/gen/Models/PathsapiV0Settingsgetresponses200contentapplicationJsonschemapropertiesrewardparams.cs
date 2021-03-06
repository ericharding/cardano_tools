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
    /// Parameters for rewards calculation
    /// </summary>
    public partial class PathsapiV0Settingsgetresponses200contentapplicationJsonschemapropertiesrewardparams
    {
        /// <summary>
        /// Initializes a new instance of the
        /// PathsapiV0Settingsgetresponses200contentapplicationJsonschemapropertiesrewardparams
        /// class.
        /// </summary>
        public PathsapiV0Settingsgetresponses200contentapplicationJsonschemapropertiesrewardparams()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// PathsapiV0Settingsgetresponses200contentapplicationJsonschemapropertiesrewardparams
        /// class.
        /// </summary>
        /// <param name="compoundingRatio">Speed at which reward is reduced.
        /// Expressed as numerator/denominator</param>
        /// <param name="compoundingType">Reward reduction algorithm. Possible
        /// values include: 'Linear', 'Halvening'</param>
        /// <param name="epochRate">Number of epochs between reward</param>
        /// <param name="epochStart">Epoch when rewarding starts</param>
        /// <param name="initialValue">Initial reward</param>
        public PathsapiV0Settingsgetresponses200contentapplicationJsonschemapropertiesrewardparams(PathsapiV0Settingsgetresponses200contentapplicationJsonschemapropertiesrewardparamspropertiescompoundingratio compoundingRatio, string compoundingType, int epochRate, int epochStart, int initialValue)
        {
            CompoundingRatio = compoundingRatio;
            CompoundingType = compoundingType;
            EpochRate = epochRate;
            EpochStart = epochStart;
            InitialValue = initialValue;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets speed at which reward is reduced. Expressed as
        /// numerator/denominator
        /// </summary>
        [JsonProperty(PropertyName = "compoundingRatio")]
        public PathsapiV0Settingsgetresponses200contentapplicationJsonschemapropertiesrewardparamspropertiescompoundingratio CompoundingRatio { get; set; }

        /// <summary>
        /// Gets or sets reward reduction algorithm. Possible values include:
        /// 'Linear', 'Halvening'
        /// </summary>
        [JsonProperty(PropertyName = "compoundingType")]
        public string CompoundingType { get; set; }

        /// <summary>
        /// Gets or sets number of epochs between reward
        /// </summary>
        [JsonProperty(PropertyName = "epochRate")]
        public int EpochRate { get; set; }

        /// <summary>
        /// Gets or sets epoch when rewarding starts
        /// </summary>
        [JsonProperty(PropertyName = "epochStart")]
        public int EpochStart { get; set; }

        /// <summary>
        /// Gets or sets initial reward
        /// </summary>
        [JsonProperty(PropertyName = "initialValue")]
        public int InitialValue { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (CompoundingRatio == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "CompoundingRatio");
            }
            if (CompoundingType == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "CompoundingType");
            }
            if (CompoundingRatio != null)
            {
                CompoundingRatio.Validate();
            }
            if (EpochRate < 1)
            {
                throw new ValidationException(ValidationRules.InclusiveMinimum, "EpochRate", 1);
            }
            if (EpochStart < 0)
            {
                throw new ValidationException(ValidationRules.InclusiveMinimum, "EpochStart", 0);
            }
            if (InitialValue < 0)
            {
                throw new ValidationException(ValidationRules.InclusiveMinimum, "InitialValue", 0);
            }
        }
    }
}
