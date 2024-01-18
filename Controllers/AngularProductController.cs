using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models.Domain;
using WebAPI.Models.DTO;
using WebAPI.Repository.Abstract;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/{action}")]
    [ApiController]
    public class AngularProductController : ControllerBase
    {
        private readonly IFileService _fileService;
        private readonly IProductRepository _productRepo;
       public AngularProductController(IFileService fileservice, IProductRepository productRepo)
        {
            this._fileService = fileservice;
            this._productRepo = productRepo;
        }
        [HttpPost]
        public IActionResult add([FromForm]AngularProduct model)
        {
            var status = new Status();
            if (!ModelState.IsValid)
            {
                status.StatusCode = 0;
                status.Message = "Please pass the valid data";
                return Ok(status);
            }
            if (model.ImageFile != null)
            {
                var fileResult = _fileService.saveImage(model.ImageFile);
                if (fileResult.Item1 == 1)
                {
                    model.image = fileResult.Item2; // getting name of image
                }
                var productResult = _productRepo.add(model);
                if (productResult)
                {
                    status.StatusCode = 1;
                    status.Message = "Added successfully";
                }
                else
                {
                    status.StatusCode = 0;
                    status.Message = "Error on adding product";

                }
            }
            return Ok(status);

        }

        [HttpGet]
        public IActionResult getAll()
        {
            return Ok(_productRepo.getAll());
        }

    }
}
