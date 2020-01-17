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
    /// Linear fees configuration
    /// </summary>
    public partial class PathsapiV0Settingsgetresponses200contentapplicationJsonschemapropertiesfees
    {
        /// <summary>
        /// Initializes a new instance of the
        /// PathsapiV0Settingsgetresponses200contentapplicationJsonschemapropertiesfees
        /// class.
        /// </summary>
        public PathsapiV0Settingsgetresponses200contentapplicationJsonschemapropertiesfees()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// PathsapiV0Settingsgetresponses200contentapplicationJsonschemapropertiesfees
        /// class.
        /// </summary>
        /// <param name="certificate">Fee per certificate used in
        /// witness</param>
        /// <param name="coefficient">Fee per every input and output of
        /// transaction</param>
        /// <param name="constant">Base fee per transaction</param>
        /// <param name="perCertificateFees">Fee per certificate operations,
        /// all zero if this object absent</param>
        public PathsapiV0Settingsgetresponses200contentapplicationJsonschemapropertiesfees(int certificate, int coefficient, int constant, Get200ApplicationJsonPropertiesProperties perCertificateFees = default(Get200ApplicationJsonPropertiesProperties))
        {
            Certificate = certificate;
            PerCertificateFees = perCertificateFees;
            Coefficient = coefficient;
            Constant = constant;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets fee per certificate used in witness
        /// </summary>
        [JsonProperty(PropertyName = "certificate")]
        public int Certificate { get; set; }

        /// <summary>
        /// Gets or sets fee per certificate operations, all zero if this
        /// object absent
        /// </summary>
        [JsonProperty(PropertyName = "per_certificate_fees")]
        public Get200ApplicationJsonPropertiesProperties PerCertificateFees { get; set; }

        /// <summary>
        /// Gets or sets fee per every input and output of transaction
        /// </summary>
        [JsonProperty(PropertyName = "coefficient")]
        public int Coefficient { get; set; }

        /// <summary>
        /// Gets or sets base fee per transaction
        /// </summary>
        [JsonProperty(PropertyName = "constant")]
        public int Constant { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (Certificate < 0)
            {
                throw new ValidationException(ValidationRules.InclusiveMinimum, "Certificate", 0);
            }
            if (PerCertificateFees != null)
            {
                PerCertificateFees.Validate();
            }
            if (Coefficient < 0)
            {
                throw new ValidationException(ValidationRules.InclusiveMinimum, "Coefficient", 0);
            }
            if (Constant < 0)
            {
                throw new ValidationException(ValidationRules.InclusiveMinimum, "Constant", 0);
            }
        }
    }
}
