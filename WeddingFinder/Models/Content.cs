using System;
using System.Collections.Generic;

namespace WeddingFinder.Models
{
    public partial class Content
    {
        public Content()
        {
            Business = new HashSet<Business>();
        }

        public int ContentId { get; set; }
        public string ShortBlurb { get; set; }
        public string Body1 { get; set; }
        public string Body2 { get; set; }
        public string Body3 { get; set; }
        public string ImgProfile { get; set; }
        public string Img2 { get; set; }
        public string Img3 { get; set; }
        public string Img4 { get; set; }
        public int? ImgSortOrder { get; set; }

        public virtual ICollection<Business> Business { get; set; }
    }
}
