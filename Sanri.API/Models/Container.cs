using System;

namespace Sanri.API.Models
{
    public class Container
    {
        public virtual long Id { get; set; }
        public virtual string Name { get; set; }
        public virtual DateTime DateOfSending { get; set; }
        public virtual User Client { get; set; }
    }
}