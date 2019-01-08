using System.Collections.Generic;

namespace Sdl.Community.GroupShareKit.Models.Response
{
    public class Dashboard
    {
	    public List<DashboardCount> MonthlyProjectsCount { get; set; }
	    public List<LanguagePairsInProject> LanguagePairsInProjects { get; set; }
	    public List<DashboardCount> MonthlyWordCount { get; set; }
	    public List<WordsInOrganization> WordsInOrganizations { get; set; }
	    public DashboardStatistics Statistics { get; set; }
	} 

}
