Installing iText 7 for .NET
How to install iText 7 .NET version
Thank you for your interest in our open-source PDF library, iText 7, we hope you will enjoy using our product and share your experiences with us and the iText community. We will walk you through the installation process, from downloading iText 7 to adding the dependencies to your .NET build tool.

Right click on project => click Manage NuGet packages for solution
Search for iTextSharp
Install the package

Declare the following syntaxes in your code module.

C#

using iTextSharp.text;

using iTextSharp.text.pdf;
 


Before you install (commercial license users only)
Make sure you have purchased a commercial license for iText 7. All downloads we offer closed-source come with our commercial license model.
If you do not use the "Automated dependency management" method to install iText 7, you will need to download the proper license key library. You can find the installation guide here.
Important remark: In the installation guide, we use NuGet as a build tool for .NET. - iText 7
Installation
Automated dependency management
iText 7 is available on NuGet. To install the core iText 7 modules, you can install them with a single NuGetPackage by typing the following command in the NuGet Package Manager: 
Install-Package itext7
.

If you have a trial or a commercial license you will also need the iText 7 license key library. You can install this typing the following command in the NuGet Package Manager: 
Install-Package itext7.licensekey
.

NOTE: This is a required dependency for the closed-source add-ons, so it will automatically be installed when you install an add-on that needs the license key library.

Using the iText Artifactory Server
iText 7 NuGet packages are also available on the iText Artifactory server. You can add it as a custom NuGet repository to Visual Studio. In the NuGet Package Manager, go to the settings and add the following URL as a package source: https://repo.itextsupport.com/api/nuget/nuget. You can also browse the iText Artifactory server and download NuGet packages manually.

After Installation
You can find the .NET jump-start tutorial and helpful code examples in the Resources section of our website.

iText 7 Core .NET on GitHub
The source code is available on GitHub.
