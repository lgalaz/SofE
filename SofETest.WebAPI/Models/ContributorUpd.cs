using System;
using System.ComponentModel.DataAnnotations;

namespace SofETest.WebAPI.Models
{
    public class ContributorUpd : Contributor
    {
        [Range(1, 2147483647, ErrorMessage = "Id must be an integer gater or equal to 1 and no bigger than 2147483647")]
        public override int Id {get; set;}
    }
}