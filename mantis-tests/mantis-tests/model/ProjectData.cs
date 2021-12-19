using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace mantis_tests
{
    
    public class ProjectData 
       
    {
      public string Id { get; set; }

        public ProjectData() 
        { 
            
        }

        public ProjectData(string projectName, string projectDescription)
        {
            ProjectName = projectName;
            ProjectDescription = projectDescription;
            
        }

        public ProjectData(string projectName)
        {
            ProjectName = projectName;
           

        }

        public string ProjectName { get; set;  }
        public string ProjectDescription { get; set; }
    }
}
