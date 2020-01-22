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
    /// the node public info
    /// </summary>
    public partial class Get200ApplicationJsonItemsProfileInfo
    {
        /// <summary>
        /// Initializes a new instance of the
        /// Get200ApplicationJsonItemsProfileInfo class.
        /// </summary>
        public Get200ApplicationJsonItemsProfileInfo()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// Get200ApplicationJsonItemsProfileInfo class.
        /// </summary>
        /// <param name="id">the node public id</param>
        /// <param name="address">the multi-address of the node</param>
        public Get200ApplicationJsonItemsProfileInfo(string id, string address = default(string))
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
            if (Id == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Id");
            }
        }
    }
}