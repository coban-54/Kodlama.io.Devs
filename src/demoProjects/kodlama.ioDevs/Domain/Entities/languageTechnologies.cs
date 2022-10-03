using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class LanguageTechnologies : Entity
    {
        public int LanguageId { get; set; }
        public string TechnologyName { get; set; }
        public string TechnologyDescription { get; set; }
        public virtual Language? Language { get; set; }
        public LanguageTechnologies()
        {

        }

        public LanguageTechnologies(int id,int languageId, string technologyName, string technologyDescription):this()
        {
            Id = id;
            LanguageId = languageId;
            TechnologyName = technologyName;
            TechnologyDescription = technologyDescription;
        }
    }
}
