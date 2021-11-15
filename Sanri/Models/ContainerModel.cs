using System;

namespace Sanri.Models
{
    public class ContainerModel
    {
        public virtual long Id { get; set; }
        public virtual string Name { get; set; }
        public virtual DateTime DateOfSending { get; set; }
        public virtual UserModel Client { get; set; }
    }
}