using ProjectBusinessModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDataAccess.Skills
{
    public class Skillepository: iSkillRepository
    {
        private readonly FinalProjectPrn231Context _context;

        public Skillepository(FinalProjectPrn231Context context)
        {
            _context = context;
        }

        public Skill GetSkill(int id)
        {
            try
            {
                return _context.Skills.FirstOrDefault(skill => skill.Id == id);

            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public List<Skill> GetSkillRequiredByJobId(int id)
        {
            try
            {
                var listSkill = _context.Skills
                               .Where(skill => skill.Jobs.Any(job => job.Id == id)) // Assuming Skill has a navigation property Jobs
                               .ToList();
                return listSkill;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            
        }

        public List<Skill> GetSkills()
        {
            try
            {
                var skillList = _context.Skills.ToList();
                return skillList;
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
