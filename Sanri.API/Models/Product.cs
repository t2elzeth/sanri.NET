using System.ComponentModel.DataAnnotations;
using System.Data;
using FluentValidation;
using Sanri.API.Validation;

namespace Sanri.API.Models
{
    public class Product
    {
        public virtual long Id { get; set; }

        public virtual string Name { get; set; } = null!;

        public virtual Price Price { get; set; } = null!;
    }
}