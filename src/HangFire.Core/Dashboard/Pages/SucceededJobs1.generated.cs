﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Hangfire.Dashboard.Pages
{
    
    #line 2 "..\..\Dashboard\Pages\SucceededJobs.cshtml"
    using System;
    
    #line default
    #line hidden
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    #line 3 "..\..\Dashboard\Pages\SucceededJobs.cshtml"
    using Common;
    
    #line default
    #line hidden
    
    #line 5 "..\..\Dashboard\Pages\SucceededJobs.cshtml"
    using HangFire.Storage;
    
    #line default
    #line hidden
    
    #line 4 "..\..\Dashboard\Pages\SucceededJobs.cshtml"
    using Pages;
    
    #line default
    #line hidden
    
    #line 6 "..\..\Dashboard\Pages\SucceededJobs.cshtml"
    using States;
    
    #line default
    #line hidden
    
    #line 7 "..\..\Dashboard\Pages\SucceededJobs.cshtml"
    using Storage.Monitoring;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    internal partial class SucceededJobs : RazorPage
    {
#line hidden

        public override void Execute()
        {


WriteLiteral("\r\n");









            
            #line 9 "..\..\Dashboard\Pages\SucceededJobs.cshtml"
  
    Layout = new LayoutPage { Title = "Succeeded Jobs" };

    int from, perPage;

    int.TryParse(Request.Query["from"], out from);
    int.TryParse(Request.Query["count"], out perPage);

    var monitor = JobStorage.Current.GetMonitoringApi();
    Pager pager = new Pager(from, perPage, monitor.SucceededListCount())
    {
        BasePageUrl = Request.LinkTo("/succeeded")
    };

    JobList<SucceededJobDto> succeededJobs = monitor
        .SucceededJobs(pager.FromRecord, pager.RecordsPerPage);


            
            #line default
            #line hidden
WriteLiteral("\r\n");


            
            #line 27 "..\..\Dashboard\Pages\SucceededJobs.cshtml"
 if (pager.TotalPageCount == 0)
{

            
            #line default
            #line hidden
WriteLiteral("    <div class=\"alert alert-info\">\r\n        No succeeded jobs found.\r\n    </div>\r" +
"\n");


            
            #line 32 "..\..\Dashboard\Pages\SucceededJobs.cshtml"
}
else
{

            
            #line default
            #line hidden
WriteLiteral("    <div class=\"js-jobs-list\">\r\n        <div class=\"btn-toolbar btn-toolbar-top\">" +
"\r\n            <button class=\"js-jobs-list-command btn btn-sm btn-primary\"\r\n     " +
"               data-url=\"");


            
            #line 38 "..\..\Dashboard\Pages\SucceededJobs.cshtml"
                         Write(Request.LinkTo("/succeeded/requeue"));

            
            #line default
            #line hidden
WriteLiteral("\"\r\n                    data-loading-text=\"Enqueueing...\">\r\n                <span " +
"class=\"glyphicon glyphicon-repeat\"></span>\r\n                Requeue jobs\r\n      " +
"      </button>\r\n\r\n            ");


            
            #line 44 "..\..\Dashboard\Pages\SucceededJobs.cshtml"
       Write(RenderPartial(new PerPageSelector(pager)));

            
            #line default
            #line hidden
WriteLiteral(@"
        </div>

        <table class=""table"">
            <thead>
                <tr>
                    <th class=""min-width"">
                        <input type=""checkbox"" class=""js-jobs-list-select-all"" />
                    </th>
                    <th class=""min-width"">Id</th>
                    <th>Job</th>
                    <th class=""min-width"">Total Duration</th>
                    <th class=""align-right"">Succeeded</th>
                </tr>
            </thead>
            <tbody>
");


            
            #line 60 "..\..\Dashboard\Pages\SucceededJobs.cshtml"
                 foreach (var job in succeededJobs)
                {

            
            #line default
            #line hidden
WriteLiteral("                    <tr class=\"js-jobs-list-row ");


            
            #line 62 "..\..\Dashboard\Pages\SucceededJobs.cshtml"
                                            Write(job.Value != null && !job.Value.InSucceededState ? "obsolete-data" : null);

            
            #line default
            #line hidden
WriteLiteral(" ");


            
            #line 62 "..\..\Dashboard\Pages\SucceededJobs.cshtml"
                                                                                                                         Write(job.Value != null && job.Value.InSucceededState ? "hover" : null);

            
            #line default
            #line hidden
WriteLiteral("\">\r\n                        <td>\r\n");


            
            #line 64 "..\..\Dashboard\Pages\SucceededJobs.cshtml"
                             if (job.Value != null && job.Value.InSucceededState)
                            {

            
            #line default
            #line hidden
WriteLiteral("                                <input type=\"checkbox\" class=\"js-jobs-list-checkb" +
"ox\" name=\"jobs[]\" value=\"");


            
            #line 66 "..\..\Dashboard\Pages\SucceededJobs.cshtml"
                                                                                                     Write(job.Key);

            
            #line default
            #line hidden
WriteLiteral("\" />\r\n");


            
            #line 67 "..\..\Dashboard\Pages\SucceededJobs.cshtml"
                            }

            
            #line default
            #line hidden
WriteLiteral("                        </td>\r\n                        <td class=\"min-width\">\r\n  " +
"                          <a href=\"");


            
            #line 70 "..\..\Dashboard\Pages\SucceededJobs.cshtml"
                                Write(Request.LinkTo("/job/" + job.Key));

            
            #line default
            #line hidden
WriteLiteral("\">\r\n                                ");


            
            #line 71 "..\..\Dashboard\Pages\SucceededJobs.cshtml"
                           Write(HtmlHelper.JobId(job.Key));

            
            #line default
            #line hidden
WriteLiteral("\r\n                            </a>\r\n");


            
            #line 73 "..\..\Dashboard\Pages\SucceededJobs.cshtml"
                             if (job.Value != null && !job.Value.InSucceededState)
                            {

            
            #line default
            #line hidden
WriteLiteral("                                <span title=\"Job\'s state has been changed while f" +
"etching data.\" class=\"glyphicon glyphicon-question-sign\"></span>\r\n");


            
            #line 76 "..\..\Dashboard\Pages\SucceededJobs.cshtml"
                            }

            
            #line default
            #line hidden
WriteLiteral("                        </td>\r\n\r\n");


            
            #line 79 "..\..\Dashboard\Pages\SucceededJobs.cshtml"
                         if (job.Value == null)
                        {

            
            #line default
            #line hidden
WriteLiteral("                            <td colspan=\"3\">\r\n                                <em" +
">Job has expired.</em>\r\n                            </td>\r\n");


            
            #line 84 "..\..\Dashboard\Pages\SucceededJobs.cshtml"
                        }
                        else
                        {

            
            #line default
            #line hidden
WriteLiteral("                            <td>\r\n                                <a class=\"job-m" +
"ethod\" href=\"");


            
            #line 88 "..\..\Dashboard\Pages\SucceededJobs.cshtml"
                                                       Write(Request.LinkTo("/job/" + job.Key));

            
            #line default
            #line hidden
WriteLiteral("\">\r\n                                    ");


            
            #line 89 "..\..\Dashboard\Pages\SucceededJobs.cshtml"
                               Write(HtmlHelper.DisplayMethod(job.Value.Job));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                </a>\r\n                            </td>\r\n");



WriteLiteral("                            <td class=\"min-width align-right\">\r\n");


            
            #line 93 "..\..\Dashboard\Pages\SucceededJobs.cshtml"
                                 if (job.Value.TotalDuration.HasValue)
                                {

            
            #line default
            #line hidden
WriteLiteral("                                    ");

WriteLiteral(" ");


            
            #line 95 "..\..\Dashboard\Pages\SucceededJobs.cshtml"
                                  Write(HtmlHelper.ToHumanDuration(TimeSpan.FromMilliseconds(job.Value.TotalDuration.Value) , false));

            
            #line default
            #line hidden
WriteLiteral("\r\n");


            
            #line 96 "..\..\Dashboard\Pages\SucceededJobs.cshtml"
                                }

            
            #line default
            #line hidden
WriteLiteral("                            </td>\r\n");



WriteLiteral("                            <td class=\"min-width align-right\">\r\n");


            
            #line 99 "..\..\Dashboard\Pages\SucceededJobs.cshtml"
                                 if (job.Value.SucceededAt.HasValue)
                                {

            
            #line default
            #line hidden
WriteLiteral("                                    <span data-moment=\"");


            
            #line 101 "..\..\Dashboard\Pages\SucceededJobs.cshtml"
                                                  Write(JobHelper.ToTimestamp(job.Value.SucceededAt.Value));

            
            #line default
            #line hidden
WriteLiteral("\">\r\n                                        ");


            
            #line 102 "..\..\Dashboard\Pages\SucceededJobs.cshtml"
                                   Write(job.Value.SucceededAt);

            
            #line default
            #line hidden
WriteLiteral("\r\n                                    </span>\r\n");


            
            #line 104 "..\..\Dashboard\Pages\SucceededJobs.cshtml"
                                }

            
            #line default
            #line hidden
WriteLiteral("                            </td>\r\n");


            
            #line 106 "..\..\Dashboard\Pages\SucceededJobs.cshtml"
                        }

            
            #line default
            #line hidden
WriteLiteral("                    </tr>\r\n");


            
            #line 108 "..\..\Dashboard\Pages\SucceededJobs.cshtml"
                }

            
            #line default
            #line hidden
WriteLiteral("            </tbody>\r\n        </table>\r\n    </div>\r\n");


            
            #line 112 "..\..\Dashboard\Pages\SucceededJobs.cshtml"
    
            
            #line default
            #line hidden
            
            #line 112 "..\..\Dashboard\Pages\SucceededJobs.cshtml"
Write(RenderPartial(new Paginator(pager)));

            
            #line default
            #line hidden
            
            #line 112 "..\..\Dashboard\Pages\SucceededJobs.cshtml"
                                        
}

            
            #line default
            #line hidden

        }
    }
}
#pragma warning restore 1591
