
using System.Data.Objects;
using System.Linq;
using BusinesOperations.Interfaces;
using Camiher.Libs.Server.DAL.CamiherLocalDAL;

namespace Camiher.Libs.Server.BusinesOperations
{
    public class ProductsOperation:IProductsOperations
    {
        /// <summary>
        /// Get a product by its productID
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public ObjectSet<ProductsSet> GetProducts(string filter)
        {
            var dataDc = new Model1Container();
            return (ObjectSet<ProductsSet>) dataDc.ProductsSet.Where(filter);
        }

        /// <summary>
        /// Get a product by its productID
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public ProductsSet GetProductById(string productId)
        {
            var dataDc = new Model1Container();
            ProductsSet product = dataDc.ProductsSet.First(s => s.Id == productId);
            return product;
        }

        /// <summary>
        /// Add a product to the database
        /// </summary>
        /// <param name="product"></param>
        /// <returns>true if product store succesfully</returns>
        public bool AddProduct(ProductsSet product)
        {
            var dataDc = new Model1Container();
            dataDc.ProductsSet.AddObject(product);
            dataDc.SaveChanges();
            return true;
        }

        public bool DeleteProductById(string productId)
        {
            var dataDc = new Model1Container();
            var product = dataDc.ProductsSet.First(s => s.Id == productId);
            if (product != null)
            {
                dataDc.ProductsSet.DeleteObject(product);
                dataDc.SaveChanges();
                return true;
            }
            else
            {
                //AddLogger
                return false;
            }        
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="product"></param>
        public bool UpdateProduct(ProductsSet product)
        {
            var dataDc = new Model1Container();
            var updatedProduct = dataDc.ProductsSet.First(s => s.Id == product.Id);
            if (updatedProduct != null)
            {
                updatedProduct.Año = product.Año;
                updatedProduct.Cantidad = product.Cantidad;
                updatedProduct.Descripcion = product.Descripcion;
                updatedProduct.Enbusca = product.Enbusca;
                updatedProduct.Enventa = product.Enventa;
                updatedProduct.Hours = product.Hours;
                updatedProduct.Kilometer = product.Kilometer;
                updatedProduct.Marca = product.Marca;
                updatedProduct.Modelo = product.Modelo;
                updatedProduct.Peso = product.Peso;
                updatedProduct.Potencia = product.Potencia;
                updatedProduct.Precio = product.Precio;
                updatedProduct.PrivateDescription = product.PrivateDescription;
                updatedProduct.Producto = product.Producto;
                updatedProduct.Proveedor_ID = product.Proveedor_ID;
                dataDc.SaveChanges();
                return true;
            }
            else
            {
                //AddLogger
                return false;
            }     
        }
    }
}
