using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    public class ProjectData
    {
        public ProjectData(string projectName)
        {
            ProjectName = projectName;
        }

        public string ProjectName { get; set; }
        public string Visibility { get; set; }
        public string Status { get; set; }
        public bool InheritGlobalCategories { get; set; }
        public string Discription { get; set; }

        public int CompareTo(ProjectData other)
        {
            if (object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return ProjectName.CompareTo(other.ProjectName);
        }

        public bool Equals(ProjectData other)
        {
            if (object.ReferenceEquals(other, null))
            {
                return false;
            }

            if (object.ReferenceEquals(this, other))
            {
                return true;
            }

            return ProjectName == other.ProjectName;
        }

        public override int GetHashCode()
        {
            return ProjectName.GetHashCode();
        }

        public override string ToString()
        {
            return $"ProjectName = {ProjectName}";
        }
    }
}
