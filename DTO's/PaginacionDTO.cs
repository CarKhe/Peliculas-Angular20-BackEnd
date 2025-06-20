namespace PeliculasAPI.DTO_s
{
    public class PaginacionDTO
    {
        public int pagina { get; set; } = 1;
        private int recordsPerPage = 10;
        private readonly int cantMaxRecordsPerPage = 50;

        public int RecordsPerPage
        {
            get { return recordsPerPage; }
            set
            {
                recordsPerPage = (value > cantMaxRecordsPerPage) ? cantMaxRecordsPerPage : value; 
            }

        }
    }
}
