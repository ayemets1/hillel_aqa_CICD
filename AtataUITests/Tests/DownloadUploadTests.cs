﻿using Atata;
using AtataUITests.Infrastructure;
using AtataUITests.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtataUITests.Tests
{
    internal class DownloadUploadTests : UITestFixture
    {
        [Test,Description("Download file to Context, verify file exists")]
        [Category("Smoke")]
        public void DownloadToContextTest()
        {
            Go.To<DemoQADownloadUploadPage>().ScrollDown().
                Download.Click();

            AtataContext.Current.Artifacts.Should.WithinSeconds(10).ContainFile("sampleFile.jpeg");
        }

        [Test,Description("Upload the downloaded file")]
        public void UploadFromContextTest()
        {
            Go.To<DemoQADownloadUploadPage>().
               Download.Click();

            AtataContext.Current.Artifacts.Should.WithinSeconds(10).ContainFile("sampleFile.jpeg");

            Go.To<DemoQADownloadUploadPage>().
                Upload.Set(HelperMethods.GetArtifactsDirectoryPath() + "\\sampleFile.jpeg").
                UploadedFileText.Should.BeVisible();
        }

        [Test, Description("Upload file from the particular folder")]
        [Category("Smoke")]
        public void UploadFromParticularFolder()
        {           
            Go.To<DemoQADownloadUploadPage>().ScrollDown().
                Upload.Set(HelperMethods.GetProjectFilePath() + "Downloads/sampleFile.jpeg").
            UploadedFileText.Should.BeVisible();
        }
    }
}