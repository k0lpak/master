using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestProject.Models
{
    public class Message
    {
        public string message { get; set; }

        public Message(string text)
        {
            this.message = text;
        }
    }
}