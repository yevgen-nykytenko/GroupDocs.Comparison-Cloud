/* 
 * GroupDocs.Comparison for Cloud API Reference
 *
 * No description provided (generated by Swagger Codegen https://github.com/swagger-api/swagger-codegen)
 *
 * OpenAPI spec version: 1.0
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */

using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using RestSharp;
using NUnit.Framework; 
using GroupDocs.Comparison.Cloud.Sdk.Model;
using GroupDocs.Comparison.Cloud.Sdk.Model.Requests;
using ComparisonRequest = GroupDocs.Comparison.Cloud.Sdk.Model.Requests.ComparisonRequest;

namespace GroupDocs.Comparison.Cloud.Sdk.Test.Api
{
    /// <summary>
    ///  Class for testing ComparisonApi
    /// </summary>
    /// <remarks>
    /// This file is automatically generated by Swagger Codegen.
    /// Please update the test case below to test the API endpoint.
    /// </remarks>
    [TestFixture]
    public class ComparisonApiTests : TestsSetup
    {
        private Model.ComparisonRequest GetComparisonRequest(string sourceName, List<string> targetsNames)
        {
            Model.ComparisonRequest comparisonRequest = new Model.ComparisonRequest()
            {
                Settings = new ComparisonRequestSettings()
                {
                    GenerateSummaryPage = true,
                    ShowDeletedContent = true,
                    StyleChangeDetection = true,
                    UseFramesForDelInsElements = false,
                    DetailLevel = "Low",
                    DeletedItemsStyle = new StyleSettingsValues()
                    {
                        BeginSeparatorString = "",
                        EndSeparatorString = "",
                        Color = new Color().Red
                    },
                    InsertedItemsStyle = new StyleSettingsValues()
                    {
                        BeginSeparatorString = "",
                        EndSeparatorString = "",
                        Color = new Color().Blue
                    },
                    StyleChangedItemsStyle = new StyleSettingsValues()
                    {
                        BeginSeparatorString = "",
                        EndSeparatorString = "",
                        Color = new Color().Green
                    },
                    CalculateComponentCoordinates = false,
                    CloneMetadata = "Source",
                    MarkDeletedInsertedContentDeep = false,
                    MetaData = new ComparisonMetadataValues()
                    {
                        Author = "GroupDocs",
                        Company = "GroupDocs",
                        LastSaveBy = "GroupDocs"
                    },
                    Password = "1111",
                    PasswordSaveOption = "User"
                },
                SourceFile = new ComparisonFileInfo()
                {
                    Folder = "",
                    Name = sourceName,
                    Password = ""
                },

            };

            List<ComparisonFileInfo> targets = new List<ComparisonFileInfo>();
            foreach (string targetsName in targetsNames)
            {
                targets.Add(new ComparisonFileInfo()
                {
                    Folder = "",
                    Name = targetsName,
                    Password = ""
                });
            }

            comparisonRequest.TargetFiles = targets.ToArray();

            return comparisonRequest;
        }

        /// <summary>
        /// Test Comparison
        /// </summary>
        [Test]
        public void ComparisonTest()
        {
            string outPath = "result.docx";
            ComparisonRequest request = new ComparisonRequest(GetComparisonRequest("source.docx", new List<string> { "target.docx" }), outPath);
            var response = ComparisonApi.Comparison(request);
            Assert.IsInstanceOf<Link>(response, "response is Link");
        }

        /// <summary>
        /// Test ComparisonImages
        /// </summary>
        [Test]
        public void ComparisonImagesTest()
        {
            string outPath = "result.docx";
            ComparisonImagesRequest request = new ComparisonImagesRequest(GetComparisonRequest("source.docx", new List<string> { "target.docx" }), outPath);
            var response = ComparisonApi.ComparisonImages(request);
            Assert.IsInstanceOf<List<Link>>(response, "response is List<Link>");
        }

        /// <summary>
        /// Test ComparisonImagesStream
        /// </summary>
        [Test]
        public void ComparisonImagesStreamTest()
        {
            ComparisonImagesStreamRequest request = new ComparisonImagesStreamRequest(GetComparisonRequest("source.docx", new List<string> { "target.docx" }));
            var response = ComparisonApi.ComparisonImagesStream(request);
            Assert.IsInstanceOf<System.IO.Stream>(response, "response is System.IO.Stream");
        }

        /// <summary>
        /// Test ComparisonStream
        /// </summary>
        [Test]
        public void ComparisonStreamTest()
        {
            string outPath = "result.docx";
            ComparisonStreamRequest request = new ComparisonStreamRequest(GetComparisonRequest("source.docx", new List<string> { "target.docx" }));
            var response = ComparisonApi.ComparisonStream(request);
            Assert.IsInstanceOf<System.IO.Stream>(response, "response is System.IO.Stream");
        }

    }

}
