using System.ComponentModel.DataAnnotations;

namespace QLgs.EdoCta.API.Dtos
{
    public class QuestionForRegisterDTO
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Response { get; set; }
    }
}