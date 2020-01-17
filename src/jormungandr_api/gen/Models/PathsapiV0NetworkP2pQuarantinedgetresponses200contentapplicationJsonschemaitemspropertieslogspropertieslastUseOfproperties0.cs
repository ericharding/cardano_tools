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
    /// the last time the node was selected for fragment propagation
    /// </summary>
    public partial class PathsapiV0NetworkP2pQuarantinedgetresponses200contentapplicationJsonschemaitemspropertieslogspropertieslastUseOfproperties0
    {
        /// <summary>
        /// Initializes a new instance of the
        /// PathsapiV0NetworkP2pQuarantinedgetresponses200contentapplicationJsonschemaitemspropertieslogspropertieslastUseOfproperties0
        /// class.
        /// </summary>
        public PathsapiV0NetworkP2pQuarantinedgetresponses200contentapplicationJsonschemaitemspropertieslogspropertieslastUseOfproperties0()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// PathsapiV0NetworkP2pQuarantinedgetresponses200contentapplicationJsonschemaitemspropertieslogspropertieslastUseOfproperties0
        /// class.
        /// </summary>
        /// <param name="secondsSinceEpoch">seconds since unix epoch</param>
        /// <param name="nanosSinceEpoch">elapsed nanoseconds since unix
        /// epoch</param>
        public PathsapiV0NetworkP2pQuarantinedgetresponses200contentapplicationJsonschemaitemspropertieslogspropertieslastUseOfproperties0(int secondsSinceEpoch, int nanosSinceEpoch)
        {
            SecondsSinceEpoch = secondsSinceEpoch;
            NanosSinceEpoch = nanosSinceEpoch;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets seconds since unix epoch
        /// </summary>
        [JsonProperty(PropertyName = "seconds_since_epoch")]
        public int SecondsSinceEpoch { get; set; }

        /// <summary>
        /// Gets or sets elapsed nanoseconds since unix epoch
        /// </summary>
        [JsonProperty(PropertyName = "nanos_since_epoch")]
        public int NanosSinceEpoch { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (SecondsSinceEpoch < 0)
            {
                throw new ValidationException(ValidationRules.InclusiveMinimum, "SecondsSinceEpoch", 0);
            }
            if (NanosSinceEpoch < 0)
            {
                throw new ValidationException(ValidationRules.InclusiveMinimum, "NanosSinceEpoch", 0);
            }
        }
    }
}
