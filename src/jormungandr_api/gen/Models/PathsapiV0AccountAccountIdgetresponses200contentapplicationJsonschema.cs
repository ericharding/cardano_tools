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

    public partial class PathsapiV0AccountAccountIdgetresponses200contentapplicationJsonschema
    {
        /// <summary>
        /// Initializes a new instance of the
        /// PathsapiV0AccountAccountIdgetresponses200contentapplicationJsonschema
        /// class.
        /// </summary>
        public PathsapiV0AccountAccountIdgetresponses200contentapplicationJsonschema()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// PathsapiV0AccountAccountIdgetresponses200contentapplicationJsonschema
        /// class.
        /// </summary>
        /// <param name="value">Current balance of this account</param>
        /// <param name="counter">Number of transactions performed with this
        /// account</param>
        /// <param name="delegation">Hex-encoded stake pool ID this account is
        /// delegating to</param>
        /// <param name="lastRewards">the last rewards</param>
        public PathsapiV0AccountAccountIdgetresponses200contentapplicationJsonschema(int value, int counter, string delegation = default(string), PathsapiV0AccountAccountIdgetresponses200contentapplicationJsonschemapropertieslastRewards lastRewards = default(PathsapiV0AccountAccountIdgetresponses200contentapplicationJsonschemapropertieslastRewards))
        {
            Delegation = delegation;
            Value = value;
            Counter = counter;
            LastRewards = lastRewards;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets hex-encoded stake pool ID this account is delegating
        /// to
        /// </summary>
        [JsonProperty(PropertyName = "delegation")]
        public string Delegation { get; set; }

        /// <summary>
        /// Gets or sets current balance of this account
        /// </summary>
        [JsonProperty(PropertyName = "value")]
        public int Value { get; set; }

        /// <summary>
        /// Gets or sets number of transactions performed with this account
        /// </summary>
        [JsonProperty(PropertyName = "counter")]
        public int Counter { get; set; }

        /// <summary>
        /// Gets or sets the last rewards
        /// </summary>
        [JsonProperty(PropertyName = "last_rewards")]
        public PathsapiV0AccountAccountIdgetresponses200contentapplicationJsonschemapropertieslastRewards LastRewards { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (Value < 0)
            {
                throw new ValidationException(ValidationRules.InclusiveMinimum, "Value", 0);
            }
            if (Counter < 0)
            {
                throw new ValidationException(ValidationRules.InclusiveMinimum, "Counter", 0);
            }
            if (LastRewards != null)
            {
                LastRewards.Validate();
            }
        }
    }
}
