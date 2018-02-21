using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    public class ProjectData : IEquatable<ProjectData>, IComparable<ProjectData>
    {
        public ProjectData()
        {
        }

        public ProjectData(string name)
        {
            Name = name;
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string ViewStatus { get; set; }
        public string Status { get; set; }
        public bool InheritGlobalCategories { get; set; }
        public string Description { get; set; }
        public bool Enabled { get; set; }

        public int CompareTo(ProjectData other)
        {
            if (object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return Name.CompareTo(other.Name);
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

            return Name == other.Name;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public override string ToString()
        {
            return $"ProjectName = {Name}";
        }
    }
}
