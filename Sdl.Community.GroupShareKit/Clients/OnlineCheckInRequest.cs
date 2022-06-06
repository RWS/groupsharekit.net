namespace Sdl.Community.GroupShareKit.Clients
{
    public class OnlineCheckInRequest
    {
        public string CheckOutId { get; set; }
        public string ConversionId { get; set; }
        public string Comment { get; set; }

        public OnlineCheckInRequest(string checkOutId, string conversionId, string comment)
        {
            CheckOutId = checkOutId;
            ConversionId = conversionId;
            Comment = comment;
        }
    }
}
