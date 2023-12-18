namespace ContactBook.Dtos.SystemMessages
{
    public class ResultDto
    {
        public int InsertedId { get; set; } = 0;
        public bool Succeed { get; set; } = false;
        public IList<string> Messages { get; set; } = new List<string>();
        public int IdentityId 
        {
            get { return InsertedId; }
            set
            {
                InsertedId = value;
                Succeed = true;
            }
        }
    }
}
