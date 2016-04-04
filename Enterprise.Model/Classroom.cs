using System.Collections.Generic;

namespace Enterprise.Model
{
    public class Classroom : EntityBase<Classroom>
    {
        public virtual int Desks { get; set; }
        public virtual Teacher Teacher { get; set; }
        public virtual List<Student> Students { get; set; }
    }
}
