using System.ComponentModel.DataAnnotations;
using TodoAppCSharp.Attributes;

namespace TodoAppCSharp.Contracts;

public class TodoRequest
{
        [Required(AllowEmptyStrings = false)] 
        public string Title { get; set; } = string.Empty;
        [Required(AllowEmptyStrings = false)] 
        public string Content { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        [DateValidation(ErrorMessage = "DateOfPublication must be in the past")]
        public DateTime DateOfPublication{ get; set; }
    
}