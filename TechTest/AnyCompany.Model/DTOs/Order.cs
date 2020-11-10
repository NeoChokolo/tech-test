using System.Runtime.Serialization;

namespace AnyCompany.Model.DTOs
{

    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class Order
    {
        /// <summary>
        /// Order Id
        /// </summary>
        [DataMember(Name = "OrderId")]
        public int OrderId { get; set; }

        /// <summary>
        /// Order amount
        /// </summary>
        [DataMember(Name = "Amount")]
        public double Amount { get; set; }

        /// <summary>
        /// Order vat
        /// </summary>
        [DataMember(Name = "VAT")]
        public double VAT { get; set; }
    }
}
