using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using APIPrueba.Models;

namespace APIPrueba.Models
{
    public class PaymentDetail
    {
        [Key]
        public int PaymentDetailId { get; set; }

        [Column(TypeName = "nVarchar(100)")]
        public string CardOwnerName{ get; set; }

        [Column(TypeName = "nVarchar(16)")]
        public string CardNumber { get; set; }

        [Column(TypeName = "nVarchar(5)")]
        public string ExpirationDate { get; set; }

        [Column(TypeName = "nVarchar(3)")]
        public string SecurityCode { get; set; }

    }
}
