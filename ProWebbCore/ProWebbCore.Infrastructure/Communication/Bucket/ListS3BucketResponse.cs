using System;
using System.Collections.Generic;
using System.Text;

namespace ProWebbCore.Communication.Bucket
{
    public class ListS3BucketResponse
    {
        public string BucketName { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
