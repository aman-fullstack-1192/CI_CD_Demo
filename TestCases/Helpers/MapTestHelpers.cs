using System.Collections.Generic;
using BizUnit.TestSteps.Common;
using BizUnit.TestSteps.ValidationSteps.Xml;
using BizUnit.TestSteps.File;
using Microsoft.BizTalk.TestTools.Mapper;
using BizUnit.Core.TestBuilder;
namespace SampleBTApp.TestHelper
{
    public static class MapTestHelpers
    {
        public static void MapTest(string inputMessageFolderPath, string outputMessageFolderPath, TestableMapBase target, string
sourceFile, SchemaDefinition sourceSchema, string destinationFile, SchemaDefinition destinationSchema,
List<XPathDefinition> xpathList)
        {
            ValidateSouceMessage(inputMessageFolderPath, sourceFile, sourceSchema);
 
            string inputMessagePath = inputMessageFolderPath + sourceFile;
            string outputMessagePath = outputMessageFolderPath + destinationFile;
 
            target.ValidateInput = false;
            target.ValidateOutput = false;
            target.TestMap(inputMessagePath, Microsoft.BizTalk.TestTools.Schema.InputInstanceType.Xml, outputMessagePath, 
Microsoft.BizTalk.TestTools.Schema.OutputInstanceType.XML);


       }

       public static void ValidateSouceMessage(string inputMessageFolderPath, string inputFile, SchemaDefinition sourceSchema)
       {
           FileReadMultipleStep fileReadStep = new FileReadMultipleStep();

           fileReadStep.DeleteFiles = false;
           fileReadStep.DirectoryPath = inputMessageFolderPath;
           fileReadStep.SearchPattern = inputFile;
           fileReadStep.FailOnError = true;
           fileReadStep.ExpectedNumberOfFiles = 1;

           XmlValidationStep inputValidationStep = new XmlValidationStep();
           inputValidationStep.XmlSchemas.Add(sourceSchema);

           fileReadStep.SubSteps.Add(inputValidationStep);
           TestCase inValTestCase = new TestCase();
           inValTestCase.Name = "Validate Input Message";
           inValTestCase.ExecutionSteps.Add(fileReadStep);

           BizUnit.Core.TestRunner testRunner = new BizUnit.Core.TestRunner(inValTestCase);
           testRunner.Run();

            
       }


       public static void ValidateDestinationMessage(string OutoutputMessageFolderPath, string outputFile, SchemaDefinition
destinationSchema, List<XPathDefinition> xpathList)
        {
            FileReadMultipleStep fileReadStep = new FileReadMultipleStep();
            fileReadStep.DeleteFiles = false;
            fileReadStep.FailOnError = true;
            fileReadStep.DirectoryPath = OutoutputMessageFolderPath;
            fileReadStep.SearchPattern = outputFile;
            fileReadStep.ExpectedNumberOfFiles = 1;
 
 
            XmlValidationStep validateOutPutStep = new XmlValidationStep();
            validateOutPutStep.XmlSchemas.Add(destinationSchema);
 
            foreach( var xpath in xpathList)
            {
                validateOutPutStep.XPathValidations.Add(xpath);
            }
 
            fileReadStep.SubSteps.Add(validateOutPutStep);
 
            TestCase outValTestCase = new TestCase();
            outValTestCase.Name= "Validate Output Message";
            outValTestCase.ExecutionSteps.Add(fileReadStep);
 
            BizUnit.Core.TestRunner testRunner = new BizUnit.Core.TestRunner(outValTestCase);
            testRunner.Run();
 
 
 
        }
    }
}