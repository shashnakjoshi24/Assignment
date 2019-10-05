using System;

namespace SLMS.Entity
{
    public class ErrorEntity
    {
        public int ErrorID { get; set; }
        public DateTime ErrorDateTime { get; set; }
        public string ErrorMessage { get; set; }
        public string ErrorDescription { get; set; }
        public short UserID { get; set; }
    }
}