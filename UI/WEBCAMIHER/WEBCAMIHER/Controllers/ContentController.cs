using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using WEBCAMIHER.Models;
using WEBCAMIHER.Handlers;

namespace WEBCAMIHER.Controllers
{
    public class ContentController : Controller
    {
        //
        // GET: /Content/
        private UnitOfWork unitOfWork = new UnitOfWork();
        public ActionResult Index()
        {
            ViewBag.PageList = new SelectList(unitOfWork.pages);
            string initialpage = unitOfWork.pages[0];
            return View(unitOfWork.ContentRepository.Get(S => S.Section.Contains(initialpage)));                                  
        }

        public JsonResult GetContent(String section)
        {
            
            //foreach (Content c in CM.getContents(section))
            //{
            //    StringBuilder SB = new StringBuilder();
            //    // Set div id and class
            //    SB.Append("<div id=\"");
            //    SB.Append(c.Id);
            //    SB.Append("\" class=\"");
            //    SB.Append(c.Class);
            //    SB.Append("\">");
            //    // Set title and text

            //    SB.Append("<h2>");
            //    SB.Append(c.Title);
            //    SB.Append("</h2>");
            //    //Set Text
            //    SB.Append("<p>");
            //    SB.Append(c.Text);
            //    SB.Append("</p>");
            //    SB.Append("</div>");
            //}
            var sb = new StringBuilder();
            foreach (Content c in unitOfWork.ContentRepository.Get().Where(S => S.Section.Contains(section)).OrderBy(S => S.Order).ToList())
            {

                sb.Append("<div id=\"");
                sb.Append(c.Id);
                sb.Append("\" class=\"");
                sb.Append(c.Class);
                sb.Append("\">");
                // Set title and text

                sb.Append("Titulo:<br><input disabled type=\"text\" name=\"title\" value=\"");
                sb.Append(c.Title);
                sb.Append("\"></input><br>");
                //Set Text
                sb.Append("Texto:<br><input disabled type=\"text\" name=\"text\" value=\"");
                sb.Append(c.Text);
                sb.Append("\"></input><br>");
                
                //Edit content button
                sb.Append("<button type=\"button\" value=\"Edit\" >Editar</button>");
                sb.Append("<button type=\"button\" value=\"Images\" hidden >Imagenes</button>");
                sb.Append("<button type=\"button\" value=\"Delete\"  >Borrar</button>");
                sb.Append("<button type=\"button\" value=\"Subir\"  >Subir</button>");
                sb.Append("<button type=\"button\" value=\"Bajar\"  >Bajar</button>");
                sb.Append("</div>");
            }


            return Json(sb.ToString(), JsonRequestBehavior.AllowGet);

        }
        public JsonResult EditContent(string editedcontent)
        {

            var serializer = new JavaScriptSerializer();
            //IContentRepository repository = new ContentModel();
            try
            {
                dynamic jsoncoor = serializer.Deserialize<object>(editedcontent);
                //repository.AmendContent(jsoncoor["Section"], jsoncoor["Title"], jsoncoor["Text"]);
                Content ContentToUpdate = unitOfWork.ContentRepository.GetByID(jsoncoor["Section"]);
                ContentToUpdate.Title = jsoncoor["Title"];
                ContentToUpdate.Text = jsoncoor["Text"];
                unitOfWork.ContentRepository.Update(ContentToUpdate);
                unitOfWork.Save();

                return Json(true);

            }
            catch (Exception)
            {
                return Json(false);
            }
        }

        /// <summary>
        /// Decrease parraf order in the page
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public JsonResult DecreaseOrderContent(string content)
        {
            try
            {
                Content decreasedContent = unitOfWork.ContentRepository.GetByID(content);
                if (decreasedContent.Order > 0)
                {
                    Content cont = unitOfWork.ContentRepository.Get(S => S.Order == decreasedContent.Order + 1).First();
                
                    cont.Order++;
                    decreasedContent.Order--;               
                    unitOfWork.Save();
                }
                return Json(true);

            }
            catch (Exception)
            {
                return Json(false);
            }
        }

        /// <summary>
        /// Increase the order of the parraf in the page
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public JsonResult IncreaseOrderContent(string content)
        {
            try
            {
                Content increasedContent = unitOfWork.ContentRepository.GetByID(content);
                if (increasedContent.Order < unitOfWork.ContentRepository.Get().Count())
                {
                    Content cont = unitOfWork.ContentRepository.Get(S => S.Order == increasedContent.Order - 1).First();

                    cont.Order--;
                    increasedContent.Order++;
                    unitOfWork.Save();
                }
                return Json(true);

            }
            catch (Exception)
            {
                return Json(false);
            }
        }

        /// <summary>
        /// Add new parraf to the page
        /// </summary>
        /// <param name="newcontent"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult AddContent(string newcontent)
        {

           
            var serializer = new JavaScriptSerializer();
            Content newContent =new Content();
            //IContentRepository repository= new ContentModel();
            try
            {
                dynamic jsoncoor = (Object)serializer.Deserialize<object>(newcontent);
                //newContent= repository.addContent(jsoncoor["Section"], jsoncoor["Title"], jsoncoor["Text"]);

                RamdomID c = new RamdomID();
                newContent.Id = c.RandomString(8);
                newContent.Section = jsoncoor["Section"];
                newContent.Title = jsoncoor["Title"];
                newContent.Text = jsoncoor["Text"];
                newContent.Order = unitOfWork.ContentRepository.Get(S => S.Section.Contains(newContent.Section)).Count();
                unitOfWork.ContentRepository.Insert(newContent);
                unitOfWork.Save();
                
            }
            catch (Exception)
            {
                return Json(false);
            }
          
            

            StringBuilder SB = new StringBuilder();
            // Set div id and class
            SB.Append("<div id=\"");
            SB.Append(newContent.Id);
            SB.Append("\" class=\"");
            SB.Append(newContent.Class);
            SB.Append("\">");
            // Set title and text

            SB.Append("Titulo:<br><input disabled type=\"text\" name=\"title\" value=\"");
            SB.Append(newContent.Title);
            SB.Append("\"></input><br>");
            //Set Text
            SB.Append("Texto:<br><input disabled type=\"text\" name=\"text\" value=\"");
            SB.Append(newContent.Text);
            SB.Append("\"></input><br>");
            
            //Edit content button
            SB.Append("<button type=\"button\" value=\"Edit\" >Editar</button>");
            SB.Append("<button type=\"button\" value=\"Images\" >Imagenes</button>");
            SB.Append("<button type=\"button\" value=\"Delete\"  >Borrar</button>");
            SB.Append("</div>");
            //Upload content button
            //SB.Append("<div class=\"row\"><span class=\"span4\"><input type=\"file\" name=\"uploadImages\" multiple=\"multiple\" class=\"input-files\" /></span><span class=\"span2\"><input type=\"button\" name=\"button\" value=\"Subir\" class=\"btn btn-upload\"></input></span></div>");
            return Json(SB.ToString(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteContent(string content)
        {
            try
            {
                int order = unitOfWork.ContentRepository.GetByID(content).Order;
                foreach (Content cont in unitOfWork.ContentRepository.Get(S=>S.Order>order))
                {
                    cont.Order--;
                }
                unitOfWork.ContentRepository.Delete(content);
                foreach(Picture pic in unitOfWork.PictureRepository.Get(s=>s.Content_Id.Contains(content))){
                pic.Content_Id="borrado";
                unitOfWork.PictureRepository.Update(pic);
                    
                }
                unitOfWork.Save();
                return Json(true);

            }
            catch (Exception)
            {
                return Json(false);
            }
        }
        public JsonResult DeletePicture(string id)
        {
            try
            {
                
                
                Picture pic=  unitOfWork.PictureRepository.GetByID(id);
                pic.Content_Id="borrado";
                unitOfWork.PictureRepository.Update(pic);
                unitOfWork.Save();
                return Json(true);

            }
            catch (Exception)
            {
                return Json(false);
            }
        }

        
        //[AcceptVerbs(HttpVerbs.Post)]
        //public JsonResult UploadImages(string contentID)
        //{
        //    IContentRepository repository = new ContentModel();
        //    foreach (string file in Request.Files)
        //    {

        //       HttpPostedFileBase UploadedFile = Request.Files[file];
        //        //Save file here

        //      Picture newpicture;
        //     if (UploadedFile != null)
        //     {
        //        newpicture = new Picture();
        //        newpicture.ImageMimeType = UploadedFile.ContentType;//public string ImageMimeType { get; set; }
        //        newpicture.ImageData = new byte[UploadedFile.ContentLength];//public byte[] ImageData { get; set; }
        //        UploadedFile.InputStream.Read(newpicture.ImageData, 0, UploadedFile.ContentLength);
        //        repository.addPicture(newpicture);
        //     }
            
        //    }

        //        return Json(true);
        //}
   
        /// <summary>
        /// Get Images in Base64
        /// </summary>
        /// <param name="section"></param>
        /// <returns></returns>
        public JsonResult GetImagesBase64(String section)
        {


            Picture[] images = unitOfWork.PictureRepository.Get(S => S.Content_Id.Contains(section)).ToArray();
            String[] images64 = new String[images.Length];
            int index= 0;
            foreach (Picture image in images)
            {

                images64[index] = Convert.ToBase64String(images[index].ImageData);
                index++;


            }
            return Json(images64);
        }
         public JsonResult GetImages(String section)
        {
           
            
             StringBuilder SB = new StringBuilder();
             SB.Append(@"<div class=""ImageSmall"">");
            foreach (Picture image in unitOfWork.PictureRepository.Get(S=>S.Content_Id.Contains(section))) {


                //var stream = new MemoryStream(image.ImageData.ToArray());

                //FileStreamResult newFile = new FileStreamResult(stream, image.ImageMimeType.ToString());
                SB.Append(@"<div id=""");
                SB.Append(image.Id);
                SB.Append(@""">");
                SB.Append(@"<img alt="""" src=""data:");
                SB.Append(image.ImageMimeType);
                SB.Append(";base64,");
                SB.Append(Convert.ToBase64String(image.ImageData));
                SB.Append("\">");
   
                SB.Append(@"<a  href=""#"" onclick=""deletePicture('");
                SB.Append(image.Id);
                SB.Append(@"');return false;"">Borrar</a>");
                SB.Append("</div>");
                    
                
            }
            SB.Append("</div>");
            return Json(SB.ToString());
         }
            [HttpPost]
        public WrappedJsonResult UploadImage(HttpPostedFileWrapper uploadImages, string contentID)
        {

            if (uploadImages == null || uploadImages.ContentLength == 0)
            {
                return new WrappedJsonResult
                {
                    Data = new
                    {
                        IsValid = false,
                        Message = "No file was uploaded.",
                        ImagePath = string.Empty
                    }
                };
            }
                //Save as file
            //var fileName = String.Format("{0}.jpg", Guid.NewGuid().ToString());
            //var imagePath = Path.Combine(Server.MapPath(Url.Content("~/Content/UserImages")), fileName);
            //uploadImages.SaveAs(imagePath);


            //Save in database

            //IContentRepository repository = new ContentModel();
            Picture newpicture;
            RamdomID r = new RamdomID();
            newpicture = new Picture();
            if (uploadImages != null)
            {
                
                newpicture.ImageMimeType = uploadImages.ContentType;//public string ImageMimeType { get; set; }
                newpicture.ImageData = new byte[uploadImages.ContentLength];//public byte[] ImageData { get; set; }
                uploadImages.InputStream.Read(newpicture.ImageData, 0, uploadImages.ContentLength);
                newpicture.Content_Id = contentID;
                newpicture.Id = r.RandomString(8);
                newpicture.Name = uploadImages.FileName;
                unitOfWork.PictureRepository.Insert(newpicture);
                unitOfWork.Save();
                //repository.addPicture(newpicture);
            }
          

            return new WrappedJsonResult
            {
                Data = new
                {
                    IsValid = true,
                    Message = string.Empty,
                    ImagePath = Convert.ToBase64String(newpicture.ImageData)
                    //ImagePath = Url.Content(String.Format("~/Content/UserImages/{0}", fileName))
                }
            };
        }


    }



}
