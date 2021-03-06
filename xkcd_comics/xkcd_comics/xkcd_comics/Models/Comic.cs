﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace xkcd_comics.Models
{
    public class Comic
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Month { get; set; }
        public int Num { get; set; }
        public string Link { get; set; }
        public string Year { get; set; }
        public string News { get; set; }
        public string Safe_title { get; set; }
        public string Transcript { get; set; }
        public string Alt { get; set; }
        public string Img { get; set; }
        public string Title { get; set; }
        public string Day { get; set; }
    }
}
