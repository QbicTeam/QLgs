using System.Collections.Generic;

namespace QLgs.EdoCta.API.Dtos
{
    public class UserForUpdateDTO
    {
        public string DisplayName { get; set; }

        public string PhotoUrl { get; set; }

        public string CurrentPwd { get; set; }

        public string NewPwd { get; set; }

        public List<QuestionResponseDTO> Responses { get; set; }  
    }
}

