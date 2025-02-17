using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptraxDAL.Models
{
    public abstract class ActionBase
    {
        public required int ID { get; set; }

        public required DateTimeOffset Date { get; set; }

        public required int UserID { get; set; }

        public string? Notes { get; set; }
    }

    public abstract class TransferActionBase : ActionBase
    {
        public required int OriginID { get; set; }

        public required int DestinationID { get; set; }
    }
}
