using AutoMapper;
using Contracts;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;

namespace File.Controllers
{

    [ApiController]
    [Route("api/file")]
    public class FileController : ControllerBase
    {
        private readonly IRepositoryWrapper repositoryWrapper;
        private readonly IMapper mapper;

        public FileController(IRepositoryWrapper repositoryWrapper, IMapper mapper)
        {
            this.repositoryWrapper = repositoryWrapper;
            this.mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {           
            return new string[] { "Det funkar" };
        }

        [EnableCors]
        [HttpPost, DisableRequestSizeLimit]
        public IActionResult Upload()
        {
            try
            {
                var file = Request.Form.Files[0];
                var folderName = Path.Combine("Resources", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');

                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);
                                        
                    repositoryWrapper.File.UploadFile(fileName, dbPath);
                    repositoryWrapper.Save();
                    
                    var filters = new String[] { "jpg", "jpeg", "png", "gif", "tiff", "bmp", "svg" };
                    
                    foreach (var imageType in filters)
                    {
                        if (Path.GetExtension(file.FileName) == imageType)
                        {
                            var highestOccuringWord = CheckTheHighestOccuringWord(fileName);
                            return Ok(new { highestOccuringWord });
                        }
                    }                                        

                    return Ok(new { fullPath });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        private string CheckTheHighestOccuringWord(string fileName)
        {
            var mostCommonFilename = repositoryWrapper.File.GetAllFiles().GroupBy(w => w.Name).OrderByDescending(g => g.Count()).First().Key;
            var _mostCommonFilename = DeleteFileTypeFromName(mostCommonFilename);
            var _fileName = DeleteFileTypeFromName(fileName);

            if (_mostCommonFilename == _fileName)
            {
                return string.Format("foo{0}bar", _mostCommonFilename);
            }
            else
            {
                return fileName;
            }
        }

        private string DeleteFileTypeFromName(string fileName)
        {
            var FilenameMinusFiletype = fileName.Substring(0, fileName.LastIndexOf('.'));

            return FilenameMinusFiletype;
        }
    }
}
