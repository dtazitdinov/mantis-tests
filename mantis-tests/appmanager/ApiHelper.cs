using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    public class ApiHelper : HelperBase
    {
        private Mantis_API.MantisConnectPortTypeClient client;

        public ApiHelper(ApplicationManager manager) : base(manager)
        {
            client = new Mantis_API.MantisConnectPortTypeClient();
        }

        public void CreateNewProject(AccountData account, ProjectData projectData)
        {
            Mantis_API.ProjectData project = new Mantis_API.ProjectData()
            {
                name = projectData.Name,
                status = new Mantis_API.ObjectRef() {id = projectData.Status},
                inherit_global = projectData.InheritGlobalCategories,
                description = projectData.Description,
                enabled = projectData.Enabled,
                view_state = new Mantis_API.ObjectRef() {id = projectData.ViewStatus }
            };

            client.mc_project_add(account.Username, account.Password, project);
        }

        public void DeleteProject(AccountData account, string id)
        {
            client.mc_project_delete(account.Username, account.Password, id);
        }

        public void CheckProjectPresent(AccountData account)
        {
            if(GetProjectList(account).Count == 0)
            {
                ProjectData project = new ProjectData()
                {
                    Name = "Project_" + TestBase.GenerateRandomNumber(1000),
                    Status = "10",
                    InheritGlobalCategories = true,
                    ViewStatus = "10",
                    Description = "Discription"
                };
                CreateNewProject(account, project);
            }
        }

        public List<ProjectData> GetProjectList(AccountData account)
        {
            List<ProjectData> list = new List<ProjectData>();

            Mantis_API.ProjectData[] listFromApi 
                = client.mc_projects_get_user_accessible(account.Username, account.Password);

            foreach (Mantis_API.ProjectData element in listFromApi)
            {
                list.Add(new ProjectData()
                {
                    Id = element.id,
                    Name = element.name,
                    Status = element.status.id,
                    InheritGlobalCategories = element.inherit_global,
                    Description = element.description,
                    Enabled = element.enabled,
                    ViewStatus = element.view_state.id
                });
            }
            return list;
        }
    }
}
