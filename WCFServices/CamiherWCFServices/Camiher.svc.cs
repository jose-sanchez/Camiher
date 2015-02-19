using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using Camiher.Libs.Server.DAL.CamiherDAL;
using Camiher.Libs.Server.BusinesOperations;
using Camiher.Libs.Server.WebServicesObjects;


namespace CamiherWCFServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    [AspNetCompatibilityRequirements(
        RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class Camiher : ICamiherService
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        #region client.axml

        /// <summary>
        /// Client buy a porduct
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="productId"></param>
        /// <param name="currentSale"></param>
        /// <returns></returns>
        public BaseResponse ClientBuyProduct(string clientId, string productId, string currentSale)
        {
            var businessOperations = new ClientsOperations();
            businessOperations.ClientBuyProduct(clientId, productId, currentSale);
            return new BaseResponse()
            {
                ErrorResponse = ResponseError.Ok
            };
        }

        /// <summary>
        /// Get current Sale
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="productId"></param>
        /// <returns></returns>
        public SaleResponse GetCurrentSale(string clientId, string productId)
        {
            var businessOperations = new ClientsOperations();
            var response = new SaleResponse()
            {
                ErrorResponse = ResponseError.Ok,
                Sale = businessOperations.GetCurrentSale(clientId, productId)

            };

            return response;
        }

        public SoldProductsResponse GetSoldProductsByClient(string clientId)
        {
            var businessOperations = new ClientsOperations();
                var response = new SoldProductsResponse()
                {
                    ErrorResponse = ResponseError.Ok,
                    Products = businessOperations.GetSoldProductsByClient(clientId)

                };
                       
            return response;
        }

        public ProductsResponse GetSoldProducts()
        {
            var businessOperations = new ClientsOperations();

                var response = new ProductsResponse()
                {
                    ErrorResponse = ResponseError.Ok,
                    Products = businessOperations.GetSoldProducts()

                };   
      
            return response;
        }

        /// <summary>
        /// Get Products from db
        /// </summary>
        /// <param name="filter">filter which product should return</param>
        /// <returns>product list filtered. If filter is not good format error</returns>
        public ProductsResponse GetProducts(string language)
        {

            var businessOperations = new ProductsOperation();
            var response = new ProductsResponse()
            {
                ErrorResponse = ResponseError.Ok,
            };

            try
            {
                response.Products = businessOperations.GetProducts(language ?? String.Empty);
            }
            catch (ArgumentException ex)
            {
                response.ErrorResponse = ResponseError.InvalidParameters;
            }
            catch (Exception ex)
            {
                response.ErrorResponse = ResponseError.Error;
            }

            return response;
        }

        /// <summary>
        /// Get Products from db
        /// </summary>
        /// <param name="filter">filter which product should return</param>
        /// <returns>product list filtered. If filter is not good format error</returns>
        public ProductsTranslationResponse GetProductsTranslations(string productId, string language)
        {

            var businessOperations = new ProductsOperation();
            var response = new ProductsTranslationResponse()
            {
                ErrorResponse = ResponseError.Ok,
            };

            try
            {
                response.ProductsTranslation = businessOperations.GetTranslation(productId, language);
            }
            catch (ArgumentException ex)
            {
                response.ErrorResponse = ResponseError.InvalidParameters;
            }
            catch (Exception ex)
            {
                response.ErrorResponse = ResponseError.Error;
            }

            return response;
        }

        /// <summary>
        /// Add a product to the database
        /// </summary>
        /// <param name="product"></param>
        /// <returns>true if product store succesfully</returns>
        public BaseResponse AddProduct(ProductsSet product, IEnumerable<ProductTranslations> translations)
        {
            var businessOperations = new ProductsOperation();
            businessOperations.AddProduct(product);

            var response = new BaseResponse()
            {
                ErrorResponse = ResponseError.Ok,
            };
            if (translations != null)
            {
                foreach (ProductTranslations pt in translations)
                {
                    businessOperations.AddProductTranslation(pt);
                }
            }

            return response;
        }


        /// <summary>
        /// Add a product to the database
        /// </summary>
        /// <param name="product"></param>
        /// <returns>true if product updated succesfully</returns>
        public BaseResponse UpdateProduct(ProductsSet product, IEnumerable<ProductTranslations> translations)
        {
            var response = new BaseResponse()
            {
                ErrorResponse = ResponseError.Ok,
            };

            try
            {
                var businessOperations = new ProductsOperation();
                businessOperations.UpdateProduct(product);
                if (translations != null)
                {
                    foreach (ProductTranslations pt in translations)
                    {
                        businessOperations.UpdateProductTranslation(product.Id, pt.Language, pt.Description);
                    }
                    
                }
            }
            catch (Exception ex)
            {
                //Addlog
                response.ErrorResponse = ResponseError.Error;
            }



            return response;
        }

        /// <summary>
        /// Delete a product to the database
        /// </summary>
        /// <param name="productId"></param>
        /// <returns>true if product store succesfully</returns>
        public BaseResponse DeleteProduct(string productId)
        {
            var businessOperations = new ProductsOperation();
            var response = new BaseResponse();
            if (businessOperations.DeleteProductById(productId))
            {
                //Delete the images associate to the product
                businessOperations.DeleteProductImages(productId);
                response.ErrorResponse = ResponseError.Ok;
            }
            else
            {
                //Improvement : perhaps add more ErrorCodes
                response.ErrorResponse = ResponseError.Error;
            }

            return response;
        }


        #endregion client.axml

        public BaseResponse AddPictureToProduct(string productId, string picture)
        {

            return new BaseResponse();
        }

        #region productImages
        public BaseResponse AddProductImage(ProductImageSet image)
        {
            var businessOperations = new ProductsOperation();
            businessOperations.AddProductImage(image);

            var response = new BaseResponse()
            {
                ErrorResponse = ResponseError.Ok,
            };

            return response;
        }

        public BaseResponse DeleteProductImages(string productId)
        {
            var businessOperations = new ProductsOperation();
            businessOperations.DeleteProductImages(productId);

            var response = new BaseResponse()
            {
                ErrorResponse = ResponseError.Ok,
            };

            return response;
        }

        public BaseResponse DeleteProductImage(string imageId)
        {
            var businessOperations = new ProductsOperation();
            businessOperations.DeleteProductImage(imageId);

            var response = new BaseResponse()
            {
                ErrorResponse = ResponseError.Ok,
            };

            return response;
        }

        public ProductsImagesResponse GetProductImages(string productId)
        {
            var businessOperations = new ProductsOperation();       

            var response = new ProductsImagesResponse()
            {
                ProductsImages = businessOperations.GetProductsImage(productId),
                ErrorResponse = ResponseError.Ok,
            };

            return response;
        }
        #endregion
    }
}
