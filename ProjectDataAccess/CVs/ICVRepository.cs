using ProjectBusinessModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDataAccess.CVs
{
    internal interface ICVRepository
    {
        public List<Cv> getListCvsByApplicantId(int id); //getall

        public Cv getCVbyApplicantId(int id, int applicantId); //getone

        public void createNewCV(int applicantId, Cv cv); //create

        public void deleteCV(int id, int applicantId); //update

        public void updateCV(int id, Cv cv, int applicantId); //update

    }
}
