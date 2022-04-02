using Recycle_Plastic_Blazor.HttpRepository;
using Recycle_Plastic_Blazor.Shared;
using Entities.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recycle_Plastic_Blazor.Pages
{
    public partial class CreateProduct
    {
        private Product _product = new Product();
		private SuccessNotification _notification;

		[Inject]
        public IProductHttpRepository ProductRepo { get; set; }

        private async Task Create()
        {
            await ProductRepo.CreateProduct(_product);
			_notification.Show();
		}

        private void AssignImageUrl(string imgUrl) => _product.ImageUrl = imgUrl;
    }
}
