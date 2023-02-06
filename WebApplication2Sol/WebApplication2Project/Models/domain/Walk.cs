namespace WebApplication2Project.Models.domain
{
    public class Walk
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Length { get; set; }
        public Guid RegionId { get; set; }
        public Guid WalkDifficultyId { get; set; }

        //navigation property
        public Region Region { get; set; }
        public WalkDifficulty WalkDifficulty { get; set; }
    }
}