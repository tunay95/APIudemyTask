using BlogApp.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Core.Entities
{
	public class Student: BaseAuditableEntity
	{
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public List<StudentsCourses> StudentsCourses { get; set; }
    }
}
