using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Domain.Models
{
    internal class ModelException : Exception
    {
        public ModelException(string message) : base(message)
        {

        }
    }
}
