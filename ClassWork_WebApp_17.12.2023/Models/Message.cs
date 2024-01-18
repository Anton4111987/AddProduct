using System.ComponentModel.DataAnnotations;

namespace ClassWork_WebApp_17._12._2023.Models
{
    public class Message
    {
        [Required(ErrorMessage ="Email не может быть пустым")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Тема не может быть пустая")]
        public string? Subject { get; set; }
        [Required(ErrorMessage = "Сообщение не может быть пустым")]
        public string? StringMessage { get; set; }

    }
}
