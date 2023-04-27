using System;
namespace cSharpApi.Models

{
    public class Response
    {
        public int statusCode { get; set; }
        public string? statusDescription { get; set; }

        public List<Owner> owners { get; set; } = new List<Owner>();
        public List<Pet> pets { get; set; } = new List<Pet>();


    }
}