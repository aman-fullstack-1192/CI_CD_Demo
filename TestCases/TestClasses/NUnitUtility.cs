using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCases.SampleAppServiceRef;
public static class NUnitUtility
{
    public static bool TestBizTalkAppService(string firstName, string lastName)
    {
        bool retVal = false;
 
        NameAppenderServiceClient client = new NameAppenderServiceClientClient();
 
        Req req = new Req();
        req.FirstName = firstName;
        req.LastName = lastName;
 
        Resp resp = client.NameAppenderService(req);
 
        if (resp != null && resp.FullName == firstName + " " + lastName)
            retVal=true;
        return retVal;
    }
}
