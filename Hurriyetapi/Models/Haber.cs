using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hurriyetapi.Models
{
    public class Haber
    {
        public int Id { get; set; }
        public string ContentType { get; set; }

        public string CreatedDate { get; set; }

        public string Description { get; set; }

        public List<Filess> Files { get; set; }
        //public IList<File> Files { get; set; }

        public string ModifiedDate { get; set; }

        public string Path { get; set; }
        public string StartDate { get; set; }

        //public Array Tags { get; set; }

        public string Title { get; set; }

        public string Url { get; set; }

    }
    public partial class Filess
    {
        public string FileUrl { get; set; }
        public Filedetail Metadata { get; set; }
    }
    public partial class Filedetail
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }

    public class HaberModel
    {
        public List<Haber> Haber { get; set; }
        public List<Haberinfo> Haberbilgisi { get; set; }
    }
    public class Haberinfo
    {
        public int Id { get; set; }

        public string ContentType { get; set; }
        public string CreatedDate { get; set; }
        public string Description { get; set; }

        public string Editor { get; set; }

        public List<Filess> Files { get; set; }
        public string Text { get; set; }
    }

}