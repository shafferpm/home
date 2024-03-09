using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CityInfo.API.Model
{
    public class CityDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int NumberOfPointsOfInterest 
        { 
            get 
            { 
                return PointsOfInterests.Count;
            } 
        }

        public ICollection<PointOfInterestDto> PointsOfInterests { get; set;} = 
            new List<PointOfInterestDto>();
    }
}
