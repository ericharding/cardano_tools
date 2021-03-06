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
    /// a node id and addresses
    /// </summary>
    public partial class PathsapiV0NetworkP2pViewTopicgetresponses200contentapplicationJsonschemaitems
    {
        /// <summary>
        /// Initializes a new instance of the
        /// PathsapiV0NetworkP2pViewTopicgetresponses200contentapplicationJsonschemaitems
        /// class.
        /// </summary>
        public PathsapiV0NetworkP2pViewTopicgetresponses200contentapplicationJsonschemaitems()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// PathsapiV0NetworkP2pViewTopicgetresponses200contentapplicationJsonschemaitems
        /// class.
        /// </summary>
        /// <param name="address">the multi-address of the node</param>
        /// <param name="id">the node public id</param>
        public PathsapiV0NetworkP2pViewTopicgetresponses200contentapplicationJsonschemaitems(string address, string id)
        {
            Address = address;
            Id = id;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets the multi-address of the node
        /// </summary>
        [JsonProperty(PropertyName = "address")]
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the node public id
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (Address == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Address");
            }
            if (Id == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Id");
            }
        }
    }
}
