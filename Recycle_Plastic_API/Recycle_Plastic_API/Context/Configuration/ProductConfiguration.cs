using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recycle_Plastic_API.Context.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
			builder.HasData
			(
				//Mugs
				new Product
				{
					Id = new Guid("0102F709-1DD7-40DE-AF3D-23598C6BBD1F"),
					Name = "RECICLAJE CON BOTELLAS",
					materials = "Botellas de plastico y Pintura",
					ImageUrl = "http://creartekids.com/wp-content/uploads/2020/03/reci-1.jpg",
					description = "Con las botellas se pueden crear muchísimas cosas desde macetas, alcancías, contenedores para colores y pinceles, flores etc.",
					contact = "Whatsapp: 4426071163"
				},
				new Product
				{
					Id = new Guid("AC7DE2DC-049C-4328-AB06-6CDE3EBE8AA7"),
					Name = "RECICLAJE CON POPOTES",
					materials = "popotes de plasticos",
					ImageUrl = "http://creartekids.com/wp-content/uploads/2020/03/aa01c82d01becbdfefe5d052dc475461.jpg",
					description = "Los popotes tampoco deben ser tirados aquí te mostramos que pueden tener múltiples usos desde improvisadas y bonitas armónicas hasta pulseras, collares, diademas para las niñas.",
					contact = "Whatsapp: 4426071163"
				}
			);
		}
    }
}
