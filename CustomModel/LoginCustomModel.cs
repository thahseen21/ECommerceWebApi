using System.ComponentModel.DataAnnotations;

namespace CustomModel
{
    public class LoginCustomModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }


    }
}