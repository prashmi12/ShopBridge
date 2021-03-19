using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using AutoMapper;
using DataAccessLayer;
using LiteDB;

namespace ShopBridge.Controllers
{
    [Route("api/[controller]")]
    public class ShopController : ApiController
    {
        // GET: Shop 
        [HttpGet]
        public JsonResult<List<Models.ProductDetails>> GetAllProducts()
        {

                //EntityMapper<Models.ProductDetails> mapObj = new EntityMapper<DataAccessLayer.Product, Models.ProductDetails>();
                List<DataAccessLayer.Product> prodList = DAL.GetAllProducts();
                List<Models.ProductDetails> products = new List<Models.ProductDetails>();
                var config = new MapperConfiguration(cfg => cfg.CreateMap<Product, Models.ProductDetails>());
                var mapper = new Mapper(config);
                foreach (var item in prodList)
                {
                    products.Add(mapper.Map<Models.ProductDetails>(item));
                }
                return Json<List<Models.ProductDetails>>(products);
            
        }
        [HttpGet]
        public JsonResult<Models.ProductDetails> GetProduct(int id)
        {
            //EntityMapper<DataAccessLayer.Product, Models.ProductDetails> mapObj = new EntityMapper<DataAccessLayer.Product, Models.ProductDetails>();
            DataAccessLayer.Product dalProduct = DAL.GetProduct(id);
            if(dalProduct == null)
            {
                //return Json<Models.ProductDetails>(null);
                throw new ArgumentNullException(id.ToString());
            }
            else
            {
                Models.ProductDetails products = new Models.ProductDetails();
                var config = new MapperConfiguration(cfg => cfg.CreateMap<Product, Models.ProductDetails>());
                var mapper = new Mapper(config);
                products = mapper.Map<Models.ProductDetails>(dalProduct);
                return Json<Models.ProductDetails>(products);
            }
            
        }
        [HttpPost]
        public bool InsertProduct(Models.ProductDetails product)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                //EntityMapper<Models.ProductDetails, DataAccessLayer.Product> mapObj = new EntityMapper<Models.ProductDetails, DataAccessLayer.Product>();
                DataAccessLayer.Product productObj = new DataAccessLayer.Product();
                var config = new MapperConfiguration(cfg => cfg.CreateMap<Models.ProductDetails, Product>());
                var mapper = new Mapper(config);
                productObj = mapper.Map<Product>(product);
                status = DAL.InsertProduct(productObj);
            }
            return status;
        }
        [HttpPut]
        public bool UpdateProduct(Models.ProductDetails product)
        {
            //EntityMapper<Models.ProductDetails, DataAccessLayer.Product> mapObj = new EntityMapper<Models.ProductDetails, DataAccessLayer.Product>();
            DataAccessLayer.Product productObj = new DataAccessLayer.Product();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Models.ProductDetails, Product>());
            var mapper = new Mapper(config);
            productObj = mapper.Map<Product>(product);
            var status = DAL.UpdateProduct(productObj);
            return status;
        }
        [HttpDelete]
        public bool DeleteProduct(int id)
        {
            var status = DAL.DeleteProduct(id);
            return status;
        }
    }
}