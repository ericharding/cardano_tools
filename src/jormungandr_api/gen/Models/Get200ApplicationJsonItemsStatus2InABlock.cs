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

    public partial class Get200ApplicationJsonItemsStatus2InABlock
    {
        /// <summary>
        /// Initializes a new instance of the
        /// Get200ApplicationJsonItemsStatus2InABlock class.
        /// </summary>
        public Get200ApplicationJsonItemsStatus2InABlock()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// Get200ApplicationJsonItemsStatus2InABlock class.
        /// </summary>
        /// <param name="date">Epoch and slot ID of block containing fragment
        /// separated with a dot</param>
        /// <param name="block">Block hash where the fragment was last
        /// seen</param>
        public Get200ApplicationJsonItemsStatus2InABlock(string date, string block)
        {
            Date = date;
            Block = block;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets epoch and slot ID of block containing fragment
        /// separated with a dot
        /// </summary>
        [JsonProperty(PropertyName = "date")]
        public string Date { get; set; }

        /// <summary>
        /// Gets or sets block hash where the fragment was last seen
        /// </summary>
        [JsonProperty(PropertyName = "block")]
        public string Block { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (Date == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Date");
            }
            if (Block == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Block");
            }
        }
    }
}
