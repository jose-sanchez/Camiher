
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Objects;
using System.Linq;
using System.Linq.Expressions;
using BusinesOperations.Interfaces;
using Camiher.Libs.Common;
using Camiher.Libs.Server.DAL.CamiherDAL;

namespace Camiher.Libs.Server.BusinesOperations
{
    public class ProductsOperation : IProductsOperations
    {
        private readonly UnitOfWork _camiherUnitOfWork = new UnitOfWork();

        public ProductsOperation()
        {
        }
        #region translations

        /// <summary>
        /// Get a  translation for the product for a specific language
        /// </summary>
        /// <returns></returns>
        public ProductTranslations GetTranslation(string productID, string language)
        {
            return
                _camiherUnitOfWork.ProductTranslationsRepository.Get()
                    .First(s => s.Product == productID && s.Language == language);
        }

        /// <summary>
        /// Get a  translation for the product for a specific language
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ProductTranslations> GetProductsTranslation( string language)
        {
            return
                _camiherUnitOfWork.ProductTranslationsRepository.Get()
                    .Where(s => s.Language == language);
        }

        /// <summary>
        /// Add a product to the database
        /// </summary>
        /// <param name="translation"></param>
        /// <returns>true if product store succesfully</returns>
        public bool AddProductTranslation(ProductTranslations translation)
        {
            _camiherUnitOfWork.ProductTranslationsRepository.Insert(translation);
            _camiherUnitOfWork.Save();
            return true;
        }

        public bool DeleteProductTranslation(string productId, string language)
        {
            var product =
                _camiherUnitOfWork.ProductTranslationsRepository.Get()
                    .First(s => s.Product == productId && s.Language == language);

            if (product != null)
            {
                _camiherUnitOfWork.ProductTranslationsRepository.Delete(product);
                _camiherUnitOfWork.Save();
                return true;
            }
            else
            {
                //AddLogger
                return false;
            }
        }

        public bool DeleteProductTranslation(string productId)
        {
            var product = _camiherUnitOfWork.ProductTranslationsRepository.Get().Where(s => s.Product == productId);

            if (product != null)
            {
                _camiherUnitOfWork.ProductTranslationsRepository.Delete(product);
                _camiherUnitOfWork.Save();
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
        public bool UpdateProductTranslation(String productId, string language, string translation)
        {
            var updatedProductTranslation =
                _camiherUnitOfWork.ProductTranslationsRepository.Get()
                    .FirstOrDefault(s => s.Product == productId && s.Language == language);
            if (updatedProductTranslation != null)
            {
                updatedProductTranslation.Description = translation;

                _camiherUnitOfWork.ProductTranslationsRepository.Update(updatedProductTranslation);
                _camiherUnitOfWork.Save();
                return true;
            }
            else
            {
                var newTranslation = new ProductTranslations();
                newTranslation.Product = productId;
                newTranslation.Description = translation;
                newTranslation.Language = language;
                newTranslation.Id = new Ramdom().RandomString(8);
                _camiherUnitOfWork.ProductTranslationsRepository.Insert(newTranslation);
                _camiherUnitOfWork.Save();
                //AddLogger
                return false;
            }
        }
        #endregion
        #region ProductsImages

        /// <summary>
        /// Get a product by its productID
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public IEnumerable<ProductImageSet> GetProductsImage(string productID)
        {
            return _camiherUnitOfWork.ProductImageRepository.Get().Where(s => s.ProductID == productID);

        }


        /// <summary>
        /// Add a product to the database
        /// </summary>
        /// <param name="product"></param>
        /// <returns>true if product store succesfully</returns>
        public bool AddProductImage(ProductImageSet product)
        {
            _camiherUnitOfWork.ProductImageRepository.Insert(product);
            _camiherUnitOfWork.Save();
            return true;
        }

        public bool DeleteProductImages(string productId)
        {
            var images = _camiherUnitOfWork.ProductImageRepository.Get().Where(s => s.ProductID == productId);
            foreach (ProductImageSet image in images)
            {
                _camiherUnitOfWork.ProductImageRepository.Delete(image);
                _camiherUnitOfWork.Save();
            }
            return true;

        }
        public Boolean DeleteProductImage(string imageId)
        {
            var image = _camiherUnitOfWork.ProductImageRepository.GetByID(imageId);
                _camiherUnitOfWork.ProductImageRepository.Delete(image);
                _camiherUnitOfWork.Save();
            
            return true;
        }

        #endregion

        #region Products

        /// <summary>
        /// Get a product by its productID
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public IEnumerable<ProductsSet> GetProducts(string language)
        {
            if (!String.IsNullOrEmpty(language))
            {
                var products = from p in _camiherUnitOfWork.ProductRepository.Get()
                    join t in _camiherUnitOfWork.ProductTranslationsRepository.Get().Where(s=>s.Language == language) 
                               on p.Id equals t.Product

                    select new ProductsSet()
                    {
                        Peso = p.Peso,
                        Año = p.Año,
                        Cantidad = p.Cantidad,
                        Descripcion = t.Description,
                        Enbusca = p.Enbusca,
                        Enventa = p.Enventa,
                        Hours = p.Hours,
                        Id = p.Id,
                        Kilometer = p.Kilometer,
                        Marca = p.Marca,
                        Modelo = p.Modelo,
                        Potencia = p.Potencia,
                        Precio = p.Precio,
                        PrivateDescription = p.PrivateDescription,
                        Producto = p.Producto,
                        Proveedor_ID = p.Proveedor_ID

                    };
                return products;
            }
            return _camiherUnitOfWork.ProductRepository.Get();


        }

        /// <summary>
        /// Get a product by its productID
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public ProductsSet GetProductById(string productId)
        {
            ProductsSet product = _camiherUnitOfWork.ProductRepository.GetByID(productId);
            return product;
        }

        /// <summary>
        /// Add a product to the database
        /// </summary>
        /// <param name="product"></param>
        /// <returns>true if product store succesfully</returns>
        public bool AddProduct(ProductsSet product)
        {
            _camiherUnitOfWork.ProductRepository.Insert(product);
            _camiherUnitOfWork.Save();
            return true;
        }

        public bool DeleteProductById(string productId)
        {
            var product = _camiherUnitOfWork.ProductRepository.GetByID(productId);
            if (product != null)
            {
                _camiherUnitOfWork.ProductRepository.Delete(product);
                _camiherUnitOfWork.Save();
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
            var updatedProduct = _camiherUnitOfWork.ProductRepository.GetByID(product.Id);
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
                _camiherUnitOfWork.ProductRepository.Update(updatedProduct);
                _camiherUnitOfWork.Save();
                return true;
            }
            else
            {
                //AddLogger
                return false;
            }

        #endregion
        }
    }
}
