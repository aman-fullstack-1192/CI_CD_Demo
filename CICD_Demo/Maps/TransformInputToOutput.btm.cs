namespace CICD_Demo.Maps {
    
    
    [Microsoft.XLANGs.BaseTypes.SchemaReference(@"CICD_Demo.Schemas.Input", typeof(global::CICD_Demo.Schemas.Input))]
    [Microsoft.XLANGs.BaseTypes.SchemaReference(@"CICD_Demo.Schemas.Output", typeof(global::CICD_Demo.Schemas.Output))]
    public sealed class TransformInputToOutput : global::Microsoft.BizTalk.TestTools.Mapper.TestableMapBase {
        
        private const string _strMap = @"<?xml version=""1.0"" encoding=""UTF-16""?>
<xsl:stylesheet xmlns:xsl=""http://www.w3.org/1999/XSL/Transform"" xmlns:msxsl=""urn:schemas-microsoft-com:xslt"" xmlns:var=""http://schemas.microsoft.com/BizTalk/2003/var"" exclude-result-prefixes=""msxsl var s0 userCSharp"" version=""1.0"" xmlns:ns0=""http://CICD_Demo.Schemas.Output"" xmlns:s0=""http://CICD_Demo.Schemas.Input"" xmlns:userCSharp=""http://schemas.microsoft.com/BizTalk/2003/userCSharp"">
  <xsl:output omit-xml-declaration=""yes"" method=""xml"" version=""1.0"" />
  <xsl:template match=""/"">
    <xsl:apply-templates select=""/s0:Req"" />
  </xsl:template>
  <xsl:template match=""/s0:Req"">
    <xsl:variable name=""var:v1"" select=""userCSharp:StringConcat(string(FirstName/text()) , &quot; &quot; , string(LastName/text()))"" />
    <ns0:Resp>
      <FullName>
        <xsl:value-of select=""$var:v1"" />
      </FullName>
    </ns0:Resp>
  </xsl:template>
  <msxsl:script language=""C#"" implements-prefix=""userCSharp""><![CDATA[
public string StringConcat(string param0, string param1, string param2)
{
   return param0 + param1 + param2;
}



]]></msxsl:script>
</xsl:stylesheet>";
        
        private const int _useXSLTransform = 0;
        
        private const string _strArgList = @"<ExtensionObjects />";
        
        private const string _strSrcSchemasList0 = @"CICD_Demo.Schemas.Input";
        
        private const global::CICD_Demo.Schemas.Input _srcSchemaTypeReference0 = null;
        
        private const string _strTrgSchemasList0 = @"CICD_Demo.Schemas.Output";
        
        private const global::CICD_Demo.Schemas.Output _trgSchemaTypeReference0 = null;
        
        public override string XmlContent {
            get {
                return _strMap;
            }
        }
        
        public override int UseXSLTransform {
            get {
                return _useXSLTransform;
            }
        }
        
        public override string XsltArgumentListContent {
            get {
                return _strArgList;
            }
        }
        
        public override string[] SourceSchemas {
            get {
                string[] _SrcSchemas = new string [1];
                _SrcSchemas[0] = @"CICD_Demo.Schemas.Input";
                return _SrcSchemas;
            }
        }
        
        public override string[] TargetSchemas {
            get {
                string[] _TrgSchemas = new string [1];
                _TrgSchemas[0] = @"CICD_Demo.Schemas.Output";
                return _TrgSchemas;
            }
        }
    }
}
