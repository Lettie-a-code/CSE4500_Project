using System.ComponentModel.DataAnnotations;

namespace CSE4500.Models
    

{
    public class DogRegistration
    {
        //Primary key is id
        public int Id { get; set; }
        // Dog Info
        [Required]
        public required string DogName { get; set; }

        public string? DobKnown { get; set; }

        public int? Day { get; set; }
        public int? Month { get; set; }
        public int? Year { get; set; }

        // Guardian Info
        [Required]
        public required string FirstName { get; set; }

        [Required]
        public required string LastName { get; set; }

        [Required]
        [Phone]
        public required string Phone { get; set; }

        public string? EmergencyContact { get; set; }

        // Dog Details
        public string? Breed { get; set; }
        public string? Notes { get; set; }

        public string? Interaction { get; set; }
        public string? Triggers { get; set; }

        public string? AdditionalNotes { get; set; }
    }
}


