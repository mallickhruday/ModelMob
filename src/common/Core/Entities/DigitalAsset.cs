using System;

namespace Core.Entities
{
    public class DigitalAsset: BaseEntity
    {
        public Guid DigitalAssetId { get; set; }
        public string Name { get; set; }
        public string FileName { get; set; }
        public string Description { get; set; }
        public string Size { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? FileModified { get; set; }        
        public bool? IsSecure { get; set; }
        public string ContentType { get; set; }
        public string RelativePath { get { return $"api/digitalassets/serve?digitalassetid={DigitalAssetId}"; } }
        public Byte[] Bytes { get; set; } = new byte[0];
        public string Folder { get; set; }
        public DateTime? UploadedOn { get; set; }
        public string UploadedBy { get; set; }       
    }
}
