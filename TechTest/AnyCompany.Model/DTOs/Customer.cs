using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AnyCompany.Model.DTOs
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class Customer
    {
        /// <summary>
        /// customer country of birth
        /// </summary>
        [DataMember(Name = "Country")]
        public string Country { get; set; }

        /// <summary>
        /// customer date of birth
        /// </summary>
        [DataMember(Name = "DateOfBirth")]
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// customer name
        /// </summary>
        [DataMember(Name = "Name")]
        public string Name { get; set; }
    }
}
