using Scholia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scholia.Services.MockDB {
    public class MockStudyData {

        public List<Study> Studies { get; set; }

        public MockStudyData() {
            Studies = new List<Study>() {

                new Study {Id = 1, Description="History", PublicContribute = true, PublicSubscribe = true, Name = "History"},
                new Study {Id = 2, Description="About the Author", PublicContribute = true, PublicSubscribe = true, Name = "About the Author"},
                new Study {Id = 3, Description="Literary Criticism", PublicContribute = true, PublicSubscribe = true, Name = "Literary Criticism"}

            };
        }

    }
}
