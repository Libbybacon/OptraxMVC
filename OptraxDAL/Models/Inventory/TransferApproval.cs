﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OptraxDAL.Models.Admin;

namespace OptraxDAL.Models.Inventory
{
    public class TransferApproval
    {
        public int ID { get; set; }

        [ForeignKey("Transfer")]
        public int TransferID { get; set; }

        public DateTimeOffset ApprovalDate { get; set; }

        [Required]
        [MaxLength(450)]
        [ForeignKey("Manager")]
        [Display(Name = "Approving Manager")]
        public string ManagerID { get; set; } = string.Empty;

        public string? Notes { get; set; }

        public virtual required AppUser Manager { get; set; }
        public virtual required InventoryTransfer Transfer { get; set; }
    }
}
