using System.ComponentModel.DataAnnotations;

namespace PlumGuide.Rover.API.Models.Input
{
    public class SendCommandInputModel
    {
        [Required]
        public string Sequence { get; set; }
    }
}
