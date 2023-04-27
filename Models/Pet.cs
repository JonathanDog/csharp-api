using System;
namespace cSharpApi.Models

{
    public class Pet
    {
        public int PetId { get; set; }
        public string PetName { get; set; }
        public string PetType { get; set; }
        public int OwnerId { get; set; }

    }
}