﻿using Recycle_Plastic_Blazor.Features;
using Entities.Models;
using Entities.RequestParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Recycle_Plastic_Blazor.HttpRepository
{
    public interface IProductHttpRepository
    {
        Task<PagingResponse<Product>> GetProducts(ProductParameters productParameters);
        Task CreateProduct(Product product);
        Task<string> UploadProductImage(MultipartFormDataContent content);
        Task<Product> GetProduct(string id);
        Task UpdateProduct(Product product);
        Task DeleteProduct(Guid id);
    }
}
