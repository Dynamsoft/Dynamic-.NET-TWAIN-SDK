Dynamic .NET TWAIN SDK
=========
version 5.2

Introduction
-----------

[Dynamic .NET TWAIN][1] is a document imaging SDK based on the 2.0/4.0 version of the Microsoft .NET Framework.
Optimized for use in C# and VB .NET, it provides rich APIs for scanner and webcam software development.

Use the SDK 
-----------

* Install the Dynamic .NET TWAIN SDK from the [download site][2]
* Launch Visual Studio to open your project
* Right-click References > Add Reference ```DynamicDotNetTWAIN.dll```

Documentation
--------------

Visit: http://www.dynamsoft.com/help/TWAIN/.Net-TWAIN-Scanner/html/AllMembers_T_Dynamsoft_DotNet_TWAIN_DynamicDotNetTwain.htm.

Highlights
-----------

* Compatible with TWAIN Specification 2.1, and backwards compatible with earlier specifications.
* Compatible with UVC/WIA Webcams
* Supports .NET 32 and 64 bit
* WinForms & WPF controls available for most components
* Customizable image scanning and loading process
* Supports WinForms (.NET Framework V2.0 SP2 and above) & WPF (.NET Framework V3.5 SP 1 and above) applications.
* Supports BMP, JPEG, PNG, TIFF, PDF, multi-page TIFF, and multi-page PDF file formats.
* Supports image editing features including Rotate, Flip, Mirror, Crop, and Erase.
* Save and upload images to a local disk, FTP site, web server or database.

Sample Code
-----------

[Barcode Generator][3] & [Barcode Reader][8]

* Add ```DynamicBarcode.dll``` to BarcodeGenerator\Redistributable\BarcodeResources

[OCR][4]
* Download [OCR SDK Language Packages][5]
* Move language packages to OCRDemo\Redistributable\tessdata
* Add ```DynamicOCR.dll``` to OCRDemo\Redistributable\OCRResources

[PDF Rasterizer][6]
* Add ```DynamicPdf.dll``` to PDFRasterizer\Redistributable\PDFResources

[Webcam][7]
* The sample demonstrates how to capture images from Webcam with C# or VB.NET

[1]:http://www.dynamsoft.com/Products/.Net-TWAIN-Scanner.aspx
[2]:https://www.dynamsoft.com/Secure/Register_ClientInfo.aspx?productName=NetTWAIN&from=FromDownload
[3]:https://github.com/DynamsoftRD/Dynamic-.NET-TWAIN-SDK/tree/master/src/BarcodeGeneratorDemo
[4]:https://github.com/DynamsoftRD/Dynamic-.NET-TWAIN-SDK/tree/master/src/OCRDemo
[5]:http://www.dynamsoft.com/Downloads/OCR-Language-Package.aspx
[6]:https://github.com/DynamsoftRD/Dynamic-.NET-TWAIN-SDK/tree/master/src/PDFRasterizerDemo
[7]:https://github.com/DynamsoftRD/Dynamic-.NET-TWAIN-SDK/tree/master/src/WebcamDemoCode
[8]:https://github.com/DynamsoftRD/Dynamic-.NET-TWAIN-SDK/tree/master/src/BarcodeReaderCode