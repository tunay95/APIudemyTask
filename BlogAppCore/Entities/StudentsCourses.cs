using BlogApp.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Core.Entities
{
	public class StudentsCourses: BaseAuditableEntity
	{
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public Student Student { get; set; }
    }
}
