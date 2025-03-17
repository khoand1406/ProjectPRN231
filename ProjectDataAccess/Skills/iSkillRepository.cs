using ProjectBusinessModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDataAccess.Skills
{
    public interface iSkillRepository
    {
        List<Skill> GetSkills();

        Skill GetSkill(int id);

        List<Skill> GetSkillRequiredByJobId(int id);

        

    }
}
