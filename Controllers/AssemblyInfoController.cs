using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;

namespace CoreHostInfo.Controllers
{
    [Route("api/[controller]")]
    public class AssemblyInfoController : Controller
    {
        // GET api/assemblyinfo
        [HttpGet]
        public AssemblyDetails[] Get()
        {
            return AssemblyInfo.GetAssemblyInfo();
        }
    }

    public class AssemblyInfo
    {
        public static AssemblyDetails[] GetAssemblyInfo()
        {
            var results = new List<AssemblyDetails>();

            var assemblies = Assembly.GetEntryAssembly().GetReferencedAssemblies();

            foreach (var assembly in assemblies)
            {
                var codebase = Assembly.Load(assembly).CodeBase.Replace("file:///", "");

                AssemblyDetails ad = new AssemblyDetails()
                {
                    Name = assembly.Name,
                    Version = assembly.Version.ToString(),
                    Directory = Path.GetDirectoryName(codebase)
                };

                results.Add(ad);
            }

            return results.ToArray();
        }
    }

    public class AssemblyDetails
    {
        public string Name { get; set; }

        public string Version { get; set; }

        public string Directory { get; set; }
    }
}