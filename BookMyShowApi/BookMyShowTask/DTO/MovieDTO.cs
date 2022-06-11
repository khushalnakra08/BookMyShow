namespace BookMyShowTask.DTO
{
    public class MovieDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public string Language { get; set; }
        public string Discription { get; set; }
        public string Country { get; set; }
        public string Source { get; set; }
        public DateTime? Duration { get; set; }
        public DateTime? ReleasedDate { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? DateDeleted { get; set; }

    }
}
