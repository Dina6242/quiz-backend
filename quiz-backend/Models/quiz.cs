using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace quiz_backend.Models
{
    public class quiz
    {
        public int ID { get; set; }
        public string Text { get; set; }
        public string ownerId { get; set; }


    }
}
