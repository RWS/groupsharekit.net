using Sdl.Community.GroupShareKit;
using Sdl.Community.GroupShareKit.Clients;

namespace GroupShareKitExample
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var groupShareServerUrl = Environment.GetEnvironmentVariable("GroupShareServerUrl");
            Console.WriteLine($"Running against {groupShareServerUrl}");

            var serverUrl = new Uri(groupShareServerUrl);
            var user = $"{Environment.UserDomainName}\\{Environment.UserName}";

            var token = GroupShareClient.GetRequestToken(
                user,
                serverUrl,
                GroupShareClient.AllScopes).Result;


            var groupShareClient = GroupShareClient.AuthenticateClient(
                token,
                user,
                password: "",
                bearerId: "",
                serverUrl,
                GroupShareClient.AllScopes).Result;

            
            var sortParameters = new SortParameters
            {
                Property = SortParameters.PropertyOption.CreatedAt,
                Direction = SortParameters.DirectionOption.DESC
            };

            var projectRequest = new ProjectsRequest(sortParameters);
            var projects = groupShareClient.Project.GetProject(projectRequest).Result.Items.Take(10);

            Console.WriteLine("The following 10 projects were found: ");
            foreach (var project in projects)
            {
                Console.WriteLine($"\t- {project.Name}");
            }
        }
    }
}