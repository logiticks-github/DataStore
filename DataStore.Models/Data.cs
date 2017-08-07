using Mobility.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStore.Models
{
    public class DataResult : BaseModel
    {
        public List<Item> Collection { get; set; }
    }
}
