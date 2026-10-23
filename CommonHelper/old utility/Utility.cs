using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iText.Kernel.Pdf;
using iText.IO.Font;
using iText.Html2pdf;
using iText.Layout;
using iText.Layout.Element;
using System.IO;
using iText.Kernel.Events;
using iText.Kernel.Pdf.Canvas;
using iText.Kernel.Font;
using iText.IO.Font.Constants;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Gharshare.Models;
using Document = iText.Layout.Document;
using Microsoft.Extensions.Options;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using System.Reflection;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using iText.Html2pdf.Resolver.Font;

namespace Gharshare.CommonHelper
{
    public class Pager
    {
        public int TotalItems { get; private set; }
        public int? ItemsinCurrentPage { get; set; }
        public int CurrentPage { get; private set; }
        public int PageSize { get; private set; }
        public int TotalPages { get; private set; }
        public int FromRecord { get; set; }
        public int ToRecord { get; set; }
        public int StartPage { get; set; }
        public int EndPage { get; private set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public string SortOrder { get; set; }
        public string? SearchPhrase { get; set; } = string.Empty;
        public string? Type { get; set; } = string.Empty;
        public bool HasSearchPhrase { get; set; } = false;

        public Pager()
        {
        }
        public static int GetPageSize()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.Json", optional: false);
            IConfiguration configuration = builder.Build();
            int pageSize = Convert.ToInt32(configuration.GetValue<string>("PageSize:Size"));
            return pageSize;
        }
        public Pager(int totalItems, int Page, string controllerName,
            string actionName, int pageSize = 10, string? searchPhrase = "", string? type = "",
           Int32? itemsinCurrentPage = 0)
        {
            try
            {
                int totalPages = (int)Math.Ceiling((decimal)totalItems / (decimal)pageSize);
                int currentPage = Page;

                int startPage = currentPage - 5;
                int endPage = currentPage + 4;

                if (startPage <= 0)
                {
                    endPage = endPage - (startPage - 1);
                    startPage = 1;
                }

                if (endPage > totalPages)
                {
                    endPage = totalPages;
                    if (endPage > 10)
                    {
                        startPage = endPage - 9;
                    }
                }

                TotalItems = totalItems;
                CurrentPage = currentPage;
                PageSize = pageSize;
                TotalPages = totalPages;
                StartPage = startPage;
                EndPage = endPage;
                ControllerName = controllerName;
                ActionName = actionName;
                SearchPhrase = searchPhrase;
                ItemsinCurrentPage = itemsinCurrentPage;
                Type = type;
                FromRecord = ((CurrentPage - 1) * PageSize) + 1;
                ToRecord = ((CurrentPage - 1) * PageSize) + (int)ItemsinCurrentPage; //PageSize-1;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
    class PageNumberEventHelper : IEventHandler
    {
        private PdfCanvas canvas;
        private int pageNumber = 1;
        public void HandleEvent(Event currentEvent)
        {
            try
            {
                PdfDocumentEvent pdfEvent = (PdfDocumentEvent)currentEvent;
                PdfDocument pdfDoc = pdfEvent.GetDocument();
                PdfPage page = pdfEvent.GetPage();
                canvas = new PdfCanvas(page);
                canvas.BeginText();
                canvas.SetFontAndSize(PdfFontFactory.CreateFont(StandardFonts.HELVETICA), 10);
                canvas.MoveText(290, 780);
                canvas.ShowText("Page " + pageNumber);
                canvas.EndText();
                canvas.Release();
                pageNumber++;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
    public class Utility
    {
        private IHostingEnvironment _hostingEnvironment;
        // private readonly ITempDataDictionary TempData;, ITempDataDictionary tempData
        public Utility(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
            //TempData = tempData;
        }
        public static string GetConfigSetting(string key, string value)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            IConfiguration configuration = builder.Build();

            // Use string interpolation to dynamically construct the configuration key
            string configSetting = configuration.GetValue<string>($"{key}:{value}");
            return configSetting;
        }
        public static string Format(decimal? value)
        {
            if (value.HasValue)
            {
                return value?.ToString("#,##0");
            }
            else
            {
                return string.Empty;
            }
        }
        public static string ConvertToShortDateFormat(DateTime? date)
        {
            if (date.HasValue)
            {
                return date.Value.ToString("dd/MM/yyyy");
            }
            else
            {
                return string.Empty;
            }
        }
        public static string GetEnumDisplayName(Enum value)
        {
            if (value != null)
            {
                var displayAttribute = value
                    .GetType()
                    .GetMember(value.ToString())
                    .FirstOrDefault()
                    ?.GetCustomAttribute<DisplayAttribute>();

                return displayAttribute != null ? displayAttribute.Name : value.ToString();
            }
            else
                return null;
        }
        public string ResizeAndSaveImage(IFormFile file, string filefolder, int targetSizeInBytes, int width, int height)
        {
            string _filePath = string.Empty;
            string fileNametoreturn = string.Empty;
            try
            {
                if (file != null)
                {
                    string _uploadDir = Path.Combine(_hostingEnvironment.WebRootPath, filefolder);
                    if (!Directory.Exists(_uploadDir))
                    {
                        Directory.CreateDirectory(_uploadDir);
                    }
                    string _fileName = Guid.NewGuid().ToString() + "-" + file.FileName;
                    _fileName = _fileName.Replace(" ", "_");
                    fileNametoreturn = "/" + filefolder + "/" + _fileName.Trim();
                    _filePath = Path.Combine(_uploadDir, _fileName.Trim());

                    var imageStream = file.OpenReadStream();
                    using (var image = new Bitmap(imageStream))
                    {
                        // Calculate the new dimensions based on the original image's aspect ratio
                        int newWidth, newHeight;

                        if (image.Width > image.Height)
                        {
                            // Landscape orientation
                            newWidth = width;
                            newHeight = (int)((float)image.Height / image.Width * newWidth);
                        }
                        else
                        {
                            // Portrait orientation or square
                            newHeight = height;
                            newWidth = (int)((float)image.Width / image.Height * newHeight);
                        }

                        using (var thumbnail = new Bitmap(newWidth, newHeight))
                        {
                            using (var graphic = Graphics.FromImage(thumbnail))
                            {
                                graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
                                graphic.CompositingQuality = CompositingQuality.HighQuality;
                                graphic.SmoothingMode = SmoothingMode.HighQuality;
                                graphic.PixelOffsetMode = PixelOffsetMode.HighQuality;

                                graphic.Clear(System.Drawing.Color.White);

                                // Draw the image on the thumbnail
                                graphic.DrawImage(image, 0, 0, newWidth, newHeight);

                                // Create a memory stream to store the compressed image
                                using (var compressedStream = new MemoryStream())
                                {
                                    var thumbnailQuality = 90; // Initial quality setting
                                    var encoderInfo = GetEncoderInfo(ImageFormat.Jpeg);
                                    var encoder = ImageCodecInfo.GetImageEncoders().First(c => c.FormatID == encoderInfo.FormatID);
                                    var encoderParameters = new EncoderParameters(1);

                                    // Save the thumbnail as a JPEG image with the initial quality setting
                                    encoderParameters.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, (long)thumbnailQuality);
                                    thumbnail.Save(compressedStream, encoder, encoderParameters);

                                    // Loop to adjust quality until the image size is within targetSizeInBytes
                                    while (compressedStream.Length > targetSizeInBytes)
                                    {
                                        // Decrease the quality and re-save the image
                                        thumbnailQuality -= 10;

                                        if (thumbnailQuality < 10)
                                        {
                                            break; // Exit the loop if quality goes below 10
                                        }

                                        encoderParameters.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, (long)thumbnailQuality);
                                        // Reset the memory stream position and clear it
                                        compressedStream.Seek(0, SeekOrigin.Begin);
                                        compressedStream.SetLength(0);

                                        // Save the compressed image again
                                        thumbnail.Save(compressedStream, encoder, encoderParameters);
                                    }

                                    // Save the final compressed image to the file
                                    using (var fs = new FileStream(_filePath, FileMode.Create))
                                    {
                                        compressedStream.Seek(0, SeekOrigin.Begin);
                                        compressedStream.CopyTo(fs);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return fileNametoreturn;
        }
        private ImageCodecInfo GetEncoderInfo(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
            return codecs.FirstOrDefault(codec => codec.FormatID == format.Guid);
        }
        public byte[] GeneratePdfByiText7(string html, string filePath)
        {
            try
            {
                using (var memoryStream = new MemoryStream())
                {
                    // Create a new PDF writer
                    var pdfWriter = new PdfWriter(memoryStream);
                    // Create a new PDF document
                    var pdfDocument = new iText.Kernel.Pdf.PdfDocument(pdfWriter);

                    // Create a new ConversionProperties object
                    var properties = new ConverterProperties();
                    // Configure the conversion properties
                    var baseUri = Utility.GetConfigSetting("baseURI", "URI");
                    //properties.SetBaseUri("https://localhost:7163");
                    properties.SetBaseUri(baseUri);
                    // Explicitly set a font provider
                    properties.SetFontProvider(new DefaultFontProvider(true,true,true));
                    // Convert the HTML to PDF
                    HtmlConverter.ConvertToPdf(html, pdfDocument, properties);
                    // Create a new layout document
                    var document = new Document(pdfDocument);
                    // Add page numbering
                    pdfDocument.AddEventHandler(PdfDocumentEvent.END_PAGE, new PageNumberEventHelper());
                    // Close the PDF document
                    pdfDocument.Close();
                    byte[] pdfBytes = memoryStream.ToArray();
                    //using (FileStream fs = new FileStream(filePath, FileMode.Create))
                    using (FileStream fs = File.Create(filePath))
                    {
                        fs.Write(pdfBytes, 0, pdfBytes.Length);
                    }
                    // Return the PDF as a byte array
                    return memoryStream.ToArray();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<string> RenderViewToStringAsync(
    string viewName, object model,
    ControllerContext controllerContext,
    bool isPartial = false)
        {
            try
            {
                var actionContext = controllerContext as ActionContext;
                var serviceProvider = controllerContext.HttpContext.RequestServices;
                var razorViewEngine = serviceProvider.GetService(typeof(IRazorViewEngine)) as IRazorViewEngine;
                var tempDataProvider = serviceProvider.GetService(typeof(ITempDataProvider)) as ITempDataProvider;

                using (var sw = new StringWriter())
                {
                    var viewResult = razorViewEngine.FindView(actionContext, viewName, !isPartial);

                    if (viewResult?.View == null)
                        throw new ArgumentException($"{viewName} does not match any available view");

                    var viewDictionary =
                        new ViewDataDictionary(new EmptyModelMetadataProvider(),
                            new ModelStateDictionary())
                        { Model = model };

                    var viewContext = new ViewContext(
                        actionContext,
                        viewResult.View,
                        viewDictionary,
                        new TempDataDictionary(actionContext.HttpContext, tempDataProvider),
                        sw,
                        new HtmlHelperOptions()
                    );

                    await viewResult.View.RenderAsync(viewContext);
                    return sw.ToString();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public string GetRootPath()
        {
            try
            {
                string rootPath = _hostingEnvironment.WebRootPath;
                return rootPath;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public byte[] getDocumentByteArray(string filePath)
        {
            byte[] byteArray = null;
            try
            {
                string filepath = GetRootPath() + filePath;
                FileStream fs = new System.IO.FileStream(filepath, FileMode.Open, FileAccess.Read);
                byteArray = ReadStream(fs);
            }
            catch (Exception ex)
            {

            }
            return byteArray;
        }
        public byte[] ReadStream(System.IO.Stream stream)
        {
            long originalPosition = 0;

            if (stream.CanSeek)
            {
                originalPosition = stream.Position;
                stream.Position = 0;
            }

            try
            {
                byte[] readBuffer = new byte[4096];

                int totalBytesRead = 0;
                int bytesRead;

                while ((bytesRead = stream.Read(readBuffer, totalBytesRead, readBuffer.Length - totalBytesRead)) > 0)
                {
                    totalBytesRead += bytesRead;

                    if (totalBytesRead == readBuffer.Length)
                    {
                        int nextByte = stream.ReadByte();
                        if (nextByte != -1)
                        {
                            byte[] temp = new byte[readBuffer.Length * 2];
                            Buffer.BlockCopy(readBuffer, 0, temp, 0, readBuffer.Length);
                            Buffer.SetByte(temp, totalBytesRead, (byte)nextByte);
                            readBuffer = temp;
                            totalBytesRead++;
                        }
                    }
                }

                byte[] buffer = readBuffer;
                if (readBuffer.Length != totalBytesRead)
                {
                    buffer = new byte[totalBytesRead];
                    Buffer.BlockCopy(readBuffer, 0, buffer, 0, totalBytesRead);
                }
                return buffer;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                if (stream.CanSeek)
                {
                    stream.Position = originalPosition;
                }
            }
        }
        public string GenerateFileName(string FileName, string folderpath)
        {
            try
            {
                string folder = string.Empty;
                folder = Path.Combine(_hostingEnvironment.WebRootPath, folderpath);
                if (!Directory.Exists(folder))
                    Directory.CreateDirectory(folder);
                string uniqueFileName = Guid.NewGuid().ToString() + "-" + FileName;//"wwwroot/"+
                string filePath = folderpath + @"/" + uniqueFileName;
                return uniqueFileName;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public string SaveFile(IFormFile file, string filefolder)
        {
            string _filePath = string.Empty;
            try
            {
                if (file != null)
                {
                    string _uploadDir = Path.Combine(_hostingEnvironment.WebRootPath, filefolder);
                    if (!Directory.Exists(_uploadDir))
                    {
                        Directory.CreateDirectory(_uploadDir);
                    }
                    string _fileName = Guid.NewGuid().ToString() + "-" + file.FileName;
                    _fileName = _fileName.Replace(" ", "_");
                    _filePath = Path.Combine(_uploadDir, _fileName.Trim());
                    using (FileStream fs = new FileStream(_filePath, FileMode.Create))
                    {
                        file.CopyTo(fs);
                    }
                    _filePath = @"/" + filefolder + @"/" + _fileName;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return _filePath;
        }
        public void DeletFile(string oldFile)
        {
            try
            {
                if (oldFile != null)
                {
                    string _oldFilePath = _hostingEnvironment.WebRootPath.Trim() + oldFile.Trim();
                    if (File.Exists(_oldFilePath))
                    {
                        File.Delete(_oldFilePath);
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
    public class TwilioService
    {
        private readonly TwilioOptions _options;

        public TwilioService(IOptions<TwilioOptions> options)
        {
            _options = options.Value;
        }
        public async Task SendSmsAsync(string toPhoneNumber, string message)
        {
            try
            {
                TwilioClient.Init(_options.AccountSid, _options.AuthToken);

                var smsMessage = await MessageResource.CreateAsync(
                    body: message,
                    from: new Twilio.Types.PhoneNumber(_options.FromPhoneNumber),
                    to: new Twilio.Types.PhoneNumber(toPhoneNumber)
                );
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }

    public class TwilioOptions
    {
        public string AccountSid { get; set; }
        public string AuthToken { get; set; }
        public string FromPhoneNumber { get; set; }
    }

}
