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
    /// Speed at which reward is reduced. Expressed as numerator/denominator
    /// </summary>
    public partial class PathsapiV0Settingsgetresponses200contentapplicationJsonschemapropertiesrewardparamspropertiescompoundingratio
    {
        /// <summary>
        /// Initializes a new instance of the
        /// PathsapiV0Settingsgetresponses200contentapplicationJsonschemapropertiesrewardparamspropertiescompoundingratio
        /// class.
        /// </summary>
        public PathsapiV0Settingsgetresponses200contentapplicationJsonschemapropertiesrewardparamspropertiescompoundingratio()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// PathsapiV0Settingsgetresponses200contentapplicationJsonschemapropertiesrewardparamspropertiescompoundingratio
        /// class.
        /// </summary>
        public PathsapiV0Settingsgetresponses200contentapplicationJsonschemapropertiesrewardparamspropertiescompoundingratio(int numerator, int denominator)
        {
            Numerator = numerator;
            Denominator = denominator;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "numerator")]
        public int Numerator { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "denominator")]
        public int Denominator { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (Numerator < 0)
            {
                throw new ValidationException(ValidationRules.InclusiveMinimum, "Numerator", 0);
            }
            if (Denominator < 1)
            {
                throw new ValidationException(ValidationRules.InclusiveMinimum, "Denominator", 1);
            }
        }
    }
}
