using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using BizUnit.TestSteps.ValidationSteps.Xml;
using Microsoft.BizTalk.TestTools.Mapper;

using System.Collections.Generic;
using BizUnit.TestSteps.Common;
using SampleBTApp.TestHelper;

namespace SampleBTApp.UnitTests
{
    [TestClass]
    public class MapTests
    {
        private const string InputFileDirectory =
@"E:\BizTalkCICDUsingJenkins\BizTalkApp\SampleBTApp\SampleBTApp.UnitTests\SampleMessages\In\";
       private const string OutputFileDirectory =
@"E:\BizTalkCICDUsingJenkins\BizTalkApp\SampleBTApp\SampleBTApp.UnitTests\SampleMessages\Out\";
 
        SchemaDefinition sourceSchema = new SchemaDefinition()
        {
            XmlSchemaNameSpace = "http://SampleBTApp.Schemas.Input Jump ",
            XmlSchemaPath = @"E:\BizTalkCICDUsingJenkins\BizTalkApp\SampleBTApp\SampleBTApp.Schemas\Input.xsd"
 
        };
 
        SchemaDefinition destinationSchema = new SchemaDefinition()
        {
            XmlSchemaNameSpace = "http://SampleBTApp.Schemas.Output Jump ",
            XmlSchemaPath = @"E:\BizTalkCICDUsingJenkins\BizTalkApp\SampleBTApp\SampleBTApp.Schemas\Output.xsd"
        };
 
        [TestMethod]
        public void TestTransform_Input_To_OutputMap()
        {
            var inputSchema = sourceSchema;
            var outputSchema = destinationSchema;
            const string inputFile = "Input.xml";
            const string outputFile = "Output.xml";
            const string fullNameXpath = "/*[local-name()='Resp' and namespace-uri()='http://SampleBTApp.Schemas.Output Jump ']/*[local - name() = 'FullName' and namespace-uri()='']";
 
            List<XPathDefinition> xpathList = new List<XPathDefinition>()
            {
            new XPathDefinition()
                {
                XPath = fullNameXpath,
                Value = "Mandar Dharmadhikari"

            }
        };

        TestableMapBase target = new CICD_Demo.Maps.TransformInputToOutput();
        MapTestHelpers.MapTest(InputFileDirectory, OutputFileDirectory, target, inputFile, sourceSchema, outputFile, 
destinationSchema, xpathList);
             
        }
    }
}
